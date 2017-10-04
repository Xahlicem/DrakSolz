using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Thorns {
    [AutoloadEquip(EquipType.Head)]
    public class ThornsHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Helmet of Thorns");
            Tooltip.SetDefault("Armor famed by Commander Kirk." +
                "\n+20% thorns" +
                "\n+15% increased thrown damage");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 7;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player) {
            player.thorns += 0.20f;
            player.thrownDamage *= 1.15f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.Thorns.ThornsArmor>() && legs.type == mod.ItemType<Items.Armor.Thorns.ThornsLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Thorns" +
                "\n+thorns buff" +
                "\n+83% chance to not consume thrown weapons" +
                "\n+20% increased thrown damage" +
                "\n+10% increased thrown crit"+
                "\n+50% increased thrown velocity");
            player.thrownCost50 = true;
            player.thrownCost33 = true;
            player.AddBuff(BuffID.Thorns, 2);
            player.thrownCrit += 10;
            player.thrownDamage *= 1.2f;
            player.thrownVelocity *= 1.5f;
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpikyBall, 250);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}