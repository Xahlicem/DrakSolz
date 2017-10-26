using Terraria;
using Terraria.Graphics.Shaders;

namespace DrakSolz.NPCs.Enemy.VoidPillar {
    public class VoidPillarData : ScreenShaderData {
        int VoidPillarTowerIndex;

        public VoidPillarData(string passName) : base(passName) { }

        void UpdatePuritySpiritIndex() {
            int VoidPillarTowerType = DrakSolz.instance.NPCType("VoidPillar");
            if (VoidPillarTowerIndex >= 0 && Main.npc[VoidPillarTowerIndex].active && Main.npc[VoidPillarTowerIndex].type == VoidPillarTowerType) {
                return;
            }
            VoidPillarTowerIndex = -1;
            for (int i = 0; i < Main.npc.Length; i++) {
                if (Main.npc[i].active && Main.npc[i].type == VoidPillarTowerType) {
                    VoidPillarTowerIndex = i;
                    break;
                }
            }
        }

        public override void Apply() {
            UpdatePuritySpiritIndex();
            if (VoidPillarTowerIndex != -1) {
                UseTargetPosition(Main.npc[VoidPillarTowerIndex].Center);
            }
            base.Apply();
        }
    }
}