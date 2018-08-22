using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class GibbetHead : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gibbet Head");
            Tooltip.SetDefault("Umm... I wouldn't wear this if I were you." +
                "\n???");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(50, 0, 0, 0);
            item.rare = 2;
            item.defense = 50;
        }

        public override void UpdateEquip(Player player) {
            player.meleeCrit += 50;
        }

        public override bool DrawHead() {
            return false;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.GibbetBody>() && legs.type == mod.ItemType<Items.Armor.GibbetLegs>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("I am become Gibbet" +
                "\nDestroyer of All");
            player.magicCrit += 10;
            player.rangedCrit += 10;
            player.meleeCrit += 10;
            player.thrownCrit += 10;
            player.magicDamage *= 1.20f;
            player.minionDamage *= 1.20f;
            player.thrownDamage *= 1.20f;
            player.thrownVelocity *= 1.3f;
            player.meleeDamage *= 1.20f;
            player.rangedDamage *= 1.20f;
            player.manaCost *= 0.80f;
            player.meleeSpeed *= 1.20f;
            player.statLifeMax2 += 100;
            player.statManaMax2 += 40;
            player.endurance += 5;
            player.accRunSpeed += 5;
            player.jumpSpeedBoost += 4;
            player.moveSpeed += 0.20f;
            player.maxRunSpeed += 0.10f;
            player.AddBuff(BuffID.Sharpened, 1);
            player.AddBuff(BuffID.Endurance, 1);
            player.AddBuff(BuffID.WeaponImbueVenom, 1);
            player.AddBuff(BuffID.Dangersense, 1);
            player.AddBuff(BuffID.Hunter, 1);
        }
        /*public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Misc.Titanite>(), 500);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}