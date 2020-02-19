namespace DrakSolz.Items.Misc.Classes {
    public class ClassCleric : ClassItem {
        protected override string TEXT { get { return "A Cleric"; } }
        protected override int STR { get { return 0; } }
        protected override int DEX { get { return 0; } }
        protected override int INT { get { return 0; } }
        protected override int FTH { get { return 4; } }
        protected override int VIT { get { return 2; } }
        protected override int ATT { get { return 4; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cleric Rune");
            Tooltip.SetDefault("Consume to focus on wisdom and faith.");
        }
    }
}