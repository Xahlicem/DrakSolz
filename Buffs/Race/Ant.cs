using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs.Race

{

    public class Ant : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Ant");
            Description.SetDefault("Power of dirt!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            XahlicemPlayer modPlayer = player.GetModPlayer<XahlicemPlayer>();
                    player.pickSpeed *= 0.75f;
                    player.maxRunSpeed += 1;
                    player.spikedBoots = 2;
        }
    }
}