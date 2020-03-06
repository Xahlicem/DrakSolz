using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroScrollFlameWeapon : SoulItem {
        public PyroScrollFlameWeapon() : base(15000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("FlameWeapon");
            Tooltip.SetDefault("Weapons burn foes.");
        }

        public override void SetDefaults() {
            item.scale *= 0.8f;
            item.useStyle = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.consumable = false;
            item.noUseGraphic = true;
            item.mana = 20;
        }

        public override bool UseItem(Player player) {
            player.AddBuff(BuffID.WeaponImbueFire, 1200);
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