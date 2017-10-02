using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion {
    public class SkeletonSummon : ModProjectile {
        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 20;
            DisplayName.SetDefault("Skeleton");
        }

        public override void SetDefaults() {
            projectile.netImportant = true;
            projectile.aiStyle = 0;
            projectile.width = 40;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            ChangeState(State_Summon);
            projectile.frame = 19;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 20;
            height = 46;
            fallThrough = false;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            if (Math.Abs(oldVelocity.X) == 0 || Math.Abs(projectile.velocity.Y) > 0.25f) return false;
            if (oldVelocity.X != projectile.velocity.X) {
                if (CollisionAhead(oldVelocity)) ChangeState(State_Still);
                else projectile.velocity = new Vector2(projectile.oldVelocity.X, -2.5f);
            }
            return false;
        }

        const int Tick_Slot = 0;

        const int State_Slot = 1;
        const int State_Summon = 0;
        const int State_Still = 1;
        const int State_Move = 2;
        const int State_Jump = 3;
        const int State_Die = 4;

        float Ticks {
            get { return projectile.ai[Tick_Slot]; }
            set { projectile.ai[Tick_Slot] = value; }
        }

        int State {
            get { return (int) projectile.ai[State_Slot]; }
            set { projectile.ai[State_Slot] = value; }
        }

        void ChangeState(int state) {
            if (state == State_Jump) projectile.velocity.Y = -5;
            State = state;
            projectile.frameCounter = -1;
            Ticks = 0;
        }

        public override void AI() {
            projectile.friendly = true;

            switch (State) {
                case State_Summon:
                case State_Die:
                    projectile.friendly = false;
                    projectile.velocity.X = 0f;
                    if (Ticks % 12 == 2)
                        for (int i = 0; i < 10; i++) Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 46), projectile.width, 10, DustID.Dirt, 2 * (Main.rand.NextFloat() - 0.5f), 1 * (Main.rand.NextFloat() - 1.5f));
                    if (Ticks >= 60) ChangeState(State_Move);
                    break;
                case State_Still:
                    if (!CollisionAhead(projectile.spriteDirection, 0)) ChangeState(State_Move);
                    projectile.velocity.X = 0f;
                    if (Ticks == 15)
                        if (Main.rand.NextBool() && CanJump()) {
                            ChangeState(State_Jump);
                        } else projectile.spriteDirection *= -1;
                    if (Ticks >= 30) ChangeState(State_Move);
                    break;
                case State_Move:
                    if ((CollisionAhead() || HoleAhead()) && CanJump())
                        ChangeState(State_Jump);
                    projectile.velocity.X = 2.5f * projectile.spriteDirection;
                    break;
                case State_Jump:
                    projectile.velocity.X = 2 * projectile.spriteDirection;
                    if (projectile.velocity.Y != 0) Ticks = 0;
                    if (Ticks >= 5) ChangeState(State_Move);
                    break;
                default:
                    break;
            }

            projectile.velocity.Y += 0.25f;
            if (projectile.velocity.Y > 9f) projectile.velocity.Y = 9f;

            if (projectile.timeLeft == 60) ChangeState(State_Die);
            if (projectile.velocity.Y != 0.25f && (State == State_Die || State == State_Summon)) {
                projectile.timeLeft++;
                return;
            }

            projectile.frame = FindFrame();
            Ticks++;
        }

        const int Frame_Jump = 0;
        const int Frame_Summon_Offset = 1;
        const int Frame_Walk_Offset = 6;

        private int FindFrame() {
            projectile.frameCounter++;

            if (Math.Abs(projectile.velocity.Y) >= 4f) return Frame_Jump;
            switch (State) {
                case State_Still:
                    return Frame_Walk_Offset;
                case State_Summon:
                    return projectile.frameCounter / 10 + Frame_Summon_Offset;
                case State_Die:
                    return Frame_Walk_Offset - 1 - (projectile.frameCounter / 10) + Frame_Summon_Offset;
                case State_Move:
                    return (projectile.frameCounter % 69) / 5 + Frame_Walk_Offset;
                case State_Jump:
                    return Frame_Jump;
                default:
                    return Frame_Walk_Offset;
            }
        }

        public override void Kill(int timeLeft) {
            Item.NewItem(projectile.Bottom, Vector2.Zero, mod.ItemType<Items.Summon.SkeletonSkull>());
        }

        private bool CollisionAhead(float velX, float velY) {
            int x = (int)(-1 + (velX < 0 ? projectile.Left.X : projectile.Right.X) + velX) / 16;
            int y = (int)(projectile.Bottom.Y - 9 + velY) / 16;
            int blockFeet = Main.tile[x, y].collisionType;
            int blockBody = Main.tile[x, y - 1].collisionType;
            int blockHead = Main.tile[x, y - 2].collisionType;

            Main.NewText(blockFeet + " " + blockBody + " " + blockHead);

            if (blockHead > 0) return true;
            if (blockFeet == 1 && (blockBody == 1 || blockBody == 2)) return true;
            if (projectile.spriteDirection == -1 && blockBody == 4) return true;
            if (projectile.spriteDirection == 1 && blockBody == 3) return true;

            return false;
        }

        private bool CollisionAhead(Vector2 vel) {
            return CollisionAhead(vel.X, vel.Y);
        }

        private bool CollisionAhead() {
            return CollisionAhead(projectile.velocity);
        }

        private bool CanJump() {
            if (Math.Abs(projectile.velocity.Y) > 0.25f) return false;
            int x = (int)((projectile.spriteDirection == 1 ? projectile.Right.X : projectile.Left.X)) / 16;
            int y = (int)(projectile.Top.Y) / 16 - 1;
            int blockTop = Main.tile[x, y].collisionType;
            x += projectile.spriteDirection;
            int blockAhead = Main.tile[x, y].collisionType;

            if (blockTop > 0) return false;
            if (blockAhead > 0) return false;

            return true;
        }

        private bool HoleAhead() {
            int x = (int)((projectile.spriteDirection == 1 ? projectile.Right.X : projectile.Left.X)) / 16 + projectile.spriteDirection;
            int y = (int)(projectile.Bottom.Y) / 16;
            int blockAhead = Main.tile[x, y++].collisionType;
            int blockAhead1 = Main.tile[x, y++].collisionType;
            int blockAhead2 = Main.tile[x, y++].collisionType;
            int blockAhead3 = Main.tile[x, y++].collisionType;

            if (blockAhead == 0 && blockAhead1 == 0 && blockAhead2 == 0 && blockAhead3 == 0) return true;

            return false;
        }
    }
}