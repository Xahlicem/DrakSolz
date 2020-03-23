using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class EstusFlask : ModItem {
        public bool Owner { get; internal set; }

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
            item.GetGlobalItem<DSGlobalItem>().Restricted = true;
        }
        public override bool CanUseItem(Player player){
            if (player.HasBuff(BuffID.PotionSickness)){
                return false;
            }
            else {return true;}
        }

        public override bool UseItem(Player player) {
            player.AddBuff(BuffID.PotionSickness, 154);
            player.AddBuff(ModContent.BuffType<Buffs.EstusHeal>(), 155);
            return true;
        }
        public override bool ConsumeItem(Player player){
            return false;
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