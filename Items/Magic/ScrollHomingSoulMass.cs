using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Magic {
    public class ScrollHomingSoulMass : SoulItem {
        public ScrollHomingSoulMass() : base(10000) { }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Homing Soul Mass");
            Tooltip.SetDefault("Conjures spheres of arcane energy to assualt foes.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.IceRod);
            item.damage = 30;
            item.magic = true;
            item.mana = 40;
            item.scale = 1f;
            item.width = 28;
            item.height = 28;
            item.useStyle = 4;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTime = 7;
            item.useAnimation = 35;
            item.knockBack = 0;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item44;
            item.shoot = ModContent.ProjectileType<Projectiles.Magic.SoulMassProj>();
            item.buffType = ModContent.BuffType<Buffs.SoulMassBuff>();
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

        public override void AddRecipes() {
            ModRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Scroll>());
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }
        /*public class SunWispStaffGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(80) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Ice.CrystalWisp>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Summon.CrystalStaff>(), 1);
                    }
                }
            }
        }*/
    }
}