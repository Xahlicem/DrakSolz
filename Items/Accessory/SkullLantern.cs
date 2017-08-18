using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class SkullLantern : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skull Lantern");
            Tooltip.SetDefault("Gives off light.");
        }

        public override void SetDefaults() {
            item.useStyle = 4;
            item.useTime = 5;
            item.useAnimation = 5;
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 2;
            item.accessory = true;
            item.autoReuse = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.AddBuff(BuffID.Warmth, 2);
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Soul"), 1500);
            recipe.AddIngredient(ItemID.Torch, 10);
            recipe.AddIngredient(mod.ItemType("HomewardBone"), 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool UseItem(Player player) {
            float offset = player.direction == 1 ? 21 : -21;
            for (int i = 0; i < 10; i++)

            {

                int dustIndex = Dust.NewDust(new Vector2(player.position.X + offset, player.position.Y), item.width, item.height, 6, 0f, 0f, 100, default(Color), 2f);

                Main.dust[dustIndex].noGravity = true;

                Main.dust[dustIndex].scale *= 0.6f;

                dustIndex = Dust.NewDust(new Vector2(player.position.X + offset, player.position.Y), item.width, item.height, 6, 0f, 0f, 100, default(Color), 1f);

                Main.dust[dustIndex].velocity *= 0.5f;

                Main.dust[dustIndex].scale *= 0.6f;

            }
            return true;
        }
    }
}