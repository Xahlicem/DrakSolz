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

    public class ManaHealth : GlobalItem {
        public override bool CanUseItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit || item.type == ItemID.ManaCrystal) return true;
            else return base.ConsumeItem(item, player);
        }

        public override void ModifyTooltips(Item item, System.Collections.Generic.List<TooltipLine> tooltips) {
            if (item.type == ItemID.LifeCrystal) {
                tooltips[tooltips.Capacity - 1].text = "Makes you whole and increases life regeneration for 5 minutes";
            }
            if (item.type == ItemID.LifeFruit) {
                tooltips[tooltips.Capacity - 2].text = "Makes you whole and increases life regeneration for 1 minute";
            }
            if (item.type == ItemID.ManaCrystal) {
                tooltips[tooltips.Capacity - 2].text = "Increases mana regeneration and magic damage for 1 minute";
            }
        }

        public override bool ConsumeItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit) {
                player.AddBuff(BuffID.Regeneration, 60 * 60 * ((item.type == ItemID.LifeCrystal)?5:1));

                int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
                if (index != -1) player.buffTime[index] = 0;
            }
            if (item.type == ItemID.ManaCrystal) {
                player.AddBuff(BuffID.ManaRegeneration, 60 * 60 * 1);
                player.AddBuff(BuffID.MagicPower, 60 * 60 * 1);
            }
            return base.ConsumeItem(item, player);
        }

        public override bool UseItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit) {
                player.AddBuff(BuffID.Regeneration, 60 * 60 * ((item.type == ItemID.LifeCrystal)?5:1));

                int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
                if (index != -1) player.buffTime[index] = 0;
                return true;
            }
            if (item.type == ItemID.ManaCrystal) {
                player.AddBuff(BuffID.ManaRegeneration, 60 * 60 * 1);
                player.AddBuff(BuffID.MagicPower, 60 * 60 * 1);
                return true;
            }
            return base.ConsumeItem(item, player);
        }
    }
}