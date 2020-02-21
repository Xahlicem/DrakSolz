﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class EstusShard : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Estus Shard");
            Tooltip.SetDefault("Used to reinforce Estus Flask, increasing uses.");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Book);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Yellow;
        }
    }
}