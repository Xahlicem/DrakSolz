using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Magic.Holy {
    public class DivineSpearFragment : SoulItem {
        public DivineSpearFragment() : base(40000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Divine Spear Fragment");
            Tooltip.SetDefault("Miracle that conjurs sacred spears from beneath to rise to the heavens. Deals x2 damage when above 50% mana.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Flamelash);
            item.useStyle = 4;
            item.noUseGraphic = true;
            item.damage = 25;
            if (NPC.downedMechBoss2 || NPC.downedMechBoss3){
            item.damage = 29;
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3){
            item.damage = 32;
            }
            if (NPC.downedPlantBoss){
            item.damage = 37;
            }
            if (NPC.downedGolemBoss){
            item.damage = 40;
            }
            if (NPC.downedAncientCultist){
            item.damage = 45;
            }
            item.useTime = 30;
            item.useAnimation = 30;
            item.mana = 25;
            item.knockBack = 3.5f;
            item.shootSpeed = 8.0f;
            item.crit = 8;
            item.value = Item.buyPrice(0, 18, 0, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.HolySpearProj2>();
            item.summon = true;
            item.magic = false;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Magic.Holy.RitualSpearFragment>());
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            float direction = Main.mouseX - Main.screenWidth / 2;
            int pro = Projectile.NewProjectile((player.Center.X + (60 * (direction >= 0 ? 1 : -1))), player.Center.Y + 40, 1 * (direction >= 0 ? 1 : -1), 0, type, (int)(damage * 0.60f), 0, player.whoAmI, player.Center.Y);
            Main.projectile[pro].frame = 1;
            if (player.statMana >= (((player.statManaMax2) * 0.5) - (item.mana * player.manaCost))) {
                Main.projectile[pro].damage *= 2;
                Main.projectile[pro].knockBack *= 2;
            } else {
                Main.projectile[pro].damage *= 1;
                Main.projectile[pro].ai[1] += 3;
            }
            return false;
        }
    }
}