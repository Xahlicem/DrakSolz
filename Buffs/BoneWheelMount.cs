using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class BoneWheelMount : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Bone Wheel");
            Description.SetDefault("You spin me right round baby!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<DrakSolzPlayer>().Rotate = true;
            player.mount.SetMount(mod.MountType<Mounts.BoneWheel>(), player);
            player.buffTime[buffIndex] = 10;
            player.slippy = true;

            if (player.ownedProjectileCounts[mod.ProjectileType<Projectiles.BoneWheelProj>()] == 0) {
                Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType<Projectiles.BoneWheelProj>(), 10, 0.5f, player.whoAmI, 1);
                Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType<Projectiles.BoneWheelProj>(), 10, 0.5f, player.whoAmI, -1);
            }
        }
    }
}