using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Father {
    [AutoloadEquip(EquipType.Head)]
    public class FatherMask : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Father Mask");
            Tooltip.SetDefault("The best looking mask in the game.\n" +
                "5% increased critical strike chance\n" +
                "5% increased damage");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = ItemRarityID.Red;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player) {
            player.magicCrit += 5;
            player.rangedCrit += 5;
            player.meleeCrit += 5;
            player.thrownCrit += 5;
            player.allDamage *= 1.05f;
            player.thrownVelocity *= 1.2f;

        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Father.GiantArmor>() && legs.type == ModContent.ItemType<Items.Armor.Father.GiantLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("He's Back!" +
                "\nTHE LEGEND NEVER DIES");
            player.magicCrit += 10;
            player.rangedCrit += 10;
            player.meleeCrit += 10;
            player.thrownCrit += 10;
			player.GetModPlayer<MPlayer>().pyromancyCrit += 10;
            player.allDamage *= 1.20f;
            player.thrownVelocity *= 1.3f;
            player.manaCost *= 0.80f;
            player.meleeSpeed *= 1.20f;
            player.GetModPlayer<DrakSolzPlayer>().MiscHP += 100;
            player.statManaMax2 += 40;
            player.accRunSpeed += 5;
            player.jumpSpeedBoost += 4;
            player.moveSpeed += 0.20f;
            player.maxRunSpeed += 0.10f;
            player.AddBuff(BuffID.Sharpened, 1);
            player.AddBuff(BuffID.Endurance, 1);
            player.AddBuff(BuffID.WeaponImbueFire, 1);
            player.AddBuff(BuffID.Dangersense, 1);
            player.AddBuff(BuffID.Hunter, 1);
        }
    }
}