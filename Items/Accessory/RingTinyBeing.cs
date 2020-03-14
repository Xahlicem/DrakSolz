using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingTinyBeing : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Tiny Being's Ring");
            Tooltip.SetDefault("Increases maximum life by 50");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<DrakSolzPlayer>().MiscHP += 50;
        }
    }

    public class RingTinyBeingDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Pinky && Main.rand.Next(1) == 0)
                Item.NewItem(npc.position, npc.width, npc.height, ModContent.ItemType<Items.Accessory.RingTinyBeing>());
        }
    }
}