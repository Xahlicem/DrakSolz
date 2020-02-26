using System.Collections.Generic;
using System.Linq;
using DrakSolz;
using DrakSolz.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz {
    public class PyromancyItem : ModItem {
        public int PyromancyValue { get; internal set; }

        public PyromancyItem(int value) {
            PyromancyValue = value;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            if (PyromancyValue >= 1) {
                tooltips[0].text += " (" + PyromancyValue + " Souls required)";
            }
            var tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null) {
                // take reverse for 'damage',  grab translation
                string[] split = tt.text.Split(' ');
                // todo: translation alchemical
                tt.text = split.First() + " fire " + split.Last();
            }

            // todo: this can be removed when tmodloader updates
            if (item.crit > 0) {
                int crit = item.crit;
                GetWeaponCrit(Main.LocalPlayer, ref crit);
                tt = tooltips.FirstOrDefault(x => x.Name == "CritChance" && x.mod == "Terraria");
                if (tt != null) {
                    tt.text = crit + "% " + string.Join(" ", tt.text.Split(' ').Skip(1).ToArray());
                } else {
                    TooltipLine ttl = new TooltipLine(mod, "CritChance", crit + "% critical strike chance");
                    int index = tooltips.FindIndex(x => x.Name == "Damage" && x.mod == "Terraria");
                    if (index != -1) {
                        tooltips.Insert(index + 1, ttl);
                    }
                }
            }
        }

        public override void SetDefaults() {
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
            item.crit = 4;
        }

        public override void GetWeaponKnockback(Player player, ref float knockback) {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            knockback += modPlayer.pyromancyKbAddition;
            knockback *= modPlayer.pyromancyKbMult;
        }

        // todo: borked, tml requires update, manual work still needed
        public override void GetWeaponCrit(Player player, ref int crit) {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            crit += modPlayer.pyromancyCrit;
        }

        public override void GetWeaponDamage(Player player, ref int damage) {
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            // We want to multiply the damage we do by our alchemicalDamage modifier.
            // todo: ? do we want magic damage to also have effect here?
            damage = (int)(damage * modPlayer.pyromancyDamage + 5E-06f);
        }

        // todo: this can be removed when tmodloader updates
        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit) {
            int cc = item.crit;
            GetWeaponCrit(player, ref cc);
            crit = crit || Main.rand.Next(1, 101) <= cc;
        }

    }
}

public class PyromancyRecipe : ModRecipe {
    private int requiredSouls;
    public PyromancyRecipe(Mod mod, PyromancyItem result) : base(mod) {
        requiredSouls = result.PyromancyValue;
        SetResult(result);
    }

    public override bool RecipeAvailable() {
        return (Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().Souls >= requiredSouls);
    }

    public override void OnCraft(Item item) {
        Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().UpdateSouls(-requiredSouls);
    }
}