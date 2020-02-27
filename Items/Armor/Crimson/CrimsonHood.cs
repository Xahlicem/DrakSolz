using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Crimson {
    [AutoloadEquip(EquipType.Head)]
    public class CrimsonHood : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Crimson Hood");
            Tooltip.SetDefault("Increases maximum mana by 15" +
                "\nReduces mana usage by 5%" );
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 15;
            player.manaCost *= 0.95f;
        }
        public override bool DrawHead() {
            return false;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Crimson.CrimsonRobe>() && legs.type == ModContent.ItemType<Items.Armor.Crimson.CrimsonSkirt>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("5% increased fire damage" +
                "\nreduced damage taken from lava and ability to walk on fire blocks");
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.05f;
            player.lavaRose = true;
            player.fireWalk = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddIngredient(ItemID.LavaBucket, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }
}