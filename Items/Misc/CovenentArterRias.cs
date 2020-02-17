using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CovenentArterRias : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Covenent of Arter Rias");
            Tooltip.SetDefault("Ring worn by the Abyss-Stalker Arter Rias.");
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
            Main.NewText("The legendary Arter Rias has arisen!", 25, 25, 75);
            NPC.NewNPC((int) player.Center.X, (int) player.Center.Y - 180, ModContent.NPCType<NPCs.Enemy.Boss.AbyssStalker>());
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.DemonTitanite>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Banners.RingedKnightBanner>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}