using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Throwing {
    public class VorpalDagger : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Vorpal Dagger");
            Tooltip.SetDefault("???");
        }

        public override void SetDefaults() {
            item.damage = 1200;
            item.thrown = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.noUseGraphic = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType<Projectiles.VorpalDaggerProj>();
            item.shootSpeed = 8f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
                position += muzzleOffset;
            }
            int numberProjectiles = 5 + Main.rand.Next(3); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++) {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public class VorpalDaggerGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == mod.NPCType<NPCs.Enemy.Endgame.Corrupt.VorpalReaver>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Throwing.VorpalDagger>(), 1);
                    }
                }
            }
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddIngredient(ItemID.Solidifier, 1);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.SetResult(ItemID.SlimeStaff);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}