using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Paladin {
    [AutoloadEquip(EquipType.Head)]
    public class PaladinHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Paladin Helmet");
            Tooltip.SetDefault("Attire donned by Leeroy, a forgotten paladin." +
                "\n+10% miracle damage" +
                "\n-1 max minions" +
                "\n+60 mana");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player) {
            if (player.maxMinions >= 1) {
                player.maxMinions -= 1;
            }
            player.minionDamage += 1.1f;
            player.statManaMax2 += 60;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Paladin.PaladinArmor>() && legs.type == ModContent.ItemType<Items.Armor.Paladin.PaladinLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Righteous Pilgrimage" +
                "\n+20% miracle damage" +
                "\n30% reduced mana cost" +
                "\n+ increased life regen");
            player.lifeRegen += 4;
            player.lifeRegenCount -= 2;
            player.minionDamage += 1.2f;
            player.manaCost *= 0.7f;
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}