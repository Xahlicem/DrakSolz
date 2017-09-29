using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class RingPriestess : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Priestess Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n+Life Regen");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.lifeRegen += 2;

            int index = player.FindBuffIndex(mod.BuffType<Buffs.Hollow>());
            if (index != -1) player.buffTime[index]--;
        }
    }

    public class RingPriestessDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Paladin && Main.rand.Next(10) == 0)
                Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Accessory.RingPriestess>());
        }
    }
}