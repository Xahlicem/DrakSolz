using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon.Consumable {
    class PossesedArmorHelmet : CMinionItem {
        public PossesedArmorHelmet() : base(5000, "PossesedArmor") { }

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Possesed Armor Helmet");
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.width = 20;
            item.height = 20;
            item.mana = 20;
            item.damage = 40;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.knockBack = 8f;
            item.rare = 5;
            item.shoot = mod.ProjectileType<Projectiles.Minion.Consumable.PossesedArmorHelmetProj>();
        }

        public override void AddRecipes() {
            SoulRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            //recipe.AddIngredient(ItemID.Bone, 50);
            //recipe.AddRecipe();
        }
    }
}