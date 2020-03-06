using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollImmolation : SoulItem {
        public PyroScrollImmolation() : base(20000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Immolation");
            Tooltip.SetDefault("Engulfs self in flames that burn nearby foes.");
        }

        public override void SetDefaults() {
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 20;
        }

        public override bool UseItem(Player player) {
            player.AddBuff(BuffID.Inferno, 900);
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.PyroScroll>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}