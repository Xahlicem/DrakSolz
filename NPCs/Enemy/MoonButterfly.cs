using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy {
    public class MoonButterfly : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Butterfly");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults() {
            npc.CloneDefaults(NPCID.Moth);
            npc.scale = 1.5f;
            npc.width = 24;
            //npc.aiStyle = 39;
            aiType = NPCID.Moth;
            animationType = NPCID.Moth;
            npc.height = 70;
            npc.damage = 130;
            npc.defense = 40;
            npc.lifeMax = 8000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 22500f;
            npc.knockBackResist = 0f;
            npc.rarity = 1;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.MoonButterflyBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            if (NPC.downedGolemBoss && Main.moonPhase == 0)
                return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
            else return 0f;
        }
        public override void AI() {
            npc.TargetClosest(true);
            float distance = Main.player[npc.target].Distance(npc.Center);
            if (distance >= 150 && distance <= 152) {
                int proj = Projectile.NewProjectile(npc.Center, (GetVelocity(Main.player[npc.target])* 1.5f), mod.ProjectileType<Projectiles.Magic.MoonButterflyProj>(), (npc.damage / 5), 0f);
                Main.projectile[proj].scale *= 0.3f;
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].hostile = true;
            }
            else if (distance >= 300 && distance <= 302) {
                int proj = Projectile.NewProjectile(npc.Center, (GetVelocity(Main.player[npc.target])* 2), mod.ProjectileType<Projectiles.Magic.MoonButterflyProj>(), (npc.damage / 4), 0f);
                Main.projectile[proj].scale *= 0.4f;
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].hostile = true;
            }
            else if (distance >= 450 && distance <= 452) {
                int proj = Projectile.NewProjectile(npc.Center, (GetVelocity(Main.player[npc.target])* 2.5f), mod.ProjectileType<Projectiles.Magic.MoonButterflyProj>(), (npc.damage / 3), 0f);
                Main.projectile[proj].scale *= 0.5f;
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].hostile = true;
            }
            else if (distance >= 600 && distance <= 602) {
                int proj = Projectile.NewProjectile(npc.Center, (GetVelocity(Main.player[npc.target])* 3), mod.ProjectileType<Projectiles.Magic.MoonButterflyProj>(), (npc.damage / 2), 0f);
                Main.projectile[proj].scale *= 0.6f;
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].hostile = true;
            }
            else if (distance >= 800 && distance <= 802) {
                int proj = Projectile.NewProjectile(npc.Center, (GetVelocity(Main.player[npc.target])* 3), mod.ProjectileType<Projectiles.Magic.MoonButterflyProj>(), (int)(npc.damage / 1.5f), 0f);
                Main.projectile[proj].scale *= 0.75f;
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].hostile = true;
            }
        }
        public override void NPCLoot() {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MoonButterfly_Gore_6"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MoonButterfly_Gore_5"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MoonButterfly_Gore_4"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MoonButterfly_Gore_3"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MoonButterfly_Gore_2"));
            Main.gore[g].scale = npc.scale;
            g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MoonButterfly_Gore_1"));
            Main.gore[g].scale = npc.scale;
            Item.NewItem(npc.Center, npc.width, npc.height, mod.ItemType<Items.Misc.Twink>());
            if (Main.rand.Next(5) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.MoonButterflyHorn>());
        }
        private Vector2 GetVelocity(Player player) {
            Vector2 vector = player.Center - npc.Center;
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            vector *= 26.5f / magnitude;

            return vector;
        }
    }
}