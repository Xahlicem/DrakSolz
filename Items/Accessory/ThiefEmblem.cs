using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Accessory {
    public class ThiefEmblem : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Thief's Emblem");
            Tooltip.SetDefault("15% increased throwing damage");
        }

        public override void SetDefaults() {
            item.width = 20;
            item.height = 20;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.thrownDamage += 0.15f;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessory.ThiefEmblem>());
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.SetResult(ItemID.AvengerEmblem);
            recipe.AddRecipe();
            /*recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WarriorEmblem);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SorcererEmblem);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RangerEmblem);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SummonerEmblem);
            recipe.SetResult(this);
            recipe.AddRecipe();*/
        }
    }

    public class ThiefEmblemDrop : GlobalNPC {
        public override bool PreNPCLoot(NPC npc) {
            if (npc.type == NPCID.WallofFlesh) {
                int[] weapons = { ItemID.BreakerBlade, ItemID.ClockworkAssaultRifle, ItemID.LaserRifle };
                int[] emblems = { ItemID.WarriorEmblem, ItemID.SorcererEmblem, ItemID.RangerEmblem, ItemID.SummonerEmblem, mod.ItemType<Items.Accessory.ThiefEmblem>() };
                if (Main.rand.NextBool())
                    Item.NewItem(npc.position, npc.width, npc.height, Utils.SelectRandom(Main.rand, weapons));
                else
                    Item.NewItem(npc.position, npc.width, npc.height, Utils.SelectRandom(Main.rand, emblems));
                foreach (int w in weapons) NPCLoader.blockLoot.Add(w);
                foreach (int e in emblems) NPCLoader.blockLoot.Add(e);
            }
            return true;
        }
    }

    public class ThiefEmblemBag : GlobalItem {
        public override bool PreOpenVanillaBag(string context, Player player, int arg) {
            if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag) {
                int[] weapons = { ItemID.BreakerBlade, ItemID.ClockworkAssaultRifle, ItemID.LaserRifle };
                int[] emblems = { ItemID.WarriorEmblem, ItemID.SorcererEmblem, ItemID.RangerEmblem, ItemID.SummonerEmblem, mod.ItemType<Items.Accessory.ThiefEmblem>() };

                if (!player.extraAccessory) player.QuickSpawnItem(ItemID.DemonHeart);
                if (Main.rand.Next(7) == 0) player.QuickSpawnItem(ItemID.FleshMask);
                player.QuickSpawnItem(ItemID.Pwnhammer);
                player.QuickSpawnItem(Utils.SelectRandom(Main.rand, weapons));
                player.QuickSpawnItem(Utils.SelectRandom(Main.rand, emblems));
                player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(6, 10));
                return false;
            } else return true;
        }
    }
}