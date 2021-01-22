using Terraria.ID;

namespace DrakSolz.Items.Misc.Classes {
    public class ClassAll : ClassItem {
        protected override string TEXT { get { return "An Adept"; } }
        protected override int STR { get { return 2; } }
        protected override int DEX { get { return 2; } }
        protected override int INT { get { return 2; } }
        protected override int FTH { get { return 2; } }
        protected override int VIT { get { return 1; } }
        protected override int ATT { get { return 1; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Adept Rune");
            Tooltip.SetDefault("Consume to focus on balance.");
        }

        public override bool ConsumeItem(Terraria.Player player) {
            //player.QuickSpawnItem()
            player.QuickSpawnItem(ItemID.GoldCoin);
            return true;
        }
    }
}