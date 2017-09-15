using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class MoonK : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Katana");
            Tooltip.SetDefault("Shoots a tiny eater!.");
        }
        public override void SetDefaults() {
            item.damage = 60;
            item.magic = true;
            item.mana = 10;
            item.width = 90;
            item.height = 90;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.noMelee = false; //so the item's animation doesn't do damage
            item.knockBack = 0;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(-50, -15);
        }
    }
}