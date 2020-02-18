using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingPriestess : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Priestess Ring");
            Tooltip.SetDefault("Increased life regeneration");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.lifeRegen += 2;

            int index = player.FindBuffIndex(ModContent.BuffType<Buffs.Hollow>());
            if (index != -1) player.buffTime[index]--;
        }
    }

    public class RingPriestessDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Paladin && Main.rand.Next(10) == 0)
                Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Accessory.RingPriestess>());
        }
    }
}