using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class AridBlade : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arid Blade");
            Tooltip.SetDefault("Arid Blades roam the desert seeking great challenge.");
        }
        public override void SetDefaults() {
            item.useStyle = 1;
            item.scale *= 1;
            item.melee = true;
            item.damage = 1700;
            item.useTime = 27;
            item.useAnimation = 27;
            item.rare = 4;
            item.knockBack = 7f;
            item.shootSpeed = 12f;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.autoReuse = true;
            item.shoot = ProjectileID.SwordBeam;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            damage = (int) item.damage / 4;
            knockBack = 1;
            float numberProjectiles = 4;
            float rotation = MathHelper.ToRadians(20);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
            for (int i = 0; i < numberProjectiles; i++) {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 0.8f; // Watch out for dividing by 0 if there is only 1 projectile.
                int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[pro].timeLeft = 30;
            }
            return false;
        }

        public class AridBladeGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(25) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Desert.AridBlade>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Melee.AridBlade>(), 1);
                    }
                }
            }
        }
    }
}