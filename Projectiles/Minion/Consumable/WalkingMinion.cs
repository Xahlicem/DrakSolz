using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    public abstract class WalkingMinion : CMinion {
        private int WalkFrameMod;
        private int WalkFrameLength;
        public float WalkSpeed { get; set; }
        public WalkingMinion(string itemType, float walkSpeed, int walkFrameLength, int walkFrames) : base(itemType) {
            WalkSpeed = walkSpeed;
            WalkFrameLength = walkFrameLength;
            WalkFrameMod = walkFrames * WalkFrameLength;
        }

        public const int State_Summon = 0;
        public const int State_Still = 1;
        public const int State_Move = 2;
        public const int State_Jump = 3;
        public const int State_Die = 4;

        public override void ChangeState(int state) {
            if (state == State_Jump) projectile.velocity.Y = -5;
            base.ChangeState(state);
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
                        if (CanJump()) {
                            ChangeState(State_Jump);
                        } else projectile.spriteDirection *= -1;
                    if (Ticks >= 30) ChangeState(State_Move);
                    break;
                case State_Move:
                    if (CollisionAhead()) {
                        if (CanJump()) ChangeState(State_Jump);
                        else ChangeState(State_Still);
                    }
                    if (HoleAhead() && CanJump())
                        ChangeState(State_Jump);
                    projectile.velocity.X = WalkSpeed * projectile.spriteDirection;
                    break;
                case State_Jump:
                    projectile.velocity.X = WalkSpeed * projectile.spriteDirection;
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

        public const int Frame_Jump = 0;
        public const int Frame_Summon_Offset = 1;
        public const int Frame_Walk_Offset = 6;

        public override int FindFrame() {
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
                    return (projectile.frameCounter % WalkFrameMod) / WalkFrameLength + Frame_Walk_Offset;
                case State_Jump:
                    return Frame_Jump;
                default:
                    return Frame_Walk_Offset;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            if (Math.Abs(oldVelocity.X) == 0 || Math.Abs(projectile.velocity.Y) > 0f) return false;
            if (oldVelocity.X != projectile.velocity.X) {
                if (CollisionAhead(oldVelocity)) ChangeState(State_Still);
                else projectile.velocity = new Vector2(projectile.oldVelocity.X, -2.5f);
            }
            return false;
        }
        public bool CollisionAhead(float velX, float velY) {
            int x = (int)((velX < 0 ? projectile.Left.X + 6 : projectile.Right.X - 6) + velX) / 16;
            int y = (int)(projectile.Bottom.Y - 9 + velY) / 16;
            int blockFeet = Main.tile[x, y].collisionType;
            int blockBody = Main.tile[x, y - 1].collisionType;
            int blockHead = Main.tile[x, y - 2].collisionType;
            int blockHead1 = Main.tile[x, y - 3].collisionType;

            if (blockHead > 0) return true;
            if (blockBody == 1 || blockBody == 2) return true;

            if (projectile.spriteDirection == -1) {
                if (blockBody == 4) return true;
                if (blockFeet == 3 && blockHead1 > 0) return true;
            }

            if (projectile.spriteDirection == 1) {
                if (blockBody == 3) return true;
                if (blockFeet == 4 && blockHead1 > 0) return true;
            }

            return false;
        }

        public bool CollisionAhead(Vector2 vel) {
            return CollisionAhead(vel.X, vel.Y);
        }

        public bool CollisionAhead() {
            return CollisionAhead(projectile.velocity);
        }

        public bool CanJump() {
            if (Math.Abs(projectile.velocity.Y) > 0.25f) return false;
            int x = (int)((projectile.spriteDirection == 1 ? projectile.Right.X - 6 : projectile.Left.X + 6)) / 16;
            int y = (int)(projectile.Top.Y + 6) / 16 - 1;
            int blockTop = Main.tile[x, y].collisionType;
            if (blockTop > 0) return false;

            x += projectile.spriteDirection;
            int blockAhead = Main.tile[x, y].collisionType;
            if ((projectile.spriteDirection == 1 && blockAhead == 4) || (projectile.spriteDirection == -1 && blockAhead == 3)) return true;
            if (blockAhead > 0) return false;

            return true;
        }

        public bool HoleAhead() {
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