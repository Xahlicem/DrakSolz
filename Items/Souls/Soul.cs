using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Net;

namespace DrakSolz.Items.Souls {
    public class Soul : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("'Souls of the Fallen'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 1;
            item.value = 0;
            item.rare = ItemRarityID.White;
            item.alpha = 64;
            item.ammo = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 4;
        }

        public override bool ItemSpace(Player player) {
            return true;
        }

        public override bool CanUseItem(Player player) {
            return true;
        }

        public override bool UseItem(Player player) {
            player.GetModPlayer<DrakSolzPlayer>().Initialize();
            return true;
        }

        public override bool CanPickup(Player player) {
            long owner = item.GetGlobalItem<Items.DSGlobalItem>().Owner;
            return (owner == -1) ? true : (player.GetModPlayer<DrakSolzPlayer>().UID == owner);
        }

        public override void GrabRange(Player player, ref int grabRange) {
            grabRange *= 7;
        }

        public override bool OnPickup(Player player) {
            if (!player.Equals(Main.LocalPlayer)) return false;
            DrakSolzPlayer mPlayer = player.GetModPlayer<DrakSolzPlayer>();
            item.stack += (int) ((float) item.stack * .1f * mPlayer.Avarice);
            mPlayer.SoulTicks += item.stack;
            player.ManaEffect(item.stack);
            if (mPlayer.EvilEye) {
                player.statLife += 5;
                player.HealEffect(5);
            }
            return false;
        }

        public override bool GrabStyle(Player player) {
            Vector2 vectorItemToPlayer = player.Center - item.Center;
            Vector2 movement = vectorItemToPlayer.SafeNormalize(default(Vector2)) * 0.7f;
            item.velocity = movement;
            float magnitude = (float) Math.Sqrt(item.velocity.X * item.velocity.X + item.velocity.Y * item.velocity.Y);
            item.velocity *= 16f / magnitude;
            return true;
        }

        public override void PostUpdate() {
            Lighting.AddLight(item.Center, Color.White.ToVector3() * 0.04f * Main.essScale);
        }
    }
    public class SoulGlobalNPC : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.aiStyle == 9 || npc.aiStyle == 50) return;
            if (DrakSolz.ListBossSoul.Contains(npc.type) || npc.type == ModContent.NPCType<NPCs.Enemy.Boss.AbyssStalker>() || npc.type == ModContent.NPCType<NPCs.Enemy.Boss.TitaniteDemon>()) return;

            double num = Math.Ceiling(Math.Pow(Math.Sqrt(npc.defDamage) + Math.Sqrt(npc.defDefense) + Math.Sqrt(npc.lifeMax) - 1, 4) / (Math.Sqrt(npc.lifeMax) * 200));
            if (npc.TypeName == "Crawltipede") {
                num *= 0.05f;
            }
            List<int> players = new List<int>();
            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i] != null)
                    if (npc.WithinRange(Main.player[i].Center, 800f))
                        players.Add(Main.player[i].whoAmI);
            num = Math.Ceiling(num / ((players.Count == 0) ? 1d : (double) players.Count));
            if (players.Count == 0) {
                int item = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Souls.Soul>(), (int) num);
                Main.item[item].GetGlobalItem<Items.DSGlobalItem>().Owner = -1;
            } else
                for (int i = 0; i < players.Count; i++) {
                    int item = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Souls.Soul>(), (int) num);
                    Main.item[item].GetGlobalItem<Items.DSGlobalItem>().Owner = Main.player[players[i]].GetModPlayer<DrakSolzPlayer>().UID;
                }
        }
    }
}