using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace DrakSolz.Items.Misc {
    class PrismStone : ModItem {
        // TODO, count as explosive for demolitionist spawn

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Prism Stone");
        }

        public override void SetDefaults() {
            item.useStyle = 1;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("PrismStoneProj");
            item.width = 8;
            item.height = 28;
            item.maxStack = 30;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 40;
            item.useTime = 40;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.value = Item.buyPrice(0, 0, 0, 50);
            item.rare = 1;
        }
    }
}