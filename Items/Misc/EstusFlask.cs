using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class EstusFlask : ModItem {
        public int Place { get; internal set; }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Estus Flask");
            Tooltip.SetDefault("Restores life and reduces hollowing.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.HealingPotion);
            item.width = refItem.width;
            item.height = refItem.height;
            item.useStyle = 2;
            item.UseSound = refItem.UseSound;
            item.useAnimation = 150;
            item.useTime = 150;
            item.maxStack = 10;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.consumable = true;
            item.lavaWet = true;
        }

        public override bool CanUseItem(Player player) {
            if (player.HasBuff(BuffID.PotionSickness)) return false;
            else {
                return true;
            }
        }
        public override bool UseItem(Player player) {
            player.AddBuff(BuffID.PotionSickness, 300);
            player.AddBuff(ModContent.BuffType<Buffs.EstusHeal>(), 155);

            int index = player.FindBuffIndex(ModContent.BuffType<Buffs.Hollow>());
            player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(1800);
            if (NPC.downedSlimeKing) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (NPC.downedBoss1) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (NPC.downedBoss2) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (NPC.downedBoss3) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (Main.hardMode) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (NPC.downedMechBossAny) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (NPC.downedPlantBoss) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (NPC.downedGolemBoss) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (NPC.downedAncientCultist) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            if (NPC.downedMoonlord) {
                player.GetModPlayer<DrakSolzPlayer>().DecreaseHollow(900);
            }
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
            modPlayer.Estus += 1;
            if (item.stack < 2) {
                item.stack = 2;
                foreach (Item i in player.inventory) {
                    if (i == item) {
                        i.netDefaults(ModContent.ItemType<Items.Misc.EmptyFlask>());
                    }
                }
            }
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.EstusShard>(), 1);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}