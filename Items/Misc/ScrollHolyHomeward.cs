using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class ScrollHolyHomeward : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Homeward");
            Tooltip.SetDefault("Returns one to their place of belonging.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.MagicMirror);
            item.useStyle = 4;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 2;
            item.consumable = false;
        }

        public override bool UseItem(Player player) {
            for (int i = 0; i < 120; i++);
            player.Spawn();
            return true;
        }
    }
}