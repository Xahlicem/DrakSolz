using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon.Consumable {
    class XahlicemEye : ModItem {

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Eye of Xahlicem");
            Tooltip.SetDefault("Alternately used as a powerful summon...");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.CrystalSerpent);
            item.width = 20;
            item.height = 20;
            item.mana = 15;
            item.damage = 1800;
            item.useAnimation = 19;
            item.useTime = 19;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.knockBack = 8f;
            item.rare = ItemRarityID.Red;
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(12, 0);
        }
        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            return (fromPlayer == -1) ? true : (player.whoAmI == fromPlayer);
        }

        public override void GrabRange(Player player, ref int grabRange) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            if (fromPlayer != player.whoAmI) return;
            grabRange = (int) player.Distance(item.Center);
        }

        public override bool AltFunctionUse(Player player) {
            item.magic = false;
            item.summon = true;
            item.consumable = true;
            item.damage = 1200;
            item.shoot = ModContent.ProjectileType<Projectiles.Minion.Consumable.XahlicemEyeProj>();
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.altFunctionUse == 2) {
                speedY = 10;
                speedX *= 0.001f;
            } else {

                item.damage = 180;
                item.magic = true;
                item.summon = false;
            }
            return true;
        }
        		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TitaniteSoul", 1);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
    }
}