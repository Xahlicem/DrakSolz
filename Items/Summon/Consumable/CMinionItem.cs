using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon.Consumable {
    abstract class CMinionItem : SoulItem {
        public string MinionType { get; internal set; }
        public CMinionItem(int souls, string minionType) : base(souls) {
            MinionType = minionType;
        }

        public override void SetDefaults() {
            item.useStyle = 1;
            item.shootSpeed = 12f;
            item.maxStack = 5;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 25;
            item.useTime = 26;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.summon = true;
            item.knockBack = 5f;
            item.autoReuse = true;
        }

        public override bool CanPickup(Player player) {
            long fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().Owner;
            return (fromPlayer == -1) ? true : (player.GetModPlayer<DrakSolzPlayer>().UID == fromPlayer);
        }

        public override void GrabRange(Player player, ref int grabRange) {
            long fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().Owner;
            if (player.GetModPlayer<DrakSolzPlayer>().UID != fromPlayer) return;
            grabRange = (int) player.Distance(item.Center);
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[DrakSolz.instance.ProjectileType(MinionType)] + player.ownedProjectileCounts[item.shoot] < 5;
        }

        public override bool AltFunctionUse(Player player) {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if (player.altFunctionUse == 2) {
                speedY = 10;
                speedX *= 0.001f;
            }
            return true;
        }
    }
}