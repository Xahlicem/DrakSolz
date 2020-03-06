using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.DragonSlayer {
    [AutoloadEquip(EquipType.Head)]
    public class DragonSlayerHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dragonslayer Helmet");
            Tooltip.SetDefault("Armor fashioned by Oreostein." +
                "\n50% chance to not consume thrown items" +
                "\n+50% increased thrown velocity");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 10, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player) {
            player.thrownVelocity *= 1.5f;
            player.thrownCost50 = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerChest>() && legs.type == ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Bane of Dragons" +
                "\nincreased movement and melee/thrown abilities");
            player.meleeCrit += 10;
            player.thrownCrit += 10;
            player.thrownDamage *= 1.25f;
            player.meleeSpeed *= 1.30f;
            player.accRunSpeed += 2;
            player.jumpSpeedBoost += 2;
            player.moveSpeed += 0.15f;
            player.AddBuff(BuffID.Sharpened, 1);
        }
        public override bool DrawHead() {
            return false;
        }
        /*public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}