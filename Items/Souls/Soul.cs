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

        // TODO -- Velocity Y smaller, post NewItem?
        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 0, 0, 1);
            item.rare = 0;
            item.alpha = 64;
            item.ammo = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 4;
        }

        public override bool CanUseItem(Player player) {
            return true;
        }

        public override bool UseItem(Player player) {
            player.GetModPlayer<DrakSolzPlayer>().Initialize();
            return true;
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            return (fromPlayer == -1) ? true : (player.whoAmI == fromPlayer);
        }

        public override void GrabRange(Player player, ref int grabRange) {
            grabRange *= 7;
        }

        public override bool OnPickup(Player player) {
            if (!player.Equals(Main.LocalPlayer)) return false;
            DrakSolzPlayer mPlayer = player.GetModPlayer<DrakSolzPlayer>();
            item.stack += (int)((float) item.stack * .1f * mPlayer.Avarice);
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
            //item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
            return true;
        }

        public override void PostUpdate() {
            Lighting.AddLight(item.Center, Color.White.ToVector3() * 0.04f * Main.essScale);
        }
    }
    public class SoulGlobalNPC : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.aiStyle == 9 || npc.aiStyle == 50) return;
            if (DrakSolz.ListBossSoul.Contains(npc.type) || npc.type == mod.NPCType<NPCs.Enemy.AbyssStalker>() || npc.type == mod.NPCType<NPCs.Enemy.TitaniteDemon>()) return;

            double num = Math.Ceiling(Math.Pow(Math.Sqrt(npc.defDamage) + Math.Sqrt(npc.defDefense) + Math.Sqrt(npc.lifeMax) - 1, 4) / (Math.Sqrt(npc.lifeMax) * 200));
            List<int> players = new List<int>();
            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i] != null)
                    if (npc.WithinRange(Main.player[i].Center, 800f))
                        players.Add(Main.player[i].whoAmI);
            num = Math.Ceiling(num / ((players.Count == 0) ? 1d : (double) players.Count));
            if (players.Count == 0) {
                int item = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Souls.Soul>(), (int) num);
                Main.item[item].GetGlobalItem<Items.DSGlobalItem>().FromPlayer = -1;
            } else
                for (int i = 0; i < players.Count; i++) {
                    int item = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Souls.Soul>(), (int) num);
                    Main.item[item].GetGlobalItem<Items.DSGlobalItem>().FromPlayer = players[i];
                }
        }
    }
}