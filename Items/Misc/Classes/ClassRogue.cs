using Terraria.ModLoader;

namespace DrakSolz.Items.Misc.Classes {
    public class ClassRogue: ClassItem {
        protected override string TEXT { get { return "A Rogue"; } }
        protected override int STR { get { return 0; } }
        protected override int DEX { get { return 10; } }
        protected override int INT { get { return 0; } }
        protected override int FTH { get { return 0; } }
        protected override int VIT { get { return 0; } }
        protected override int ATT { get { return 0; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rogue Rune");
            Tooltip.SetDefault("Consume to focus on dexterity.");
        }

        public override bool ConsumeItem(Terraria.Player player) {
            //player.QuickSpawnItem()
            player.QuickSpawnItem(ModContent.ItemType<Items.Ranged.Slingshot>());
            player.QuickSpawnItem(ModContent.ItemType<Items.Ranged.SlingshotStones>(), 100);
            return true;
        }
    }
}