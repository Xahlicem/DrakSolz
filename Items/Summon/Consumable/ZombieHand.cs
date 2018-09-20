using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon.Consumable {
    class ZombieHand : CMinionItem {
        public ZombieHand() : base(100, "Zombie") { }

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Zombie Hand");
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.width = 20;
            item.height = 20;
            item.mana = 5;
            item.damage = 10;
            item.value = Item.buyPrice(0, 0, 5, 0);
            item.rare = 1;
            item.shoot = mod.ProjectileType<Projectiles.Minion.Consumable.ZombieHandProj>();
        }

        public override void AddRecipes() {
            SoulRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddIngredient(ItemID.ZombieArm);
            recipe.AddRecipe();
        }
        public class ZombieHandDrop : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(16) == 0) {
                    if (npc.type == NPCID.Zombie|| npc.type == NPCID.ZombieRaincoat || npc.type == NPCID.ZombieEskimo) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ItemID.ZombieArm, 1);
                    }
                }
            }
        }
    }
}