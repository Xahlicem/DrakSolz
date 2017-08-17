using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs.Race

{

    public class Skeleton : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Skeleton");
            Description.SetDefault("Power of Skeletron!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            XahlicemPlayer modPlayer = player.GetModPlayer<XahlicemPlayer>();
            player.ignoreWater = true;
            player.breath = 100000;
            player.lifeRegenCount = 0;

        }
    }
}