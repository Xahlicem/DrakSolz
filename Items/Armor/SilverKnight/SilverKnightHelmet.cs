using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.SilverKnight {
    [AutoloadEquip(EquipType.Head)]
    public class SilverKnightHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Silver Knight Helmet");
            Tooltip.SetDefault("Apparel." +
                "\n+40 mana" +
                "\n20% reduced mana cost");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Gray;
            item.defense = 25;
        }

        public override void UpdateEquip(Player player) {
            player.manaCost *= 0.8f;
            player.statManaMax2 += 40;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.SilverKnight.SilverKnightArmor>() && legs.type == ModContent.ItemType<Items.Armor.SilverKnight.SilverKnightLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Knight's Valor" +
                "\n50% increased damage(70% Miracle)" +
                "\n15% increased critical chance(35% thrown)");
            player.magicCrit += 15;
            player.rangedCrit += 15;
            player.meleeCrit += 15;
            player.thrownCrit += 35;
            player.magicDamage *= 1.5f;
            player.thrownDamage *= 1.5f;
            player.minionDamage *= 1.7f;
            player.thrownVelocity *= 1.3f;
            player.meleeDamage *= 1.5f;
            player.rangedDamage *= 1.5f;
            player.statManaMax2 += player.statManaMax;
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}