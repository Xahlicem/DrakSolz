namespace DrakSolz.Items.Misc.Classes {
    public class ClassBulwark : ClassItem {
        protected override string TEXT { get { return "A Bulwark"; } }
        protected override int STR { get { return 0; } }
        protected override int DEX { get { return 0; } }
        protected override int INT { get { return 0; } }
        protected override int FTH { get { return 0; } }
        protected override int VIT { get { return 10; } }
        protected override int ATT { get { return 0; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bulwark Rune");
            Tooltip.SetDefault("Consume to focus on vitality and defense.");
        }
    }
}