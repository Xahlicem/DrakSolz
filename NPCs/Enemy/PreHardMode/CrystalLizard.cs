using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.NPCs.Enemy.PreHardMode {
    public class CrystalLizard : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Crystal Lizard");
            Main.npcFrameCount[npc.type] = 11;
        }

        public override void SetDefaults() {
            npc.width = 30;
            npc.scale *= 1;
            npc.height = 20;
            npc.aiStyle = -1;
            npc.damage = 20;
            npc.defense = 15;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 100000f;
            npc.knockBackResist = 0.1f;
            npc.rarity = 1;
            npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = mod.ItemType<Items.Banners.CrystalLizardBanner>();
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return 0.005f;
            //return SpawnCondition.Cavern.Chance * 0.01f;
        }

        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;

        const int State_Still = 0;
        const int State_Walk = 1;
        const int State_Run = 2;

        public float AI_State {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }

        public float ChangeState(int state) {
            AI_State = state;
            return AI_Timer;
        }

        public override void AI() {
            if (AI_State == State_Still) {
                npc.TargetClosest(true);

                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 250f) {
                    AI_State = State_Walk;
                    AI_Timer = 0;
                } else if (npc.life < npc.lifeMax) {
                    AI_Timer++;
                    if (AI_Timer >= 10) ChangeState(State_Walk);
                }
            } else if (AI_State == State_Walk && npc.velocity.Y <= 0) {
                if (Math.Abs(npc.velocity.X) < 1) AI_Timer++;
                else AI_Timer = 0;
                if (AI_Timer >= 10) ChangeState(State_Run);
                if (AI_Timer == 3) npc.velocity.Y -= 5f;
                npc.velocity.X = npc.direction * -5;
            } else if (AI_State == State_Run) {
                AI_Timer++;
                if (AI_Timer % 24 == 0) npc.alpha += 42;
                if (npc.alpha >= 240) {
                    npc.life = 0;
                    AI_Timer = 0;
                }
            }
            npc.rotation = MathHelper.ToRadians(10 * npc.velocity.Y * -npc.direction);
        }

        const int Frame_Still = 0;

        const int Frame_Walk_Time = 4;
        static readonly int[] Frame_Walk = { 1, 2, 3, 4, 5, 6, 7, 0 };
        static readonly int Frame_Walk_Max = Frame_Walk_Time * Frame_Walk.Length;

        const int Frame_Escape_Time = 6;
        static readonly int[] Frame_Escape = { 8, 9, 10, 9 };
        static readonly int Frame_Escape_Max = Frame_Escape_Time * Frame_Escape.Length;

        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;

            if (AI_State == State_Still) {
                npc.frame.Y = Frame_Still * frameHeight;
                npc.velocity = new Vector2(npc.direction * 0, 0);
            } else if (AI_State == State_Run) {
                if (npc.frameCounter >= Frame_Escape_Max - 1)
                    npc.frameCounter = 0;
                else npc.frameCounter++;
                npc.frame.Y = Frame_Escape[(int) npc.frameCounter / Frame_Escape_Time] * frameHeight;
            } else if (AI_State == State_Walk) {
                if (npc.frameCounter >= Frame_Walk_Max - 1)
                    npc.frameCounter = 0;
                else npc.frameCounter++;
                npc.frame.Y = Frame_Walk[(int) npc.frameCounter / Frame_Walk_Time] * frameHeight;
            }
        }
        public override void OnHitPlayer(Player player, int damage, bool crit) {
            player.AddBuff(mod.BuffType<Buffs.SlipperyBuff>(), 3600, true);
        }
        public override void NPCLoot() {
            Item.NewItem(npc.Center, npc.width, npc.height, mod.ItemType<Items.Misc.Twink>());
            if (NPC.downedAncientCultist) {
                if (Main.rand.Next(2) == 0) Item.NewItem(npc.position, npc.width, npc.height, mod.ItemType<Items.Misc.Titanite>());
            }
        }
    }
}