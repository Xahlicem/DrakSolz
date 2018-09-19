using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class CrystalLizardBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Crystal Lizard");
            Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.magicCrit += 1;
            player.thrownCrit += 1;
            player.meleeCrit += 1;
            player.rangedCrit += 1;
            player.minionDamage *= 1.01f;
            player.thrownDamage *= 1.01f;
            player.meleeDamage *= 1.01f;
            player.magicDamage *= 1.01f;
            player.rangedDamage *= 1.01f;
            player.manaCost *= 0.99f;
            player.wingTime += 60;
            player.wingTimeMax += 60;
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<DrakSolzPlayer>().CrystalPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("CrystalLizardPet")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("ExamplePet"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}