using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing {
    class BlackFireBomb : ModItem {

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Black Fire Bomb");
        }

        public override void SetDefaults() {
            item.useStyle = 1;
            item.damage = 100;
            item.thrown = true;
            item.shootSpeed = 12f;
            item.width = 28;
            item.height = 28;
            item.maxStack = 999;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Item.buyPrice(0, 0, 25, 0);
            item.rare = ItemRarityID.LightPurple;
            item.shoot = ModContent.ProjectileType<Projectiles.BlackFireBombProj>();
        }
    }
}