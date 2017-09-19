using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items {
    public class OwnedItem : GlobalItem {
        internal int fromPlayer;
        public int FromPlayer { get { return fromPlayer; } set { fromPlayer = value; } }

        public bool owned = false;
        public override bool CloneNewInstances {
            get { return true; }
        }
        public override bool InstancePerEntity {
            get { return true; }
        }

        public OwnedItem() {
            if (Main.netMode == NetmodeID.SinglePlayer) fromPlayer = -1;
            else fromPlayer = -2;
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            var source = item.GetGlobalItem<OwnedItem>();
            var destination = itemClone.GetGlobalItem<OwnedItem>();
            if (source != null && destination != null) {
                destination.owned = source.owned;
                destination.FromPlayer = fromPlayer;
            }
            return destination;
        }

        public override void OnCraft(Item item, Recipe recipe) {
            owned = true;
        }

        public override void PostReforge(Item item) {
            owned = true;
        }

        public override bool OnPickup(Item item, Player player) {
            fromPlayer = player.whoAmI;
            owned = true;
            return true;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (item.GetGlobalItem<OwnedItem>().owned) return;
            SoulItem i = item.modItem as SoulItem;
            if (i == null) return;
            tooltips[0].text += " (" + i.SoulValue + " Souls required)";
        }

        public override void NetSend(Item item, System.IO.BinaryWriter writer) {
            writer.Write(fromPlayer);
        }

        public override void NetReceive(Item item, System.IO.BinaryReader reader) {
            fromPlayer = reader.ReadInt32();
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
            OwnedItem info = item.GetGlobalItem<OwnedItem>();
            return new TagCompound { { "owned", info.owned }, { "fromPlayer", fromPlayer } };
        }

        public override void Load(Item item, TagCompound tag) {
            owned = tag.GetBool("owned");
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