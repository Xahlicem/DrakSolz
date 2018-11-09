using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Xanthous {
    [AutoloadEquip(EquipType.Head)]
    public class XanthousCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Xanthous Crown");
            Tooltip.SetDefault("Atire donned by Xanthous, the old monk." +
                "\n+10% miracle damage" +
                "\n-1 max minions" +
                "\n+60 mana");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 7;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player) {
            if(player.maxMinions >= 1){
            player.maxMinions -= 1;
            }
            player.minionDamage *= 1.1f;
            player.statManaMax2 += 60;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.Xanthous.XanthousOvercoat>() && legs.type == mod.ItemType<Items.Armor.Xanthous.XanthousWaistcloth>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Yellow Madness" +
                "\n+20% miracle damage" +
                "\n30% reduced mana cost" +
                "\n+40 life");
            player.statLifeMax2 += 40;
            player.minionDamage *= 1.2f;
            player.manaCost *= 0.7f;
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
                recipe.AddIngredient(ItemID.LivingFireBlock, 25);
                recipe.AddIngredient(mod.ItemType<Items.Armor.Tattered.TatteredHat>());
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();

        }
    }
}