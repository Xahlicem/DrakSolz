using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class AbyssSword : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Abyss Greatsword");
            Tooltip.SetDefault("Something is hidden within its depths...");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.useStyle = 1;
            item.damage = 3000;
            item.knockBack = 8f;
            item.useTime = 30;
            item.useAnimation = 30;
            item.value = Item.buyPrice(2, 0, 0, 0);
            item.scale *= 1.5f;
            item.autoReuse = true;
            item.melee = true;
        }

        public override bool CanUseItem(Player player) {
            int istyled = item.alpha;
            if (istyled <= 0) {
                item.useStyle = 1;
                item.alpha = 1;
            } else if (istyled <= 1) {
                item.useStyle = 3;
                item.alpha = 2;
            } else {
                item.useStyle = 2;
                item.alpha = 0;
            }
            int mbuff = player.FindBuffIndex(ModContent.BuffType<Buffs.AbyssSwordBuff>());
            int idamage = item.damage;
            int iuse = item.useAnimation + 2;
            int iani = item.useTime + 2;
            int icrit = item.crit;
            float iknock = item.knockBack;
            float isize = item.scale;
            byte ipref = item.prefix;
            if (mbuff < 0) {
                foreach (Item i in player.inventory)
                    if (i == item) {
                        i.netDefaults(ModContent.ItemType<Items.Melee.ArtoriasSword>());
                        i.damage = idamage - 1000;
                        i.useAnimation = iuse;
                        i.useTime = iani;
                        i.crit = icrit;
                        i.knockBack = iknock;
                        i.scale = isize;
                        i.prefix = ipref;
                        i.GetGlobalItem<DSGlobalItem>().FromPlayer = player.whoAmI;
                        i.GetGlobalItem<DSGlobalItem>().Owned = true;
                        Main.PlaySound(SoundID.Shatter, player.Center);
                    }
                return false;
            } else {
                Main.PlaySound(SoundID.Shatter, player.Center);
                return true;
            }
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
                Main.dust[dust].scale *= 2 + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }

        /*public override bool UseItem(Player player) {
            item.damage = 30 + (int)((player.statLifeMax2 - player.statLife) * 0.1f);
            return base.UseItem(player);
        }*/
    }
}