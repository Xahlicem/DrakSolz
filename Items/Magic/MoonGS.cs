using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class MoonGS : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Greatsword");
            Tooltip.SetDefault("Shoots a tiny eater!.");
        }
        public override void SetDefaults() {
            item.damage = 80;
            item.magic = true;
            item.mana = 18;
            item.width = 90;
            item.height = 90;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 1;
            item.noMelee = false; //so the item's animation doesn't do damage
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("MGSProj");
            item.shootSpeed = 12f;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-50, -15);
        }
    }
}