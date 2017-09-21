using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class BoneWheel : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bone Wheel");
            Tooltip.SetDefault("Used by Wheel Skeletons as a means of transportation. Are you going to ride it or something?");
        }

        public override void SetDefaults() {
			item.useStyle = 5;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 35f;
			item.channel = true;
            item.damage = 25;
            item.shootSpeed = 3.4f;
            item.knockBack = 4f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<Projectiles.BoneWheelProj>();
            item.value = 1000;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.thrown = true;
            item.autoReuse = true;
        }
    }
}