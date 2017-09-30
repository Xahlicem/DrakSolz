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
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            ChangeState(State_Summon);
            projectile.frame = 19;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
            width = 20;
            height = 46;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
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
            State = state;
            Ticks = 0;
        }

        public override void AI() {
            projectile.friendly = true;
            Main.NewText(State.ToString());

            switch (State) {
                case State_Summon:
                case State_Die:
                    projectile.friendly = false;
                    if (Ticks >= 30) ChangeState(State_Still);
                    break;
                case State_Still:
                    if (Ticks >= 10) ChangeState(State_Move);
                    break;
                case State_Move:
                    projectile.velocity.X = 3;
                    //if (Ticks >= 10) ChangeState(State_Move);
                    break;
                default:
                    break;
            }
            if (projectile.timeLeft <= 30) ChangeState(State_Die);
            projectile.velocity.Y = 2;

            projectile.frame = FindFrame();
            Ticks++;
        }

        static readonly int[] summon = { 19, 18, 17, 16, 15, 1 };

        const int Frame_Walk_Offset = 1;

        private int FindFrame() {
            projectile.spriteDirection = projectile.direction;
            switch (State) {
                case State_Still:
                    return 1;
                case State_Summon:
                    return summon[(int) Ticks / 6];
                case State_Die:
                    return summon[5 - ((int) Ticks / 6)];
                case State_Move:
                    return ((int) Ticks % 69) / 5 + Frame_Walk_Offset;
                default:
                    return 20;
            }
        }
    }
}