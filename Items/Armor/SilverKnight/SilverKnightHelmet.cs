using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.SilverKnight {
    [AutoloadEquip(EquipType.Head)]
    public class SilverKnightHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Knight Helmet");
            Tooltip.SetDefault("Apparel."+
                "\n+40 mana"+
                "\n20% reduced mana cost");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = -1;
            item.defense = 25;
        }

        public override void UpdateEquip(Player player) {
            player.manaCost *= 0.8f;
            player.statManaMax2 += 40;
             }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.SilverKnight.SilverKnightArmor>() && legs.type == mod.ItemType<Items.Armor.SilverKnight.SilverKnightLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Knight's Valor" +
                "\n20% increased damage" +
                "\n10% increased critical chance");
            player.magicCrit += 10;
            player.rangedCrit += 10;
            player.meleeCrit += 10;
            player.thrownCrit += 10;
            player.magicDamage *= 1.2f;
            player.thrownDamage *= 1.2f;
            player.minionDamage *= 1.2f;
            player.thrownVelocity *= 1.3f;
            player.meleeDamage *= 1.2f;
            player.rangedDamage *= 1.2f;
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Titanite>(), 25);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}