using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Tattered {
    [AutoloadEquip(EquipType.Head)]
    public class TatteredHat : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Tattered Hat");
            Tooltip.SetDefault("Increases maximum mana by 20");
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 20;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair) {
            drawHair = false;
            drawAltHair = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Tattered.TatteredTunic>() && legs.type == ModContent.ItemType<Items.Armor.Tattered.TatteredBoots>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("10% increased miracle damage" +
                "\nReduces mana usage by 10%");
            player.minionDamage *= 1.10f;
            player.manaCost *= 0.9f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.TatteredCloth, 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddRecipe();
        }
    }

    class BannerMod : GlobalRecipe {
        public override bool RecipeAvailable(Recipe recipe) {
            if (recipe.createItem.type == ItemID.GoblinBattleStandard) return false;
            return base.RecipeAvailable(recipe);
        }
    }

    class TatteredMod : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.GoblinArcher || npc.type == NPCID.GoblinPeon || npc.type == NPCID.GoblinThief || npc.type == NPCID.GoblinWarrior || npc.type == NPCID.GoblinSorcerer || npc.type == NPCID.GoblinSummoner) {
                Item.NewItem(npc.position, npc.width, npc.height, ItemID.TatteredCloth);
            }
            if (npc.type == NPCID.GoblinScout && Main.rand.Next(3) == 0) Item.NewItem(npc.position, npc.width, npc.height, ItemID.GoblinBattleStandard);
        }
    }
}