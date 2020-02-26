using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.HardmodeFire {
    [AutoloadEquip(EquipType.Head)]
    public class AdamantiteCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Adamantite Crown");
            Tooltip.SetDefault("14% increased throwing damage" +
                "\n8% increased throwing critical strike chance");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 11;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 80;
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.11f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 11;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("-19% mana cost");
			player.manaCost *= 0.81f;
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