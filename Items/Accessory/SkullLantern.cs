using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class SkullLantern : SoulItem {
        public SkullLantern() : base(1500) { }

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
            item.useTurn = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.AddBuff(BuffID.Warmth, 2);
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ItemID.Torch, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.HomewardBone>(), 2);
            recipe.AddRecipe();
        }

        public override void UseStyle(Player player) {
            player.itemLocation.Y += 20;
            player.itemLocation.X += player.direction == 1 ? -10 : 10;
        }

        public override bool UseItem(Player player) {
            float offset = player.direction == 1 ? 11 : -11;
            for (int i = 0; i < 10; i++) {
                int dustIndex = Dust.NewDust(new Vector2(player.position.X + offset, player.position.Y + 20), item.width, item.height, 6, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale *= 0.6f;
                dustIndex = Dust.NewDust(new Vector2(player.position.X + offset, player.position.Y + 20), item.width, item.height, 6, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dustIndex].velocity *= 0.5f;
                Main.dust[dustIndex].scale *= 0.6f;
            }
            return true;
        }
    }
}