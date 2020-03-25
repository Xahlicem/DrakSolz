using System;
using DrakSolz.Items.Souls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class FirelinkSword : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Firelink Sword");
            Tooltip.SetDefault("A sword that seems to grow in power with each lord slain");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.BladedGlove);
            item.damage = 20;
            item.crit = 10;
            item.knockBack = 8f;
            item.useTime = 32;
            item.useAnimation = 32;
            item.scale *= 0.8f;
            item.rare = ItemRarityID.Red;
            item.value = Item.sellPrice(0, 4, 0, 0);
        }
        public override void UpdateInventory(Player player) {
            DrakSolzPlayer modPlayer = (DrakSolzPlayer) player.GetModPlayer<DrakSolzPlayer>();
            int amount = modPlayer.EstusHealth - 1;
            int mult = 1;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_ARTORIAS)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_TITIANITE_DEMON)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_MOON_LORD)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_DUKE_FISHRON)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_LUNATIC_CULTIST)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_GOLEM)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_PLANTERA)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_DESTROYER)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_SKELETRON_PRIME)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_RETINAZER)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_WALL)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_BEE)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_SKELETRON)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_EATER)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_BRAIN)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_EYE)) amount++;
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_SLIME)) amount++;
            item.crit = 10 + (amount);
            int c = 10 + (amount);
            if (HasDownedBoss(modPlayer, BossSoul.SOUL_ARTORIAS)) { mult = 150; } else if (HasDownedBoss(modPlayer, BossSoul.SOUL_TITIANITE_DEMON)) { mult = 60; } else if (HasDownedBoss(modPlayer, BossSoul.SOUL_MOON_LORD)) { mult = 12; } else if (HasDownedBoss(modPlayer, BossSoul.SOUL_LUNATIC_CULTIST)) { mult = 10; } else if (HasDownedBoss(modPlayer, BossSoul.SOUL_GOLEM)) { mult = 8; } else if (HasDownedBoss(modPlayer, BossSoul.SOUL_PLANTERA)) { mult = 6; } else if (HasDownedBoss(modPlayer, BossSoul.SOUL_WALL)) { mult = 5; } else { mult = 4; }
            item.damage = 20 + (amount * mult);
            int d = 20 + (amount * mult);
            if (item.prefix == 39) {
                item.damage = (int)(d * 0.7f);
            }
            if (item.prefix == 50) {
                item.damage = (int)(d * 0.8f);
            }
            if (item.prefix == 8 || item.prefix == 10 || item.prefix == 40) {
                item.damage = (int)(d * 0.85f);
            }
            if (item.prefix == 13 || item.prefix == 41) {
                item.damage = (int)(d * 0.9f);
            }
            if (item.prefix == 3 || item.prefix == 12 || item.prefix == 51 || item.prefix == 55) {
                item.damage = (int)(d * 1.05f);
            }
            if (item.prefix == 46) {
                item.damage = (int)(d * 1.07f);
            }
            if (item.prefix == 4 || item.prefix == 6 || item.prefix == 37 || item.prefix == 43 || item.prefix == 53) {
                item.damage = (int)(d * 1.1f);
            }
            if (item.prefix == 5 || item.prefix == 59 || item.prefix == 60 || item.prefix == 81) {
                item.damage = (int)(d * 1.15f);
            }
            if (item.prefix == 57) {
                item.damage = (int)(d * 1.18f);
            }
            if (item.prefix == 3 || item.prefix == 51) {
                item.crit = (int)(c * 1.02f);
            }
            if (item.prefix == 36 || item.prefix == 37 || item.prefix == 44 || item.prefix == 46) {
                item.crit = (int)(c * 1.03f);
            }
            if (item.prefix == 59 || item.prefix == 60 || item.prefix == 61 || item.prefix == 81) {
                item.crit = (int)(c * 1.05f);
            }
        }

        public static bool HasDownedBoss(DrakSolzPlayer modPlayer, int bossSoulPlace) {
            return ((modPlayer.BossSouls & bossSoulPlace) > 0);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.Next(1) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 120);
            player.AddBuff(ModContent.BuffType<Buffs.FirelinkKeep>(), 120);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Tiles.FirelinkShrine>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}