using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Ringed {
    [AutoloadEquip(EquipType.Head)]
    public class RingedHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ringed Knight Helmet");
            Tooltip.SetDefault("Apparel.");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 10;
            item.defense = 28;
        }

        public override void UpdateEquip(Player player) {
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.Ringed.RingedArmor>() && legs.type == mod.ItemType<Items.Armor.Ringed.RingedLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Unsealed Power");
            player.magicCrit += 95;
            player.rangedCrit += 95;
            player.meleeCrit += 95;
            player.thrownCrit += 95;
            player.magicDamage *= 2f;
            player.thrownDamage *= 2f;
            player.meleeDamage *= 2f;
            player.rangedDamage *= 2f;
            player.bulletDamage *= 2f;
            player.arrowDamage *= 2f;
            player.rocketDamage *= 2f;
            player.minionDamage *= 2f;
            player.manaCost *= 0.01f;
            player.statManaMax2 += 250;
            player.statLifeMax2 += 500;
            player.meleeSpeed *= 1.5f;
            player.endurance += 5;
            player.accRunSpeed += 5;
            player.jumpSpeedBoost += 4;
            player.moveSpeed += 0.20f;
            player.maxRunSpeed += 0.10f;
            player.thrownVelocity *= 2f;
            player.thrownCost50 = true;
            player.thrownCost33 = true;
            player.ammoCost80 = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.AddBuff(BuffID.Battle, 2);
            player.AddBuff(BuffID.WaterCandle, 2);
            player.armorPenetration += 20;
            player.onHitDodge = true;
            player.onHitRegen = true;
            player.buffImmune[BuffID.OnFire] = false;
            player.AddBuff(BuffID.OnFire, 2);
        }
        public override void ArmorSetShadows(Player player) {
            player.armorEffectDrawShadow = true;
            /*if (Main.rand.Next(3) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Smoke, 0, 0, 0, Color.Black);
                Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }*/
        }
        public override bool DrawHead() {
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Banners.RingedKnightBanner>(), 10);
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}