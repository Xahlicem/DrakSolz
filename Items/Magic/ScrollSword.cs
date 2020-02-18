using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class ScrollSword : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Magic Sword");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.useStyle = 5;
            item.noUseGraphic = true;
            item.damage = 16;
            item.useAnimation = 30;
            item.useTime = 30;
            item.knockBack = 4f;
            item.value = Item.sellPrice(0, 0, 75, 0);
            item.mana = 15;
            item.autoReuse = false;
            item.melee = false;
            item.magic = true;
        }

        public override bool CanUseItem(Player player) {
            int mbuff = player.FindBuffIndex(ModContent.BuffType<Buffs.MageSwordBuff>());
            if (mbuff < 0) {

                return true;
            } else {
                return false;
            }
        }

        public override bool UseItem(Player player) {
            player.AddBuff(ModContent.BuffType<Buffs.MageSwordBuff>(), 300);
            int idamage = item.damage;
            int iuse = item.useAnimation;
            int iani = item.useTime;
            int icrit = item.crit;
            float iknock = item.knockBack;
            byte ipref = item.prefix;
            int ialpha = item.mana;
            foreach (Item i in player.inventory)
                if (i == item) {
                    i.netDefaults(ModContent.ItemType<Items.Magic.MageSword>());
                    i.damage = idamage;
                    i.useAnimation = iuse;
                    i.useTime = iani;
                    i.crit = icrit;
                    i.knockBack = iknock;
                    i.alpha = ialpha;
                    i.prefix = ipref;
                    i.GetGlobalItem<DSGlobalItem>().FromPlayer = player.whoAmI;
                    i.GetGlobalItem<DSGlobalItem>().Owned = true;
                };

            return true;
        }
        public class ScrollSwordGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == NPCID.DarkCaster || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Spinwheel>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Magic.ScrollSword>(), 1);
                    }
                }
            }
        }
    }
}