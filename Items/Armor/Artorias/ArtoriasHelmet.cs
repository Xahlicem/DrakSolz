using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Artorias {
    [AutoloadEquip(EquipType.Head)]
    public class ArtoriasHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Arter Rias Helmet");
            Tooltip.SetDefault("Apparel.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.rare = ItemRarityID.Red;
            item.defense = 40;
        }

        public override void UpdateEquip(Player player) { }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Artorias.ArtoriasArmor>() && legs.type == ModContent.ItemType<Items.Armor.Artorias.ArtoriasLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Unsealed Power");
            player.magicCrit += 95;
            player.rangedCrit += 95;
            player.meleeCrit += 95;
            player.thrownCrit += 95;
            player.magicDamage *= 2f;
            player.thrownDamage *= 2f;
            player.meleeDamage *= 2f;
            player.rangedDamage *= 2f;
            player.bulletDamage *= 2f;
            player.arrowDamage *= 2f;
            player.rocketDamage *= 2f;
            player.minionDamage *= 2f;
            player.manaCost *= 0.01f;
            player.statManaMax2 += 250;
            player.GetModPlayer<DrakSolzPlayer>().MiscHP += 500;
            player.meleeSpeed *= 1.5f;
            player.endurance += 5;
            player.accRunSpeed += 5;
            player.jumpSpeedBoost += 4;
            player.moveSpeed += 0.20f;
            player.maxRunSpeed += 0.10f;
            player.thrownVelocity *= 2f;
            player.thrownCost50 = true;
            player.thrownCost33 = true;
            player.ammoCost80 = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.AddBuff(BuffID.Battle, 2);
            player.AddBuff(BuffID.WaterCandle, 2);
            player.armorPenetration += 20;
            player.onHitDodge = true;
            player.onHitRegen = true;
        }
        public override void ArmorSetShadows(Player player) {
            player.armorEffectDrawShadow = true;
            /*if (Main.rand.Next(3) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Smoke, 0, 0, 0, Color.Black);
                Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }*/
        }
        public override bool DrawHead() {
            return false;
        }
        public class ArtoriasHelmetGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (npc.type == ModContent.NPCType<NPCs.Enemy.Boss.AbyssStalker>()) {
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.Artorias.ArtoriasHelmet>(), 1);
                }
            }
        }
    }
}