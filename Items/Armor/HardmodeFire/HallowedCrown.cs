using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class HallowedCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hallowed Crown");
            Tooltip.SetDefault("5% increased fire damage" +
                "\n7% increased fire critical strike chance" +
                "\nincreases maximum mana by 80");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 80;
            player.GetModPlayer<MPlayer>().pyromancyDamage += 0.05f;
            player.GetModPlayer<MPlayer>().pyromancyCrit += 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("-20% mana cost" +
                "\n8% increased fire damage");
			player.manaCost *= 0.80f;
            player.GetModPlayer<MPlayer>().pyromancyDamage += 0.08f;
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