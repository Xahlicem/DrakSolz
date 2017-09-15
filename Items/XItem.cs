using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items {
    public class XItem : GlobalItem {
        internal int fromPlayer;
        public int FromPlayer { get { return fromPlayer; } set { fromPlayer = value; } }

        public bool owned = false;
        public override bool CloneNewInstances {
            get { return true; }
        }
        public override bool InstancePerEntity {
            get { return true; }
        }

        public XItem() {
            if (Main.netMode == NetmodeID.SinglePlayer) fromPlayer = -1;
            else fromPlayer = -2;
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            var source = item.GetGlobalItem<XItem>();
            var destination = itemClone.GetGlobalItem<XItem>();
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
            if (item.GetGlobalItem<XItem>().owned) return;
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
            XItem info = item.GetGlobalItem<XItem>();
            return new TagCompound { { "Xowned", info.owned }, { "XfromPlayer", fromPlayer } };
        }

        public override void Load(Item item, TagCompound tag) {
            owned = tag.GetBool("Xowned");
            fromPlayer = tag.GetInt("XfromPlayer");
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
            return (Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().Souls >= requiredSouls);
        }

        public override void OnCraft(Item item) {
            Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().Souls -= requiredSouls;
        }
    }

    public class ManaHealth : GlobalItem {
        public override bool CanUseItem(Item item, Player player) {
            if (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit || item.type == ItemID.ManaCrystal) return true;
            else return base.ConsumeItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (tooltips.Capacity < 2) return;
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
                player.AddBuff(BuffID.Regeneration, 60 * 60 * ((item.type == ItemID.LifeCrystal) ? 5 : 1));

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
                player.AddBuff(BuffID.Regeneration, 60 * 60 * ((item.type == ItemID.LifeCrystal) ? 5 : 1));

                int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
                if (index != -1) player.buffTime[index] = 0;
                return true;
            }
            if (item.type == ItemID.ManaCrystal) {
                player.AddBuff(BuffID.ManaRegeneration, 60 * 60 * 1);
                player.AddBuff(BuffID.MagicPower, 60 * 60 * 1);
                return true;
            }
            return base.UseItem(item, player);
        }
    }

    public class SummonMod : GlobalItem {
        public override void SetDefaults(Item item) {
            if (item.type == ItemID.SlimeStaff) {
                item.mana *= 1;

            }
        }
    }

    public class MeleeThrow : GlobalItem {

        public override void SetDefaults(Item item) {
            if (item == null || item.type >= ItemID.Sets.Yoyo.Length || DrakSolz.ListMeleeThrow == null) return;
            if (ItemID.Sets.Yoyo[item.type] || DrakSolz.ListMeleeThrow.Contains(item.type)) {
                item.melee = false;
                item.thrown = true;
            }
        }
    }
}