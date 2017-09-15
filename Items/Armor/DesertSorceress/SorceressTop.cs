using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.DesertSorceress {
    [AutoloadEquip(EquipType.Body)]
    public class SorceressTop : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Desert Sorceress Top");
            Tooltip.SetDefault("Armor forged with pure moonlight." +
                "\n+20 Max Health" +
                "\n+20 Max Mana");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 9;
            item.defense = 25;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 20;
            player.statLifeMax2 += 20;
        }
        public class SorceressTopGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(10) == 0) {
                    if (npc.type == mod.NPCType("DesertSorceress")) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("SorceressTop"), 1);
                    }
                }
            }
        }
    }
}