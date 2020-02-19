namespace DrakSolz.Items.Misc.Classes {
    public class ClassEmpty : ClassItem {
        protected override string TEXT { get { return "A Forsaken"; } }
        protected override int STR { get { return 0; } }
        protected override int DEX { get { return 0; } }
        protected override int INT { get { return 0; } }
        protected override int FTH { get { return 0; } }
        protected override int VIT { get { return 0; } }
        protected override int ATT { get { return 0; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mysterious Rune");
            Tooltip.SetDefault("Forge into your desired class, or consume to forsake your fate.");
        }
    }
}