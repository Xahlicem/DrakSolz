using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class DemonTitanite : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Demon Titanite");
            Tooltip.SetDefault("From a fallen Titanite Demon.");
        }

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
            item.rare = 10;
            item.maxStack = 1;
            item.consumable = true;
        }
        public override bool UseItem(Player player) {
            player.AddBuff(BuffID.Panic, 3600);
            Main.NewText("A wandering demon has arrived!", 50, 50, 50);
            NPC.NewNPC((int) player.Center.X, (int) player.Center.Y - 180, mod.NPCType<NPCs.Enemy.Boss.TitaniteDemon>());
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Titanite>(), 20);
            recipe.AddIngredient(mod.ItemType<Items.Banners.InhumanityBanner>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}