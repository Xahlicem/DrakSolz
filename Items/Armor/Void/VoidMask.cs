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
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 10;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player) {
            player.thrownDamage *= 1.1f;
            player.thrownCrit += 30;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType<Items.Armor.Void.VoidChest>() && legs.type == mod.ItemType<Items.Armor.Void.VoidLeggings>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Absence" +
                "\n+Immunity to all debuffs" +
                "\n+83% chance to not consume thrown weapons" +
                "\n+");
            player.thrownCost50 = true;
            player.thrownCost33 = true;
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.ChaosState] = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Darkness] = true;
            player.buffImmune[BuffID.Dazed] = true;
            player.buffImmune[BuffID.Electrified] = true;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Horrified] = true;
            player.buffImmune[BuffID.Ichor] = true;
            //player.buffImmune[BuffID.ManaSickness] = true;
            player.buffImmune[BuffID.MoonLeech] = true;
            player.buffImmune[BuffID.NoBuilding] = true;
            player.buffImmune[BuffID.OgreSpit] = true;
            player.buffImmune[BuffID.Oiled] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            //player.buffImmune[BuffID.PotionSickness] = true;
            player.buffImmune[BuffID.Rabies] = true;
            player.buffImmune[BuffID.ShadowFlame] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Slimed] = true;
            player.buffImmune[BuffID.Stinky] = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Suffocation] = true;
            player.buffImmune[BuffID.TheTongue] = true;
            player.buffImmune[BuffID.Venom] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.Webbed] = true;
            player.buffImmune[BuffID.Wet] = true;
            player.buffImmune[BuffID.WindPushed] = true;
            player.buffImmune[BuffID.WitheredArmor] = true;
            player.buffImmune[BuffID.WitheredWeapon] = true;
            player.buffImmune[BuffID.VortexDebuff] = true;
            player.buffImmune[BuffID.SoulDrain] = true;
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
            recipe.AddIngredient(mod.ItemType<Items.Misc.VoidFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}