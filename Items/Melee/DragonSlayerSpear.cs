using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class DragonSlayerSpear : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dragonslayer Spear");
            Tooltip.SetDefault("The spear of the knight known as the Dragonslayer was imbued the power, and shattered the stone scales of dragons.");
        }

        public override void SetDefaults() {
            item.damage = 60;
            item.useStyle = 5;
            item.useAnimation = 22;
            item.useTime = 27;
            item.shootSpeed = 4.4f;
            item.knockBack = 4.5f;
            item.width = 28;
            item.height = 28;
            item.scale = 1f;
            item.rare = 6;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<Projectiles.DragonSlayerSpearProj>();
            item.value = 300000;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}