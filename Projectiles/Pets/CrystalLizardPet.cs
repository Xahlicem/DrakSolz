using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Pets {
    public class CrystalLizardPet : ModProjectile {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Paper Airplane"); // Automatic from .lang files
            Main.projFrames[projectile.type] = 10;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.PetLizard);
            aiType = ProjectileID.PetLizard;
        }

        public override bool PreAI() {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false; // Relic from aiType
            return true;
        }

        public override void AI() {
            Player player = Main.player[projectile.owner];
            DrakSolzPlayer modPlayer = player.GetModPlayer<DrakSolzPlayer>();
            if (player.dead) {
                modPlayer.CrystalPet = false;
            }
            if (modPlayer.CrystalPet) {
                projectile.timeLeft = 2;
            }
        }
    }
}