using Terraria;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingRedTear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Red Tearstone Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+25% Damage when near death");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            int life = 0;
            if (player.statLifeMax2 <= 20) life = 15;
            else if (player.statLifeMax2 <= 100) life = 20;
            else life = (int)(player.statLifeMax2 * 0.2f);

            if (player.statLife <= life) {
                player.meleeDamage += 0.25f;
                player.magicDamage += 0.25f;
                player.thrownDamage += 0.25f;
                player.rangedDamage += 0.25f;
                player.minionDamage += 0.25f;
            }
        }
    }
}