using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon.Consumable {
    class PossesedArmorHelmet : CMinionItem {
        public PossesedArmorHelmet() : base(5000, "PossesedArmor") { }

        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Possesed Armor Helmet");
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.width = 20;
            item.height = 20;
            item.mana = 20;
            item.damage = 40;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.knockBack = 8f;
            item.rare = 5;
            item.shoot = ModContent.ProjectileType<Projectiles.Minion.Consumable.PossesedArmorHelmetProj>();
        }

        public override void AddRecipes() {
            SoulRecipe recipe = new SoulRecipe(mod, this);
            recipe.AddIngredient(ItemID.PossessedArmorBanner, 1);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            //recipe.AddIngredient(ItemID.Bone, 50);
            //recipe.AddRecipe();
        }
        /*public class ScrollSwordGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(20) == 0) {
                    if (npc.type == NPCID.PossessedArmor) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Summon.Consumable.PossesedArmorHelmet>(), 1);
                    }
                }
            }
        }*/
    }
}