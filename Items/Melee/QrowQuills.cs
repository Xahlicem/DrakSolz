using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class QrowQuills : SoulItem {
        public QrowQuills() : base(200000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Qrow Quills");
            Tooltip.SetDefault("Sword wielded by Corvian Knights, brandishing four thin-edge blades in the left hand." + 
            "\nPrimary attack deals melee damage." + 
            "\nAlternate attack deals 20% increased throwing damage.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Arkhalis);
            item.damage = 110;
            item.width = 28;
            item.height = 28;
            //item.knockBack = 0;
            item.value = Item.sellPrice(0, 0, 2, 50);
            item.rare = ItemRarityID.Green;
        }
        public override bool AltFunctionUse(Player player) {
            item.useStyle = 1;
            item.useAnimation = 16;
            item.useTime = 4;
            item.reuseDelay = 30;
            /*item.melee = false;
            item.thrown = true;*/
            return true;
        }

        public override bool UseItem(Player player) {
            if (player.altFunctionUse == 2) {
                item.melee = false;
                item.thrown = true;
            } else {
                item.thrown = false;
                item.melee = true;
            }
            return base.UseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.altFunctionUse == 2) {
                item.thrown = true;
                item.melee = false;
                float numberProjectiles = 1;
                float d = player.thrownDamage * 10;
                if (item.thrown) {
                    for (int i = 0; i < numberProjectiles; i++) {
                        damage = (item.damage * (int)d) /10;
                        int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.QrowQuillsProj>(), damage, knockBack / 2, player.whoAmI);
                    }
                }
                return false;
            } else {
                float numberProjectiles = 1;
                item.melee = true;
                item.thrown = false;
                float d = player.meleeDamage * 10;
                if (item.melee) {
                    for (int i = 0; i < numberProjectiles; i++) {
                        damage = (item.damage * (int)d) /10;
                        int pro = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                        Main.projectile[pro].scale *= 2;
                        Main.projectile[pro].height = 75;
                        Main.projectile[pro].width = 90;
                    }
                }
                return false;

            }
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ItemID.Arkhalis, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.VoidFragment>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}