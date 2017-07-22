using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class MoonlightHead : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Helm");
            Tooltip.SetDefault("Armor forged with pure moonlight." +
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
            //player.AddBuff(BuffID.NightOwl, 2);
            player.magicCrit += 10;
            player.nightVision = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType("MoonlightChest") && legs.type == mod.ItemType("MoonlightLeggings");
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Moonlight Prayer" +
                "\n+20% Magic Damage" +
                "\n+100% Mana Cost" +
                "\n+Instant Mana Regen" +
                "\n+Immunity to Curse");
            player.magicDamage *= 1.2f;
            player.manaCost *= 2.0f;
            player.manaRegen += 60;
            player.manaRegenBuff = true;
            //player.AddBuff(BuffID.ManaRegeneration, 2);
            player.AddBuff(BuffID.Shine, 2);
            player.buffImmune[BuffID.Cursed] = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}