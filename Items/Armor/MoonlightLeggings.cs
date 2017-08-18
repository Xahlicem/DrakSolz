using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Armor {
    [AutoloadEquip(EquipType.Legs)]
    public class MoonlightLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Moonlight Leggings");
            Tooltip.SetDefault("Armor forged with pure moonlight." +
                "\n+Water Walking" +
                "\n10% increased movement speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 9;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed += 0.10f;
            player.waterWalk = true;
            //player.AddBuff(BuffID.WaterWalking, 2);
        }
    }
}