using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Buffs {
    public class AbyssSwordBuff : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Abyss Sword");
            Description.SetDefault("Conjured sword will fade away soon.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
            Main.persistentBuff[Type] = true;
            canBeCleared = true;
        }
    }
}