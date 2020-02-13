using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Moonlight {
    [AutoloadEquip(EquipType.Head)]
    public class MoonlightHead : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Helm");
            Tooltip.SetDefault("Armor forged with pure moonlight." +
                "\nIncreases maximum mana by 40" +
                "\n10% increased magic damage and critical strike chance" +
                "\n+NightVision");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 9;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player) {
            player.statManaMax2 += 40;
            player.magicCrit += 10;
            player.magicDamage *= 1.10f;
            player.nightVision = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Moonlight.MoonlightChest>() && legs.type == ModContent.ItemType<Items.Armor.Moonlight.MoonlightLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Moonlight Prayer" +
                "\n+100% Magic Damage" +
                "\n+100% Mana Cost" +
                "\n+Instant Mana Regen" +
                "\n+Immunity to Curse");
            player.magicDamage *= 2.0f;
            player.manaCost *= 2.0f;
            player.manaRegen += 60;
            player.manaRegenBuff = true;
            //player.AddBuff(BuffID.ManaRegeneration, 2);
            player.AddBuff(BuffID.Shine, 2);
            player.buffImmune[BuffID.Cursed] = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.MoonButterflyHorn>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.Twink>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}