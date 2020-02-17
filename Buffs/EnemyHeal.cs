using Terraria;
using Terraria.ModLoader;
using DrakSolz.NPCs;

namespace DrakSolz.Buffs {
    public class EnemyHeal : ModBuff {
        public override void SetDefaults()
		{
			DisplayName.SetDefault("Healing");
			Description.SetDefault("Restoring life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<DSGlobalNPC>().Healp = true;
		}
	}
}