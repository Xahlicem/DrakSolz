using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


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
            item.maxStack = 999999;
            item.value = Item.buyPrice(0, 0, 0, 1);
            item.rare = 0;
            item.alpha = 64;
        }

        public override bool CanPickup(Player player) {
            return true;
        }

        // The following 2 methods are purely to show off these 2 hooks. Don't use them in your own code.
        public override void GrabRange(Player player, ref int grabRange) {
            grabRange *= 7;
        }

        public override bool OnPickup(Player player) {
            player.GetModPlayer<XahlicemPlayer>().Souls += item.stack;
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
            if (npc.lifeMax >= 5) Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("Soul"), (npc.defense + npc.damage + 1) * npc.lifeMax / 80);
        }
    }
}