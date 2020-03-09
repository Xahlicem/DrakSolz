using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Xanthous {
    [AutoloadEquip (EquipType.Body)]
    public class XanthousOvercoat : ModItem {
        public override void SetStaticDefaults () {
            base.SetStaticDefaults ();
            DisplayName.SetDefault ("Xanthous Overcoat");
            Tooltip.SetDefault ("Attire donned by Xanthous, the old monk." +
                "\n+6% fire damage and critical strike chance" +
                "\n+40 life");
        }

        public override void SetDefaults () {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice (0, 2, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 15;
        }

        public override void UpdateEquip (Player player) {
            player.GetModPlayer<MPlayer> ().pyromancyDamage += 0.06f;
            player.GetModPlayer<MPlayer> ().pyromancyCrit += 6;
            player.GetModPlayer<DrakSolzPlayer> ().MiscHP += 40;
        }
        public override void AddRecipes () {
            if (NPC.downedPlantBoss) {
                ModRecipe recipe = new ModRecipe (mod);
                recipe.AddIngredient (ModContent.ItemType<Items.Misc.InfernoBar> (), 18);
                recipe.AddTile (TileID.MythrilAnvil);
                recipe.SetResult (this);
                recipe.AddRecipe ();
            }
        }
    }
}