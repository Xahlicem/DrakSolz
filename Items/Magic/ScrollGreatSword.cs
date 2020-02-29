using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class ScrollGreatSword : SoulItem {
        public ScrollGreatSword() : base(20000) { }
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Magic Greatsword");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 40;
            item.useAnimation = 35;
            item.useTime = 35;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.knockBack = 8f;
            item.mana = 50;
            item.autoReuse = false;
            item.melee = false;
            item.magic = true;
        }

        public override bool CanUseItem(Player player) {
            int mbuff = player.FindBuffIndex(ModContent.BuffType<Buffs.MageGreatSwordBuff>());
            if (mbuff < 0) {

                return true;
            } else {
                return false;
            }
        }

        public override bool UseItem(Player player) {
            player.AddBuff(ModContent.BuffType<Buffs.MageGreatSwordBuff>(), 600);
            int idamage = item.damage;
            int iuse = item.useAnimation;
            int iani = item.useTime;
            int icrit = item.crit;
            int ialpha = item.mana;
            float iknock = item.knockBack;
            byte ipref = item.prefix;
            foreach (Item i in player.inventory)
                if (i == item) {
                    i.netDefaults(ModContent.ItemType<Items.Magic.MageGreatSword>());
                    i.damage = idamage;
                    i.useAnimation = iuse;
                    i.useTime = iani;
                    i.crit = icrit;
                    i.alpha = ialpha;
                    i.knockBack = iknock;
                    i.prefix = ipref;
                    i.GetGlobalItem<DSGlobalItem>().Owner = player.GetModPlayer<DrakSolzPlayer>().UID;
                    i.GetGlobalItem<DSGlobalItem>().Owned = true;
                };

            return true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.ScrollSword>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
    }
}