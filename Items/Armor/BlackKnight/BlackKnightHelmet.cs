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
            player.statManaMax2 += 60;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightArmor>() && legs.type == ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Unwavered Valor" +
                "\n55% increased damage(75% miracle)" +
                "\n20% increased critical chance(40% thrown)");
            player.magicCrit += 20;
            player.rangedCrit += 20;
            player.meleeCrit += 20;
            player.thrownCrit += 40;
            player.magicDamage *= 1.55f;
            player.thrownDamage *= 1.55f;
            player.minionDamage *= 1.75f;
            player.thrownVelocity *= 1.5f;
            player.meleeDamage *= 1.55f;
            player.rangedDamage *= 1.55f;
            player.statManaMax2 += player.statManaMax;
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}