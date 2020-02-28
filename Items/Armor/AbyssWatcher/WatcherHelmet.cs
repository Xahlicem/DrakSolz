using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.AbyssWatcher {
    [AutoloadEquip(EquipType.Head)]
    public class WatcherHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Watcher's Helmet");
            Tooltip.SetDefault("10% increased fire and melee damage");
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player) {
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.10f;
            player.meleeDamage += 0.10f;
        }
        public override bool DrawHead() {
            return true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherChest>() && legs.type == ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("15% increased fire and melee damage" +
                "\n5% increased critical strike chance" +
                "\nweapons apply fire on hit" +
                "\n15 increased defense while on fire");
			player.GetModPlayer<MPlayer>().pyromancyDamage += 0.15f;
			player.meleeDamage += 0.15f;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 5;
            player.meleeCrit += 5;
            player.magicCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
            player.AddBuff(BuffID.WeaponImbueFire, 1);
            if (player.HasBuff(BuffID.OnFire) || player.HasBuff(BuffID.Frostburn) || player.HasBuff(BuffID.ShadowFlame) || player.HasBuff(BuffID.CursedInferno)){
                player.statDefense += 15;
            }
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.InfernoBar>(), 12);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
    }
}