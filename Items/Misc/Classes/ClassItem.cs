using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc.Classes {
    public abstract class ClassItem : ModItem {
        protected abstract string TEXT { get; }
        protected abstract int STR { get; }
        protected abstract int DEX { get; }
        protected abstract int INT { get; }
        protected abstract int FTH { get; }
        protected abstract int VIT { get; }
        protected abstract int ATT { get; }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Pho);
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.maxStack = 1;
            item.consumable = true;
        }
        public override bool UseItem(Player player) {
            Main.NewText(TEXT + " has been chosen!", 255, 255, 255);
            //player.GetModPlayer<DrakSolzPlayer>().LevelUp(STR, DEX, INT, FTH, VIT, ATT);
            player.GetModPlayer<DrakSolzPlayer>().Str = (STR);
            player.GetModPlayer<DrakSolzPlayer>().Dex = (DEX);
            player.GetModPlayer<DrakSolzPlayer>().Int = (INT);
            player.GetModPlayer<DrakSolzPlayer>().Fth = (FTH);
            player.GetModPlayer<DrakSolzPlayer>().Vit = (VIT);
            player.GetModPlayer<DrakSolzPlayer>().Att = (ATT);
            return true;
        }
        public override void AddRecipes() {
            if (ModContent.ItemType<Items.Misc.Classes.ClassEmpty>() == this.item.netID) return;
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.GetModItem(ModContent.ItemType<Items.Misc.Classes.ClassEmpty>()), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}