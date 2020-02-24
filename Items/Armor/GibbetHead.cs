using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class GibbetHead : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gibbet Head");
            Tooltip.SetDefault("Umm... I wouldn't wear this if I were you." +
                "\n???");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(25, 0, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 35;
        }

        public override void UpdateEquip(Player player) {
            player.meleeCrit += 50;
        }

        public override bool DrawHead() {
            return false;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.GibbetBody>() && legs.type == ModContent.ItemType<Items.Armor.GibbetLegs>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("I am become Gibbet" +
                "\nDestroyer of Terraria");
            player.magicCrit += 25;
            player.rangedCrit += 25;
            player.meleeCrit += 25;
            player.thrownCrit += 25;
            player.allDamage *= 1.50f;
            player.thrownVelocity *= 1.3f;
            player.manaCost *= 0.80f;
            player.meleeSpeed *= 1.40f;
            player.statLifeMax2 += 100;
            player.statManaMax2 += 40;
            player.endurance += 5;
            player.accRunSpeed += 5;
            player.jumpSpeedBoost += 4;
            player.moveSpeed += 0.20f;
            player.maxRunSpeed += 0.10f;
            player.AddBuff(BuffID.Sharpened, 1);
            player.AddBuff(BuffID.Endurance, 1);
            player.AddBuff(BuffID.WeaponImbueVenom, 1);
            player.AddBuff(BuffID.Dangersense, 1);
            player.AddBuff(BuffID.Hunter, 1);
        }
        public class GibbetHeadGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Corrupt.Gibbet>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.GibbetHead>(), 1);
                    }
                }
            }
        }
    }
}