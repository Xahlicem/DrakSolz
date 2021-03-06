using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class CrystalPet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Mysterious Crystal");
            Tooltip.SetDefault("Something is attracted to this...");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.shoot = ModContent.ProjectileType<Projectiles.Pets.CrystalLizardPet>();
            item.buffType = ModContent.BuffType<Buffs.CrystalLizardBuff>();
        }

        public override void UseStyle(Player player) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public class CrystalPetNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(20) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.CrystalLizard>() || npc.type == ModContent.NPCType<NPCs.Enemy.PostPlantera.GiantCrystalLizard>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Misc.CrystalPet>(), 1);
                    }
                }
            }
        }
    }
}