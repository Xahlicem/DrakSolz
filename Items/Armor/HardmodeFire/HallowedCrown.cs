using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class HallowedCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hallowed Crown");
            Tooltip.SetDefault("15% increased throwing damage" +
                "\n8% increased throwing critical strike chance");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = ItemRarityID.Pink;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.15f;
            player.thrownCrit += 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
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
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}