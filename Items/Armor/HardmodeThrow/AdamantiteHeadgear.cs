using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class AdamantiteHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Adamantite Headgear");
            Tooltip.SetDefault("14% increased throwing damage" +
                "\n8% increased throwing critical strike chance");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 13;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.14f;
            player.thrownCrit += 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("33% chance to not consume thrown item" +
                "\n20% increased throwing velocity");
            player.thrownCost33 = true;
            player.thrownVelocity *=1.2f;
        }

        public override void ArmorSetShadows(Player player) {
            player.armorEffectDrawOutlines = true;
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