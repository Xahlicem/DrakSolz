using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Melee {
    public class Sword : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sword");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.PlatinumPickaxe);
            item.tileBoost = -2;
            item.pick = 60;
            item.axe = 100;
            item.damage = 60;
            item.knockBack = 20f;
            item.scale = 0.75f;
            item.GetGlobalItem<DSGlobalItem>().Restricted = true;
        }

        public override bool CanUseItem(Player player) {
            if (item.GetGlobalItem<DSGlobalItem>().Used) {
                foreach (Item i in player.inventory)
                    if (i == item) {
                        i.netDefaults(ModContent.ItemType<Items.Melee.SwordHilt>());
                        i.Prefix(PrefixID.Broken);
                        i.GetGlobalItem<DSGlobalItem>().Owner = player.GetModPlayer<DrakSolzPlayer>().UID;
                        i.GetGlobalItem<DSGlobalItem>().Restricted = true;
                        i.GetGlobalItem<DSGlobalItem>().Owned = true;
                        i.rare = -1;
                    }
                Gore.NewGore(player.Center, Vector2.Zero, mod.GetGoreSlot("Gores/Sword/Hilt"), 1f);
                Gore.NewGore(player.Center, Vector2.Zero, mod.GetGoreSlot("Gores/Sword/Blade0"), 1f);
                Gore.NewGore(player.Center, Vector2.Zero, mod.GetGoreSlot("Gores/Sword/Blade1"), 1f);
                Gore.NewGore(player.Center, Vector2.Zero, mod.GetGoreSlot("Gores/Sword/Blade2"), 1f);
                Main.PlaySound(SoundID.Shatter, player.Center);
            } else Main.PlaySound(SoundID.Item, player.Center, 37);
            return true;
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips) {
            if (item.GetGlobalItem<DSGlobalItem>().Used) tooltips.Add(new TooltipLine(mod, "Tooltip", "Something seems wrong..."));
            else tooltips.Add(new TooltipLine(mod, "Tooltip", "Thank goodness you didn't start with a copper pickaxe!"));

            if (item.GetGlobalItem<DSGlobalItem>().Owned) return;
            tooltips[0].text += " (Legendary required)";
        }
    }
}