using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic.Pyro {
    public class PyroTorch : SoulItem {
        public PyroTorch() : base(4000) { }

        public override void SetStaticDefaults () {
            DisplayName.SetDefault ("Heavy Torch");
            Tooltip.SetDefault ("A heavier torch design, sturdy enough to bludgeon foes." +
                "\nCan be held out to produce great light, but can't be mounted on walls.");
        }
        public bool ftorch = true;

        public override void SetDefaults () {
            item.CloneDefaults (ItemID.BreakerBlade);
            item.melee = false;
            item.damage = 16;
            item.scale *= 1.5f;
            item.width = 28;
            item.height = 28;
            item.useTime = 24;
            item.useAnimation = 24;
            item.knockBack = 6;
            item.value = Item.sellPrice (0, 0, 50, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item10;
            item.shoot = ModContent.ProjectileType<Projectiles.TorchProj> ();
            item.shootSpeed = 0.5f;
        }
        public override bool CanUseItem (Player player) {
            if (Main.expertMode && player.wet) {
                ftorch = false;
            } else if (player.breath < player.breathMax) {
                ftorch = false;
            } else {
                ftorch = true;
            }
            return true;
        }

        public override bool AltFunctionUse (Player player) {
            /*item.melee = false;
            item.thrown = true;*/
            item.useStyle = 4;
            item.useAnimation = 32;
            item.useTime = 4;
            item.reuseDelay = 15;
            item.noMelee = true;
            return true;
        }

        public override bool UseItem (Player player) {
            if (player.altFunctionUse == 2) {
                item.useStyle = 4;
                item.useAnimation = 32;
                item.useTime = 4;
                item.reuseDelay = 15;
                item.noMelee = true;
            } else {
                item.useStyle = 1;
                item.useAnimation = 24;
                item.useTime = 30;
                item.reuseDelay = 35;
                item.noMelee = false;
            }
            return base.UseItem (player);

        }

        public override bool Shoot (Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.altFunctionUse == 2) {
                item.useStyle = 4;
                item.useAnimation = 32;
                item.useTime = 4;
                item.reuseDelay = 15;
                item.noMelee = true;
                position = new Vector2 ((player.Center.X) + (24 * player.direction), player.Center.Y - 25);
                speedY = -1;
                knockBack = 0f;
                damage = damage / 4;
                if (ftorch) {
                    int pro = Projectile.NewProjectile (position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                    Main.projectile[pro].timeLeft = 20;
                }
                return false;
            } else {
                item.useStyle = 1;
                item.useAnimation = 24;
                item.useTime = 30;
                item.reuseDelay = 35;
                item.noMelee = false;
                return false;

            }
        }
        public override void MeleeEffects (Player player, Rectangle hitbox) {
            if (ftorch) {
                if (player.altFunctionUse != 2) {
                    if (Main.rand.Next (1) == 0) {
                        //Emit dusts when swing the sword
                        int dust = Dust.NewDust (new Vector2 (hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
                        Main.dust[dust].scale *= 1f + Main.rand.NextFloat ();
                        Main.dust[dust].noGravity = true;
                    }
                }
            }
        }
        public override void OnHitNPC (Player player, NPC target, int damage, float knockback, bool crit) {
            if (ftorch) {
                target.AddBuff (BuffID.OnFire, 90);
            }
        }

        public override void AddRecipes () {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient (ItemID.Wood, 20);
            recipe.AddIngredient (ModContent.ItemType<Items.Magic.Pyro.PyroScrollCombustion> (), 1);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe ();
        }
    }
}