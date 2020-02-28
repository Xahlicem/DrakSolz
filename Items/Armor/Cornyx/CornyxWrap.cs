using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Cornyx {
    [AutoloadEquip(EquipType.Head)]
    public class CornyxWrap : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cornyx's Wrap");
            Tooltip.SetDefault("15% increased fire critical strike chance" +
                "\nReduces mana usage by 5%" +
                "\nincreases maximum mana by 50"  );
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 50;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 15;
            player.blind = true;
        }
        public override bool DrawHead() {
            return true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Cornyx.CornyxRobe>() && legs.type == ModContent.ItemType<Items.Armor.Cornyx.CornyxSkirt>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("15% increased fire damage" +
                "\nReduces mana usage by 25%" +
                "\nreduced damage taken from lava and immunity to on-fire effects");
            player.manaCost *= 0.75f;
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.15f;
            player.lavaRose = true;
            player.fireWalk = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.ShadowFlame] = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.InfernoBar>(), 15);
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}