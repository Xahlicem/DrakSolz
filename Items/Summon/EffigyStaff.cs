using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon {
    public class EffigyStaff : SoulItem {
        public EffigyStaff() : base(100) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Effigy Staff");
            Tooltip.SetDefault("Summons a humanity sprite to fight for you.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.RavenStaff);
            item.damage = 60;
            item.summon = true;
            item.mana = 70;
            item.scale = 1f;
            item.width = 28;
            item.height = 28;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item44;
            item.shoot = ModContent.ProjectileType<Projectiles.Minion.HumSumProj>();
            item.buffType = ModContent.BuffType<Buffs.HumSumBuff>();
            item.buffTime = 3600;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-4, 0);
        }

        public override bool AltFunctionUse(Player player) {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            return player.altFunctionUse != 2;
        }

        public override bool UseItem(Player player) {
            if (player.altFunctionUse == 2) {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
    }
}