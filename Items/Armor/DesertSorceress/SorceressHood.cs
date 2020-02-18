using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.DesertSorceress {
    [AutoloadEquip(EquipType.Head)]
    public class SorceressHood : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Desert Sorceress Hood");
            Tooltip.SetDefault("Clothing worn by Desert Sorceresses. So fashionable." +
                "\n+5% magic damage" +
                "\n+10% magic crit");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player) {
            //player.AddBuff(BuffID.NightOwl, 2);
            player.magicCrit += 10;
            player.magicDamage *= 1.05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.DesertSorceress.SorceressTop>() && legs.type == ModContent.ItemType<Items.Armor.DesertSorceress.SorceressSkirt>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Desert's Kiss" +
                "\n+10% magic damage" +
                "\n+5% magic crit" +
                "\n-20% mana cost" +
                "\n+ uses mana potions when low" +
                "\n+ 10 mana sickness cooldown" +
                "\n+immunity to On Fire");
            player.magicDamage *= 1.1f;
            player.manaCost *= 0.8f;
            player.magicCrit += 5;
            player.buffImmune[BuffID.OnFire] = true;
            player.manaFlower = true;
            player.manaSickReduction = 10;
        }
    }
}