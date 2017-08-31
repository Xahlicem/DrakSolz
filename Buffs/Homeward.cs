using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace XahlicemMod.Buffs

{

    public class Homeward : ModBuff {
        public override void SetDefaults() {
            DisplayName.SetDefault("Homeward");
            Description.SetDefault("Home sweet home");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.moveSpeed = 0;
            player.maxRunSpeed = 0;
            player.accRunSpeed = 0;
            if (player.buffTime[buffIndex] == 1)
                if (player.SpawnX != -1 && player.SpawnY != -1) player.Teleport(new Vector2(player.SpawnX << 4, player.SpawnY << 4));
        }
    }
}