using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon {
    public class SoulSummonStaff : SoulItem {
        public SoulSummonStaff() : base(100) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul Staff");
            Tooltip.SetDefault("Summons a soul to fight for you.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.RavenStaff);
            item.damage = 5;
            item.summon = true;
            item.mana = 5;
            item.scale = 1f;
            item.width = 28;
            item.height = 28;
            item.useStyle = 5;
            item.noMelee = true;
            //item.knockBack = 0;
            item.value = Item.buyPrice(0, 0, 5, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType<Projectiles.Minion.SoulSummonProj>();
            item.buffType = mod.BuffType<Buffs.SoulSummonBuff>();
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

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips) {
            tooltips.RemoveAt(tooltips.Count - 1);
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddRecipe();
        }
    }
}