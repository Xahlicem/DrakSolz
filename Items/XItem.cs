using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace XahlicemMod.Items {
    public class XItem : GlobalItem {
        public bool owned = false;
        public override bool CloneNewInstances {
            get { return true; }
        }
        public override bool InstancePerEntity {
            get { return true; }
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            var source = item.GetGlobalItem<XItem>();
            var destination = itemClone.GetGlobalItem<XItem>();
            if (source != null && destination != null) destination.owned = source.owned;
            return destination;
        }

        public override void OnCraft(Item item, Recipe recipe) {
            owned = true;
        }
        public override void PostReforge(Item item) {
            owned = true;
        }
        public override bool OnPickup(Item item, Player player) {
            owned = true;
            return true;
        }

        public override void ModifyTooltips(Item item, System.Collections.Generic.List<TooltipLine> tooltips) {
            if (item.GetGlobalItem<XItem>().owned) return;
            SoulItem i = item.modItem as SoulItem;
            if (i == null) return;
            tooltips[0].text += " (" + i.SoulValue + " Souls required)";
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
            XItem info = item.GetGlobalItem<XItem>();
            return new TagCompound { { "Xowned", info.owned } };
        }

        public override void Load(Item item, TagCompound tag) {
            owned = tag.GetBool("Xowned");
        }
    }

    public class SoulItem : ModItem {
        public int SoulValue { get; set; }

        public override bool CloneNewInstances { get { return true; } }

        public override ModItem Clone() {
            SoulItem clone = base.Clone() as SoulItem;
            clone.SoulValue = this.SoulValue;
            return clone;
        }
    }

    public class SoulRecipe : ModRecipe {
        private int requiredSouls;
        public SoulRecipe(Mod mod, SoulItem result) : base(mod) {
            requiredSouls = result.SoulValue;
            SetResult(result);
        }

        public override bool RecipeAvailable() {
            return (Main.LocalPlayer.GetModPlayer<XahlicemPlayer>().Souls >= requiredSouls);
        }

        public override void OnCraft(Item item) {
            Main.LocalPlayer.GetModPlayer<XahlicemPlayer>().Souls -= requiredSouls;
        }
    }
}