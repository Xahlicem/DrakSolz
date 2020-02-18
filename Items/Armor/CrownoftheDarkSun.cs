using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class CrownoftheDarkSun : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Crown of the Dark Sun");
            Tooltip.SetDefault("A peculiar crown, would fit nicely with some kind white robe... Just the robe." +
                "\n-1 max minions" +
                "\n+20 mana");
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player) {
            if(player.maxMinions >= 1){
            player.maxMinions -= 1;
            }
            player.statManaMax2 += 20;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) {
            drawHair = false;
            drawAltHair = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ItemID.DiamondRobe && legs.type == ItemID.None;
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("35% increased miracle damage" +
                "\nReduces mana usage by 25%" +
                "\n+15 armor");
            player.minionDamage *= 1.35f;
            player.manaCost *= 0.75f;
            player.statDefense += 15;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 1);
            recipe.AddIngredient(ItemID.UnicornHorn, 8);
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}