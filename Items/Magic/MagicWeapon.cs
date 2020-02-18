using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public abstract class MagicWeapon : ModItem {
        public float ManaCost { get; internal set; }
        public float useTime { get; internal set; }

        public MagicWeapon() {
            ManaCost = -1;
            useTime = -1;
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Magic Weapon!");
            Tooltip.SetDefault("MAGIC! WEAPON!");
        }

        public override bool CanUseItem(Player player) {
            if (useTime == -1) useTime = item.useTime;
            if (ManaCost == -1) ManaCost = item.mana;
            float MSpeed = player.meleeSpeed * 10;
            item.useTime = (int)(useTime * player.meleeSpeed);
            item.useAnimation = (int)(useTime * player.meleeSpeed);
            item.mana = 0;
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            item.mana = (int)ManaCost;
            if (player.statMana >= ManaCost * player.manaCost) {
                player.statMana -= (int)(ManaCost * player.manaCost);
                return true;
            }
            return false;
        }
    }
}