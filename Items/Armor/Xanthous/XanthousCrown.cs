using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Xanthous {
    [AutoloadEquip (EquipType.Head)]
    public class XanthousCrown : ModItem {
        public override void SetStaticDefaults () {
            DisplayName.SetDefault ("Xanthous Crown");
            Tooltip.SetDefault ("Attire donned by Xanthous, the old monk." +
                "\n+6% fire damage" +
                "\n+60 mana");
        }

        public override void SetDefaults () {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice (0, 2, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 18;
        }

        public override void UpdateEquip (Player player) {
            player.GetModPlayer<MPlayer> ().pyromancyDamage += 0.06f;
            player.statManaMax2 += 60;
        }

        public override bool IsArmorSet (Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Xanthous.XanthousOvercoat> () && legs.type == ModContent.ItemType<Items.Armor.Xanthous.XanthousWaistcloth> ();
        }

        public override void UpdateArmorSet (Player player) {
            player.setBonus = ("Yellow Madness" +
                "\n+10% fire damage" +
                "\n30% reduced mana cost" +
                "\nfirewalking");
            player.GetModPlayer<MPlayer> ().pyromancyDamage += 0.10f;
            player.manaCost *= 0.7f;
            player.fireWalk = true;
        }
        public override bool DrawHead () {
            return false;
        }
        public override void AddRecipes () {
            if (NPC.downedPlantBoss) {
                ModRecipe recipe = new ModRecipe (mod);
                recipe.AddIngredient (ModContent.ItemType<Items.Misc.InfernoBar> (), 20);
                recipe.AddTile (TileID.MythrilAnvil);
                recipe.SetResult (this);
                recipe.AddRecipe ();
            }
        }
    }
}