using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class MageSword : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Magic Sword");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.damage = 16;
            item.useAnimation = 30;
            item.useTime = 30;
            item.knockBack = 4f;
            item.value = Item.sellPrice(0, 0, 75, 0);
            item.melee = false;
            item.magic = true;
            item.scale *= 1.3f;
            item.mana = 0;
        }

        public override bool CanUseItem(Player player) {
            float MSpeed = player.meleeSpeed * 10;
            item.useTime = (30 * ((int) MSpeed)) / 10;
            item.useAnimation = (30 * ((int) MSpeed)) / 10;
            int mbuff = player.FindBuffIndex(ModContent.BuffType<Buffs.MageSwordBuff>());
            int idamage = item.damage;
            int iuse = item.useAnimation;
            int iani = item.useTime;
            int icrit = item.crit;
            float iknock = item.knockBack;
            byte ipref = item.prefix;
            int imana = item.alpha;
            if (mbuff < 0) {
                foreach (Item i in player.inventory)
                    if (i == item) {
                        i.netDefaults(ModContent.ItemType<Items.Magic.ScrollSword>());
                        i.damage = idamage;
                        i.useAnimation = iuse;
                        i.useTime = iani;
                        i.crit = icrit;
                        i.knockBack = iknock;
                        i.mana = imana;
                        i.prefix = ipref;
                        i.GetGlobalItem<DSGlobalItem>().Owner = player.GetModPlayer<DrakSolzPlayer>().UID;
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
            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.BlueCrystalShard);
                Main.dust[dust].scale *= 1 + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
    }
}