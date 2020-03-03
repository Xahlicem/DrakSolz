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
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Gray;
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
			player.GetModPlayer<MPlayer>().pyromancyCrit += 20;
            player.thrownCrit += 40;
            player.allDamage += 0.55f;
            player.minionDamage += 0.20f;
            player.thrownVelocity *= 1.5f;
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