using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class AdamantiteCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Adamantite Crown");
            Tooltip.SetDefault("6% increased fire damage" +
                "\n8% increased fire critical strike chance" +
                "\nincreases maximum mana by 70");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 70;
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.06f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("-18% mana cost" +
                "\n6% increased fire damage");
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.06f;
			player.manaCost *= 0.82f;
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