using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.FireKeeper {
    [AutoloadEquip(EquipType.Head)]
    public class FireKeeperMask : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Fire Keeper's Mask");
            Tooltip.SetDefault("Increases maximum mana by 40" +
                "\nReduces mana usage by 30%" );
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 40;
            player.manaCost *= 0.70f;
            player.blind = true;
        }
        public override bool DrawHead() {
            return true;
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.FireKeeper.FireKeeperShirt>() && legs.type == ModContent.ItemType<Items.Armor.FireKeeper.FireKeeperSkirt>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("25% increased fire damage and critical strike chance" +
                "\nreduced hollowing restoration delay");
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.25f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 15;
            player.AddBuff(ModContent.BuffType<Buffs.FirelinkKeep>(), 1);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.AddRecipe();
        }
    }
}