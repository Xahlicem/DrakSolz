using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace XahlicemMod.Items
{
    [AutoloadEquip(EquipType.Head)]
    public class ChannelerHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Description!"
                + "\n+NightVision");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 5000000;
            item.rare = 9;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.AddBuff(BuffID.NightOwl, 2);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ChannelerRobe") && legs.type == mod.ItemType("ChannelerSkirt");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = ("Moonlight Prayer"
                + "\n+20% Magic Damage"
                + "\n+20% Melee Damage"
                + "\n+60 Max Mana"
                + "\n-20% Mana Cost"
                + "\n+Channeler's Perfect Dance"
                + "\n+20% Max Life"
                + "\n+Immunity to Curse");
            player.magicDamage *= 1.2f;
            player.meleeDamage *= 1.2f;
            player.statManaMax2 += 60;
            player.manaCost *= 0.8f;
            player.manaRegen += 60;
            player.AddBuff(mod.BuffType("ChannelBuff2"), 2);
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

