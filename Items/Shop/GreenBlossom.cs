using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace XahlicemMod.Items.Shop
{
public class GreenBlossom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Blossom");
            Tooltip.SetDefault("Stamina Boosting Plant");
        }

        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Mushroom);
            item.width = refItem.width;
            item.height = refItem.height;
            item.useStyle = refItem.useStyle;
            item.UseSound = refItem.UseSound;
            item.useAnimation = 20;
            item.useTime = 20;
            item.maxStack = 99;
            item.value = Item.buyPrice(0, 0, 3, 0);
            item.rare = 0;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.Panic, 3600);
            //player.AddBuff(mod.BuffType("Undead2"), 2);

            return true;
        }

        public class GreenBlossomGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(2) == 0)
                {
                    if (npc.type == NPCID.Zombie)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GreenBlossom"), 1);

                    }
                }
            }
        }

    }
}