using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class ArtoriasSword : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arter Rias' Greatsword");
            Tooltip.SetDefault("Something is hidden within its depths...");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.useStyle = 1;
            item.damage = 2000;
            item.knockBack = 8f;
            item.useTime = 30;
            item.useAnimation = 30;
            item.autoReuse = true;
            item.scale *= 1.5f;
            item.melee = true;
        }
        public override bool CanUseItem(Player player) {
            int mbuff = player.FindBuffIndex(mod.BuffType<Buffs.AbyssSwordBuff>());
            if (mbuff < 0) {

                return true;
            } else {
                return false;
            }
        }

        public override bool UseItem(Player player) {
            if (Main.rand.Next(15) == 0) {
            player.AddBuff(mod.BuffType<Buffs.AbyssSwordBuff>(), 180);
            int idamage = item.damage;
            int iuse = item.useAnimation - 2;
            int iani = item.useTime - 2;
            int icrit = item.crit;
            float iknock = item.knockBack;
            float isize = item.scale;
            byte ipref = item.prefix;
            foreach (Item i in player.inventory)
                if (i == item) {
                    i.netDefaults(mod.ItemType<Items.Melee.AbyssSword>());
                    i.damage = idamage + 500;
                    i.useAnimation = iuse;
                    i.useTime = iani;
                    i.crit = icrit;
                    i.knockBack = iknock;
                    i.scale = isize;
                    i.prefix = ipref;
                    i.GetGlobalItem<DSGlobalItem>().FromPlayer = player.whoAmI;
                    i.GetGlobalItem<DSGlobalItem>().Owned = true;
                };
            }

            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Souls.ArtoriasSoul>());
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        /*public override bool UseItem(Player player) {
            item.damage = 30 + (int)((player.statLifeMax2 - player.statLife) * 0.1f);
            return base.UseItem(player);
        }*/
    }
}