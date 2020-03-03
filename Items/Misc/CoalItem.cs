using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public abstract class CoalItem : ModItem {
        public const byte COAL_RED = 1<<0;
        public const byte COAL_WHITE = 1<<1;
        public const byte COAL_YELLOW = 1<<2;
        public const byte COAL_BLUE = 1<<3;
        public const byte COAL_LORD = 1<<4;
        private int price;
        private int rare;
        public byte Place { get; internal set; }
        public CoalItem(byte place, int rare, int price) {
            Place = place;
            this.price = price;
            this.rare = rare;
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = price;
            item.rare = rare;
        }
    }
    class CoalItemDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Spinwheel>() && Main.rand.Next(10) == 0) Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<CoalRed>(), 1);
            if (npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Channeler>() && Main.rand.Next(10) == 0) Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<CoalWhite>(), 1);
            if (npc.type == ModContent.NPCType<NPCs.Enemy.HardMode.DragonSlayer>() && Main.rand.Next(3) == 0) Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<CoalYellow>(), 1);
            if (npc.type == ModContent.NPCType<NPCs.Enemy.PostPlantera.GiantCrystalLizard>() && Main.rand.Next(2) == 0) Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<CoalBlue>(), 1);
            if (npc.type == ModContent.NPCType<NPCs.Enemy.Boss.TitaniteDemon>()) Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<CoalLord>(), 1);
        }
    }
}