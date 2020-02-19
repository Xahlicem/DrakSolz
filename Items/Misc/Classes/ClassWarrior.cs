namespace DrakSolz.Items.Misc.Classes {
    public class ClassWarrior: ClassItem {
        protected override string TEXT { get { return "A Warrior"; } }
        protected override int STR { get { return 8; } }
        protected override int DEX { get { return 0; } }
        protected override int INT { get { return 0; } }
        protected override int FTH { get { return 0; } }
        protected override int VIT { get { return 2; } }
        protected override int ATT { get { return 0; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Warrior Rune");
            Tooltip.SetDefault("Consume to focus on strength.");
        }
    }
}