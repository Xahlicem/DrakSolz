using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Minion.Consumable {
    public abstract class CMinion : ModProjectile {
        public string ItemType { get; set; }
        public CMinion(string itemType) {
            ItemType = itemType;
        }

        const int Tick_Slot = 0;
        const int State_Slot = 1;

        public float Ticks {
            get { return projectile.ai[Tick_Slot]; }
            set { projectile.ai[Tick_Slot] = value; }
        }

        public int State {
            get { return (int) projectile.ai[State_Slot]; }
            set { projectile.ai[State_Slot] = value; }
        }

        public virtual void ChangeState(int state) {
            State = state;
            projectile.frameCounter = -1;
            Ticks = 0;
        }

        public abstract int FindFrame();

        public override void Kill(int timeLeft) {
            int item = Item.NewItem((int) projectile.Bottom.X, (int) projectile.Center.Y + 8, 0, 0, DrakSolz.instance.ItemType(ItemType));
            Main.item[item].GetGlobalItem<Items.DSGlobalItem>().Owner = Main.player[projectile.owner].GetModPlayer<DrakSolzPlayer>().UID;
        }
    }
}