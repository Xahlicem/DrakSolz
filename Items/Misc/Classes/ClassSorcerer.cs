using Terraria.ModLoader;

namespace DrakSolz.Items.Misc.Classes {
    public class ClassSorcerer : ClassItem {
        protected override string TEXT { get { return "A Sorcerer"; } }
        protected override int STR { get { return 0; } }
        protected override int DEX { get { return 0; } }
        protected override int INT { get { return 8; } }
        protected override int FTH { get { return 0; } }
        protected override int VIT { get { return 0; } }
        protected override int ATT { get { return 2; } }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sorcerer Rune");
            Tooltip.SetDefault("Consume to focus on intelligence.");
        }

        public override bool ConsumeItem(Terraria.Player player) {
            //player.QuickSpawnItem()
            player.QuickSpawnItem(ModContent.ItemType<Items.Magic.SoulArrow.ScrollSoulDart>());
            return true;
        }
    }
}