using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class MoonS : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Scythe");
            Tooltip.SetDefault("Shoots a tiny eater!.");
        }
        public override void SetDefaults() {
            item.damage = 115;
            item.magic = true;
            item.mana = 20;
            item.width = 90;
            item.height = 90;
            item.useTime = 40;
            item.useAnimation = 40;
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