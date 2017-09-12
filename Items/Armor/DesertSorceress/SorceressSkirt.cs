using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Armor.DesertSorceress {
    [AutoloadEquip(EquipType.Legs)]
    public class SorceressSkirt : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Desert Sorceress Skirt");
            Tooltip.SetDefault("Armor forged with pure moonlight." +
                "\n+Water Walking" +
                "\n10% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 9;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed += 0.10f;
            player.waterWalk = true;
            //player.AddBuff(BuffID.WaterWalking, 2);
        }
        public class SorceressSkirtGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(10) == 0) {
                    if (npc.type == mod.NPCType("DesertSorceress")) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("SorceressSkirt"), 1);
                    }
                }
            }
        }
    }
}