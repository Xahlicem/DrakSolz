using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Xanthous {
    [AutoloadEquip(EquipType.Body)]
    public class XanthousOvercoat : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Xanthous Overcoat");
            Tooltip.SetDefault("Atire donned by Xanthous, the old monk." +
                "\n+10% miracle damage" +
                "\n-1 max minions" +
                "\n+40 mana");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 7;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player) {
            if(player.maxMinions >= 1){
            player.maxMinions -= 1;
            }
            player.minionDamage *= 1.1f;
            player.statManaMax2 += 40;
        }
        public override void AddRecipes() {
            if (NPC.downedPlantBoss == true) {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LivingFireBlock, 25);
                recipe.AddIngredient(mod.ItemType<Items.Armor.Tattered.TatteredTunic>());
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}