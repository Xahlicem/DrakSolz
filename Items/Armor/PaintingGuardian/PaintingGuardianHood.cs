using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.PaintingGuardian {
    [AutoloadEquip(EquipType.Head)]
    public class PaintingGuardianHood : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Painting Guardian Hood");
            Tooltip.SetDefault("Increases maximum mana by 10" +
                "\nReduces mana usage by 5%" );
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 3;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 10;
            player.manaCost *= 0.95f;
        }
        public override bool DrawHead() {
            return false;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.PaintingGuardian.PaintingGuardianRobe>() && legs.type == mod.ItemType<Items.Armor.PaintingGuardian.PaintingGuardianLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("5% increased miracle damage" +
                "\nIncreases your max number of minions");
            player.minionDamage *= 1.05f;
            player.maxMinions += 1;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}