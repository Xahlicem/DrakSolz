using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Net;

namespace XahlicemMod.Items.Craft {
    public class Soul : ModItem {
        public override void SetStaticDefaults() {
            //DisplayName.SetDefault(" ");
            Tooltip.SetDefault("'Souls of the Fallen'");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            //ItemID.Sets.ItemIconPulse[item.type] = true;
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
            item.noGrabDelay = 200;
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.Craft.SoulGlobalItem>().FromPlayer;
            return (fromPlayer == -1) ? true : (player.whoAmI == fromPlayer);
        }

        // The following 2 methods are purely to show off these 2 hooks. Don't use them in your own code.
        public override void GrabRange(Player player, ref int grabRange) {
            grabRange *= 7;
        }

        public override bool OnPickup(Player player) {
            if (!player.Equals(Main.LocalPlayer)) return false;
            player.GetModPlayer<XahlicemPlayer>().Souls += item.stack;
            player.ManaEffect(item.stack);
            Main.NewText(item.GetGlobalItem<Items.Craft.SoulGlobalItem>().FromPlayer.ToString(), Color.Beige);
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

        public ModPacket GetPacket(int item, int player) {
            ModPacket packet = this.mod.GetPacket();

            packet.Write((byte) XModMessageType.Soul);
            packet.Write(player);
            packet.Write(item);

            return packet;
        }
    }
    public class SoulGlobalNPC : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.lifeMax < 5) return;
            double num = Math.Ceiling((float)(npc.defense + npc.damage + 1) * npc.lifeMax / 80f);
            //Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Craft.Soul>(), (int) num);
            List<int> players = new List<int>();
            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i] != null) {
                    if (Main.player[i].Distance(npc.position) < 1000) players.Add(Main.player[i].whoAmI);
                }
            if (players.Count == 0) Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Craft.Soul>(), (int) num);
            else
                for (int i = 0; i < players.Count; i++) {
                    int item = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Craft.Soul>(), (int)(num / (float) players.Count));
                    Main.item[item].GetGlobalItem<Items.Craft.SoulGlobalItem>().FromPlayer = players[i];
                    Main.NewText(i.ToString(), Color.Beige);
                    if (Main.netMode == NetmodeID.Server)(Main.item[item].modItem as Soul).GetPacket(item, players[i]);
                }

        }
    }

    public class SoulGlobalItem : GlobalItem {
        private int fromPlayer = -1;
        public int FromPlayer { get { return fromPlayer; } set { fromPlayer = value; } }

        public override void NetSend(Item item, System.IO.BinaryWriter writer) {
            writer.Write(fromPlayer);
        }

        public override void NetReceive(Item item, System.IO.BinaryReader reader) {
            fromPlayer = reader.ReadInt32();
        }

        public override bool InstancePerEntity {
            get {
                return true;
            }
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            SoulGlobalItem myClone = (SoulGlobalItem) base.Clone(item, itemClone);
            myClone.fromPlayer = fromPlayer;
            return myClone;
        }
    }
}