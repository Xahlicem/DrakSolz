using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing {
    class FireBomb : ModItem {

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Fire Bomb");
        }

        public override void SetDefaults() {
            item.useStyle = 1;
            item.damage = 55;
            item.thrown = true;
            item.shootSpeed = 12f;
            item.width = 28;
            item.height = 28;
            item.maxStack = 999;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 25;
            item.useTime = 25;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.rare = 5;
            item.shoot = mod.ProjectileType<Projectiles.FireBombProj>();
        }
    }
}