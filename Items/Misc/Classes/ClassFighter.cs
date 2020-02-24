namespace DrakSolz.Items.Misc.Classes {
    public class ClassFighter : ClassItem {
        protected override string TEXT { get { return "A Fighter"; } }
        protected override int STR { get { return 4; } }
        protected override int DEX { get { return 4; } }
        protected override int INT { get { return 0; } }
        protected override int FTH { get { return 0; } }
        protected override int VIT { get { return 2; } }
        protected override int ATT { get { return 0; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fighter Rune");
            Tooltip.SetDefault("Consume to focus between dexterity and strength.");
        }
    }
}