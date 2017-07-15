using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace XahlicemMod.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class MoonlightHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Armor forged with pure moonlight."
                + "\n+NightVision");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000000;
            item.rare = 9;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.AddBuff(BuffID.NightOwl, 2);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MoonlightChest") && legs.type == mod.ItemType("MoonlightLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = ("Moonlight Prayer"
                + "\n+20% Magic Damage"
                + "\n+60 Max Mana"
                + "\n+100% Mana Cost"
                + "\n+Instant Mana Regen"
                + "\n+20% Max Life"
                + "\n+Immunity to Curse");
            player.magicDamage *= 1.2f;
            player.statManaMax2 += 60;
            player.manaCost *= 2.0f;
            player.manaRegen += 60;
            player.AddBuff(BuffID.ManaRegeneration, 2);
            player.AddBuff(BuffID.Shine, 2);
            player.buffImmune[BuffID.Cursed] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

