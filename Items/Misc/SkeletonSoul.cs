using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Misc {
    public class SkeletonSoul : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Skeleton Soul");
            Tooltip.SetDefault("Contains the powers of being dead!");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults() {
            //item.CloneDefaults(ItemID.RecallPotion);
            item.useTime = 120;
            item.useStyle = 4;
            item.maxStack = 1;
            item.rare = 0;
            item.consumable = true;
        }

        public override bool UseItem(Player player) {
            player.GetModPlayer<XahlicemPlayer>().ChangeRace(XahlicemPlayer.Race.Skeleton);
            return true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(mod.TileType<Items.Craft.FirelinkShrineTile>());
            recipe.AddIngredient(mod.ItemType<Items.Misc.SoulVessel>(), 1);
            recipe.AddIngredient(ItemID.Bone, 100);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}