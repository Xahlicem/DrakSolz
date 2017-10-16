using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class AdamantiteHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Adamantite Headgear");
            Tooltip.SetDefault("+25% thrown damage" +
                "\n+12% thrown crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 4;
            item.defense = 13;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.25f;
            player.thrownCrit += 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("+50% chance to not consume thrown item" +
                "\n+30% thrown velocity");
            player.thrownCost50 = true;
            player.thrownVelocity *=1.3f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}