namespace DrakSolz.Items.Misc.Classes {
    public class ClassWizard: ClassItem {
        protected override string TEXT { get { return "A Wizard"; } }
        protected override int STR { get { return 0; } }
        protected override int DEX { get { return 0; } }
        protected override int INT { get { return 2; } }
        protected override int FTH { get { return 0; } }
        protected override int VIT { get { return 2; } }
        protected override int ATT { get { return 6; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Wizard Rune");
            Tooltip.SetDefault("Consume to focus on attunement, slightly gaining intelligence.");
        }
    }
}