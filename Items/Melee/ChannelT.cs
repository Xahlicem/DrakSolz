using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class ChannelT : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Channeler's Trident");
            Tooltip.SetDefault("A unique trident which spins around when thrust.");
        }

        public override void SetDefaults() {
            item.damage = 25;
            item.useStyle = 5;
            item.useAnimation = 30;
            item.useTime = 35;
            item.shootSpeed = 3.4f;
            item.knockBack = 4f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<Projectiles.ChannelTProj>();
            item.value = 1000;
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