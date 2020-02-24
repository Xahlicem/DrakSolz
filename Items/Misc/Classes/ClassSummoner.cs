namespace DrakSolz.Items.Misc.Classes {
    public class ClassSummoner : ClassItem {
        protected override string TEXT { get { return "A Pyromancer"; } }
        protected override int STR { get { return 0; } }
        protected override int DEX { get { return 0; } }
        protected override int INT { get { return 4; } }
        protected override int FTH { get { return 4; } }
        protected override int VIT { get { return 0; } }
        protected override int ATT { get { return 2; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pyromancer Rune");
            Tooltip.SetDefault("Consume to focus on faith and intelligence.");
        }
    }
}