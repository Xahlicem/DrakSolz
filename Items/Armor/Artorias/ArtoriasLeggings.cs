using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Artorias {
    [AutoloadEquip(EquipType.Legs)]
    public class ArtoriasLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arter Rias Leggings");
            Tooltip.SetDefault("Apparel.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = ItemRarityID.Red;
            item.defense = 40;
        }

        public override void UpdateEquip(Player player) {
        }
        public override bool DrawLegs() {
            return false;
        }
        public class ArtoriasLeggingsGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (npc.type == ModContent.NPCType<NPCs.Enemy.Boss.AbyssStalker>()) {
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.Artorias.ArtoriasLeggings>(), 1);
                }
            }
        }
    }
}