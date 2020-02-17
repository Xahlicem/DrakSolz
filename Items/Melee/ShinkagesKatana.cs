using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class ShinkagesKatana : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shinkage's Katana");
            Tooltip.SetDefault("???.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.damage = 1800;
            item.knockBack = 10f;
            item.useTime = 20;
            item.useAnimation = 20;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
                Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.ShadowFlame, 180);
        }
        public class SoulShatterGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Dungeon.Shinkage>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Melee.ShinkagesKatana>(), 1);
                    }
                }
            }
        }
    }
}