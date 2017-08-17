using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs.Race

{

    public class LizardMan : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("LizardMan");
            Description.SetDefault("Power of cold blooded!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            XahlicemPlayer modPlayer = player.GetModPlayer<XahlicemPlayer>();
            player.thrownVelocity *= 0.5f;
            player.statLifeMax2 = (int)(player.statLifeMax2 * 1.2);
            player.lifeRegenTime = 2;
            player.lifeRegen += player.statLifeMax2 / 50;
            if (Main.time % 12 == 0) player.breath += 1;

            if (Main.dayTime) {
                player.moveSpeed *= 1.25f;
                player.maxRunSpeed *= 1.25f;
                player.accRunSpeed *= 1.25f;
            } else {
                    player.moveSpeed *= 0.75f;
                    player.maxRunSpeed *= 0.75f;
                    player.accRunSpeed = 0;
            }
            
        }
    }
}