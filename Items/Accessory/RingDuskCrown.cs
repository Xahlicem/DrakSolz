﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Accessory {
    public class RingDuskCrown : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dusk Crown Ring");
            Tooltip.SetDefault("This is a modded ring." +
                "\n-50% Mana Cost");
        }

        public override void SetDefaults() {
            item.width = 22;
            item.defense = -30;
            item.height = 20;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        //these wings use the same values as the solar wings
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.manaCost *= 0.5f;

        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Soul"), 500);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}