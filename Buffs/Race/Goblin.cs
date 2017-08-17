using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs.Race

{

    public class Goblin : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Goblin");
            Description.SetDefault("Power of Moria!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            XahlicemPlayer modPlayer = player.GetModPlayer<XahlicemPlayer>();
            player.rangedDamage *= 1.25f;
        }
    }
}