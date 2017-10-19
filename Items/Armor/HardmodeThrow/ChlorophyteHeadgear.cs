using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeThrow {
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteHeadgear : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chlorophyte Headgear");
            Tooltip.SetDefault("16% increased ranged damage" +
                "\n6% increased ranged critical strike chance");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 6, 0);
            item.rare = 7;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.16f;
            player.thrownCrit += 6;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Summons a powerful leaf crystal to shoot at nearby enemies");
            player.AddBuff(BuffID.LeafCrystal, 5);
        }

        public override void ArmorSetShadows(Player player) {
            player.armorEffectDrawOutlines = true;
        }
        
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}