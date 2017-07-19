using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Craft {
    public class Soul : ModItem {
        public override void SetStaticDefaults() {
            //DisplayName.SetDefault("Soul");
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
            item.value = 1;
            item.rare = 0;
            item.alpha = 64;
        }

        // The following 2 methods are purely to show off these 2 hooks. Don't use them in your own code.
        public override void GrabRange(Player player, ref int grabRange) {
            grabRange *= 3;
        }

        public override bool GrabStyle(Player player) {
            Vector2 vectorItemToPlayer = item.Center - player.Center;
            Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 0.1f;
            item.velocity = item.velocity + movement;
            item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
            return true;
        }

        public override void PostUpdate() {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RottenChunk, 15);
            recipe.AddIngredient(ItemID.VilePowder, 30);
            recipe.AddIngredient(ItemID.WormTooth, 10);
            recipe.AddIngredient(ItemID.Emerald, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }

    public class SoulGlobalNPC : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.lifeMax >= 5) Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("Soul"), (npc.defense + npc.damage + 1) * npc.lifeMax / 80);
        }
    }
}