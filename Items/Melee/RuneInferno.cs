using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class RuneInferno : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rune Inferno");
            Tooltip.SetDefault("???.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Muramasa);
            item.damage = 1900;
            item.knockBack = 10f;
            item.useTime = 30;
            item.useAnimation = 30;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
                Main.dust[dust].scale *= 2f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.Oiled, 180);
            target.AddBuff(BuffID.OnFire, 180);
        }
        public class RuneInfernoGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Underworld.Cacophynos>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Melee.RuneInferno>(), 1);
                    }
                }
            }
        }
    }
}