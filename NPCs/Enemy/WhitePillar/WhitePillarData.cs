using Terraria;
using Terraria.Graphics.Shaders;

namespace DrakSolz.NPCs.Enemy.WhitePillar
{
	public class WhitePillarData : ScreenShaderData
	{
		int WhitePillarTowerIndex;

		public WhitePillarData(string passName) : base(passName) { }

		void UpdatePuritySpiritIndex()
		{
			int WhitePillarTowerType = DrakSolz.instance.NPCType("WhitePillar");
			if (WhitePillarTowerIndex >= 0 && Main.npc[WhitePillarTowerIndex].active && Main.npc[WhitePillarTowerIndex].type == WhitePillarTowerType)
			{
				return;
			}
			WhitePillarTowerIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == WhitePillarTowerType)
				{
					WhitePillarTowerIndex = i;
					break;
				}
			}
		}

		public override void Apply()
		{
			UpdatePuritySpiritIndex();
			if (WhitePillarTowerIndex != -1)
			{
				UseTargetPosition(Main.npc[WhitePillarTowerIndex].Center);
			}
			base.Apply();
		}
	}
}