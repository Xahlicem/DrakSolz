using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items {
    public class DSGlobalItem : GlobalItem {
        internal int fromPlayer;
        public int FromPlayer { get { return fromPlayer; } set { fromPlayer = value; } }

        public bool Owned { get; set; }
        public bool Used { get; set; }
        public override bool CloneNewInstances { get { return true; } }
        public override bool InstancePerEntity { get { return true; } }

        public DSGlobalItem() {
            if (Main.netMode == NetmodeID.SinglePlayer) fromPlayer = -1;
            else fromPlayer = -2;
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            var source = item.GetGlobalItem<DSGlobalItem>();
            var destination = itemClone.GetGlobalItem<DSGlobalItem>();
            if (source != null && destination != null) {
                destination.Owned = source.Owned;
                destination.Used = source.Used;
                destination.FromPlayer = fromPlayer;
            }
            return destination;
        }

        public override void OnCraft(Item item, Recipe recipe) {
            Owned = true;
        }

        public override bool UseItem(Item item, Player player) {
            Used = true;
            return base.UseItem(item, player);
        }

        public override void PostReforge(Item item) {
            fromPlayer = item.owner;
            Owned = true;
        }

        public override bool OnPickup(Item item, Player player) {
            fromPlayer = player.whoAmI;
            Owned = true;
            return true;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (item.GetGlobalItem<DSGlobalItem>().Owned) return;
            SoulItem i = item.modItem as SoulItem;
            if (i == null) return;
            tooltips[0].text += " (" + i.SoulValue + " Souls required)";
        }

        public override void NetSend(Item item, System.IO.BinaryWriter writer) {
            writer.Write(fromPlayer);
            writer.Write(Used);
        }

        public override void NetReceive(Item item, System.IO.BinaryReader reader) {
            fromPlayer = reader.ReadInt32();
            Used = reader.ReadBoolean();
        }

        public override bool NeedsSaving(Item item) {
            if (item.type == 0 || item.consumable || item.ammo > 0 || item.type == ModLoader.GetMod("ModLoader").ItemType("MysteryItem")) {
                return false;
            }
            return true;
        }

        public override TagCompound Save(Item item) {
            if (item.type == 0 || item.type == ModLoader.GetMod("ModLoader").ItemType("MysteryItem")) {
                return null;
            }
            DSGlobalItem info = item.GetGlobalItem<DSGlobalItem>();
            return new TagCompound { { "owned", info.Owned }, { "used", info.Used }, { "fromPlayer", fromPlayer } };
        }

        public override void Load(Item item, TagCompound tag) {
            Owned = tag.GetBool("owned");
            Used = tag.GetBool("used");
            fromPlayer = tag.GetInt("fromPlayer");
        }
    }

    public class SoulItem : ModItem {
        public int SoulValue { get; internal set; }

        public SoulItem(int value) {
            SoulValue = value;
        }

        public override bool Autoload(ref string name) {
            return (GetType() == typeof (SoulItem)) ? false : base.Autoload(ref name);
        }
    }

    public class SoulRecipe : ModRecipe {
        private int requiredSouls;
        public SoulRecipe(Mod mod, SoulItem result) : base(mod) {
            requiredSouls = result.SoulValue;
            SetResult(result);
        }

        public override bool RecipeAvailable() {
            return (Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().Souls >= requiredSouls);
        }

        public override void OnCraft(Item item) {
            Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().Souls -= requiredSouls;
        }
    }
}