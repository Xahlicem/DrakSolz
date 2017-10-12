using System;
using Terraria;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class TitaniteHead : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Titanite Demon Head");
            Tooltip.SetDefault("Or lack thereof!" +
                "\n+50% increased melee Damage" +
                "\n+25% increased melee Crit" +
                "\n+ higher jumps" +
                "\n+ faster falls");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 9;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.jumpSpeedBoost += 5;
            player.maxFallSpeed *= 4;
            player.accDivingHelm = true;
            player.blind = true;
            player.meleeDamage *= 1.5f;
            player.meleeCrit += 25;
            player.headcovered = true;
        }

        public override bool DrawHead() {
            return false;
        }
    }
}