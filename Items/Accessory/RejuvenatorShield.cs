using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    
	[AutoloadEquip(EquipType.Shield)]
    public class RejuvenatorShield : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rejuvenator's Shield");
            Tooltip.SetDefault("Increased defense and estus flask recovery");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.defense = 10;
            item.value = Item.buyPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().EstusHealth += 2;
        }
        public class RejuvenatorShieldGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(10) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Dungeon.Rejuvenator>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Accessory.RejuvenatorShield>(), 1);
                    }
                }
            }
        }
    }
}