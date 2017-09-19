using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class HomewardBone : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Homeward Bone");
            Tooltip.SetDefault("Returns one to their place of belonging.");
        }

        public override void SetDefaults() {
            item.useTime = 120;
            item.useStyle = 4;
            item.maxStack = 99;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = 2;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.FindSpawn();
            if (player.SpawnX == -1) return false;
            if (Main.tile[player.SpawnX, player.SpawnY].type != mod.TileType<Tiles.FirelinkShrineTile>()) {
                return false;
            }
            player.AddBuff(mod.BuffType<Buffs.Homeward>(), 100);
            return true;
        }

        public class GreenBlossomGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == NPCID.Zombie || npc.type == NPCID.BaldZombie || npc.type == NPCID.ArmedZombie ||
                        npc.type == NPCID.BigBaldZombie || npc.type == NPCID.ZombieDoctor ||
                        npc.type == NPCID.ArmedZombieEskimo || npc.type == NPCID.SlimedZombie ||
                        npc.type == NPCID.SmallZombie || npc.type == NPCID.ArmedZombieSlimed ||
                        npc.type == NPCID.BigFemaleZombie || npc.type == NPCID.BigSlimedZombie ||
                        npc.type == NPCID.ArmedZombiePincussion || npc.type == NPCID.ArmedZombieSwamp ||
                        npc.type == NPCID.ArmedZombieTwiggy || npc.type == NPCID.BigPincushionZombie ||
                        npc.type == NPCID.BigSwampZombie || npc.type == NPCID.BigTwiggyZombie ||
                        npc.type == NPCID.BigZombie || npc.type == NPCID.SmallBaldZombie ||
                        npc.type == NPCID.SmallFemaleZombie || npc.type == NPCID.SmallPincushionZombie ||
                        npc.type == NPCID.SmallSlimedZombie || npc.type == NPCID.SmallSwampZombie ||
                        npc.type == NPCID.SmallTwiggyZombie || npc.type == NPCID.SwampZombie ||
                        npc.type == NPCID.TwiggyZombie || npc.type == NPCID.PincushionZombie ||
                        npc.type == NPCID.FemaleZombie || npc.type == NPCID.ArmedZombieCenx)

                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Misc.HomewardBone>(), 1);

                }
            }
        }
    }

}