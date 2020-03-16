using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class ArtoriasSoul : BossSoul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dark Soul");
            Tooltip.SetDefault("Soul of the Abyss Stalker");
        }

        public ArtoriasSoul() : base(16, 9999999, "RingTinyBeing") { }

        public override void AddRecipes() {
            new ArtoriasRecipe(mod, this).AddRecipe();
        }
    }

    public class ArtoriasRecipe : ModRecipe {
        public ArtoriasRecipe(Mod mod, BossSoul soul) : base(mod) {
            SetResult(ModContent.ItemType<Items.Melee.ArtoriasSword>());
            AddIngredient(soul);
            AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            AddIngredient(ModContent.ItemType<Items.Melee.Sword>());
        }

        public override bool RecipeAvailable() {
            if (Main.LocalPlayer == null) return false;
            foreach (Item i in Main.LocalPlayer.inventory) {
                if (i.type != ModContent.ItemType<Items.Melee.Sword>()) continue;
                return i.prefix == PrefixID.Legendary;
            }
            return false;
        }
    }
}