using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CrystalPet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mysterious Crystal");
            Tooltip.SetDefault("Something is attracted to this...");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = mod.ProjectileType("CrystalLizardPet");
            item.buffType = mod.BuffType("CrystalLizardBuff");
        }

        public override void UseStyle(Player player) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}