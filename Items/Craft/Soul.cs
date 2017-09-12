using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Net;

namespace XahlicemMod.Items.Craft {
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
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.Craft.SoulGlobalItem>().FromPlayer;
            return (fromPlayer == -1) ? true : (player.whoAmI == fromPlayer);
        }

        public override void GrabRange(Player player, ref int grabRange) {
            grabRange *= 7;
        }

        public override bool OnPickup(Player player) {
            if (!player.Equals(Main.LocalPlayer)) return false;
            player.GetModPlayer<XahlicemPlayer>().Souls += item.stack;
            player.ManaEffect(item.stack);
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
            double num = Math.Ceiling(Math.Pow(Math.Sqrt(npc.defDamage) + Math.Sqrt(npc.defDefense) + Math.Sqrt(npc.lifeMax) - 1, 4) / (Math.Sqrt(npc.lifeMax) * 200)); //(float)(npc.defDefense * npc.lifeMax + 1) / (npc.defDamage +1));
            //Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Craft.Soul>(), (int) num);
            List<int> players = new List<int>();
            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i] != null)
                    if (npc.WithinRange(Main.player[i].Center, 800f))
                        players.Add(Main.player[i].whoAmI);
            num = Math.Ceiling(num / ((players.Count == 0) ? 1d : (double) players.Count));
            if (players.Count == 0) {
                int item = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Craft.Soul>(), (int) num);
                Main.item[item].GetGlobalItem<Items.Craft.SoulGlobalItem>().FromPlayer = -1;
            } else
                for (int i = 0; i < players.Count; i++) {
                    int item = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Craft.Soul>(), (int) num);
                    Main.item[item].GetGlobalItem<Items.Craft.SoulGlobalItem>().FromPlayer = players[i];
                }
        }
    }

    public class SoulGlobalItem : GlobalItem {
        internal int fromPlayer;
        public int FromPlayer { get { return fromPlayer; } set { fromPlayer = value; } }

        public SoulGlobalItem() {
            if (Main.netMode == NetmodeID.SinglePlayer) fromPlayer = -1;
            else fromPlayer = -2;
        }

        public override bool InstancePerEntity { get { return true; } }

        public override void NetSend(Item item, System.IO.BinaryWriter writer) {
            writer.Write(fromPlayer);
        }

        public override void NetReceive(Item item, System.IO.BinaryReader reader) {
            fromPlayer = reader.ReadInt32();
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            SoulGlobalItem myClone = (SoulGlobalItem) base.Clone(item, itemClone);
            myClone.FromPlayer = fromPlayer;
            return myClone;
        }
    }
}