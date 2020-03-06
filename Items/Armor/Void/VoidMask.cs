using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Void {
    [AutoloadEquip(EquipType.Head)]
    public class VoidMask : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Void Mask");
            Tooltip.SetDefault("Contains powers of the endless abyss." +
                "\n+30% increased thrown crit" +
                "\n+10% increased thrown damage");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.Red;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.1f;
            player.thrownCrit += 30;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Void.VoidChest>() && legs.type == ModContent.ItemType<Items.Armor.Void.VoidLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Absence" +
                "\nGravity Control" +
                "\n+83% chance to not consume thrown weapons");
            player.AddBuff(BuffID.Featherfall, 2);
            player.gravControl = true;
            if (player.gravDir == -1) {
                player.thrownDamage *= 1.30f;
                player.thrownCrit += 15;
            }
            player.thrownCost50 = true;
            player.thrownCost33 = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Dazed] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.OgreSpit] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Webbed] = true;
            player.buffImmune[BuffID.WindPushed] = true;
            player.buffImmune[BuffID.VortexDebuff] = true;
        }
        public override void ArmorSetShadows(Player player) {
            player.armorEffectDrawOutlines = true;
            player.armorEffectDrawShadow = true;
            if (Main.rand.Next(3) == 0) {
                //Emit dusts when swing the sword
                int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Smoke, 0, 0, 0, Color.Black);
                Main.dust[dust].scale *= 0.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
            }
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.AddIngredient(ModContent.ItemType<Items.Misc.VoidFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}