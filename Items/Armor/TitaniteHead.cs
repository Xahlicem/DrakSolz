using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class TitaniteHead : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanite Demon Head");
            Tooltip.SetDefault("Or lack thereof!" +
                "\n+50% increased melee Damage" +
                "\n+25% increased melee Crit" +
                "\n+ higher jumps" +
                "\n+ faster falls");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.jumpSpeedBoost += 5;
            player.maxFallSpeed *= 4;
            player.accDivingHelm = true;
            player.blind = true;
            player.meleeDamage *= 1.5f;
            player.meleeCrit += 25;
            player.headcovered = true;
        }

        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Titanite>(), 500);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}