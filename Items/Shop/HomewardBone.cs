using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace XahlicemMod.Items.Shop
{
    public class HomewardBone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Homeward Bone");
            Tooltip.SetDefault("Returns one to their place of belonging.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.RecallPotion);
            item.useTime = 120;
            item.useStyle = 4;
            item.maxStack = 99;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.rare = 2;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            for (int i = 0; i < 60; i++) ;
                player.Spawn();
                return true; 
        }
    }
}