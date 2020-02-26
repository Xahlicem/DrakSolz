using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class ChlorophyteCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chlorophyte Crown");
            Tooltip.SetDefault("16% increased throwing damage" +
                "\n6% increased throwing critical strike chance");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 6, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 16;
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
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}