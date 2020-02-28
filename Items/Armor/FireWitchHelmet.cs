using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;
using System.Collections.Generic;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class FireWitchHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Flame Warmage Helmet");
            Tooltip.SetDefault("A steady helmet, usually paired with a blue pyromancy robe... How do a get a matching color?" +
                "\n20% increased fire damage");
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.20f;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) {
            drawHair = false;
            drawAltHair = false;
        }
        public override bool DrawHead() {
            return false;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Crimson.CrimsonRobe>() && legs.type == ModContent.ItemType<Items.Armor.Crimson.CrimsonSkirt>();
        }

        public override void UpdateArmorSet(Player player) {
            if (player.dye[1].type == ItemID.SkyBlueDye && player.dye[2].type == ItemID.SkyBlueDye){
            player.setBonus = ("30% increased fire damage and critical strike chance" +
                "\nincreases mana usage by 50%");
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.30f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 30;
            player.manaCost *= 1.5f;}
        }
        public class FireWitchHeadNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(25) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.PostPlantera.FlameWarmage>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.FireWitchHelmet>(), 1);
                    }
                }
            }
        }

    }
}