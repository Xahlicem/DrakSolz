using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.BlackKnight {
    [AutoloadEquip(EquipType.Head)]
    public class BlackKnightHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Knight Helmet");
            Tooltip.SetDefault("Apparel." +
                "\n+50 mana"+
                "\n25% reduced mana cost");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = -1;
            item.defense = 28;
        }

        public override void UpdateEquip(Player player) {
            player.manaCost *= 0.75f;
            player.statManaMax2 += 50;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.BlackKnight.BlackKnightArmor>() && legs.type == mod.ItemType<Items.Armor.BlackKnight.BlackKnightLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Unwavered Valor" +
                "\n25% increased damage" +
                "\n15% increased critical chance");
            player.magicCrit += 15;
            player.rangedCrit += 15;
            player.meleeCrit += 15;
            player.thrownCrit += 15;
            player.magicDamage *= 1.25f;
            player.thrownDamage *= 1.25f;
            player.minionDamage *= 1.25f;
            player.meleeDamage *= 1.25f;
            player.rangedDamage *= 1.25f;
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