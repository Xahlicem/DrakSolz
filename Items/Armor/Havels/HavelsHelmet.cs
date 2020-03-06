using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Havels {
    [AutoloadEquip(EquipType.Head)]
    public class HavelsHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Habel's Helmet");
            Tooltip.SetDefault("Apparel worn by Habel the Rock.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = ItemRarityID.Gray;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player) {
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Havels.HavelsArmor>() && legs.type == ModContent.ItemType<Items.Armor.Havels.HavelsLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Can't Stop The Rock" +
                "\nDefensive powers increased");
            player.statDefense += 10;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.WaterWalking] = true;
            player.buffImmune[BuffID.Featherfall] = true;
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}