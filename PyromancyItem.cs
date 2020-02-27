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
    public class PyromancyItem : GlobalItem {

        public bool FireWeapon(Item item) { return (item.melee || item.magic || item.ranged || item.thrown || item.summon); }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (FireWeapon(item)) return;
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
                GetWeaponCrit(item, Main.LocalPlayer, ref crit);
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

        public override void SetDefaults(Item item) {
            if (FireWeapon(item)) return;
            //item.crit = 4;
        }

        public override void GetWeaponKnockback(Item item, Player player, ref float knockback) {
            if (FireWeapon(item)) return;
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            knockback += modPlayer.pyromancyKbAddition;
            knockback *= modPlayer.pyromancyKbMult;
        }

        // todo: borked, tml requires update, manual work still needed
        public override void GetWeaponCrit(Item item, Player player, ref int crit) {
            if (FireWeapon(item)) return;
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            crit += modPlayer.pyromancyCrit;
        }

        public override void GetWeaponDamage(Item item, Player player, ref int damage) {
            if (FireWeapon(item)) return;
            MPlayer modPlayer = MPlayer.GetModPlayer(player);
            // We want to multiply the damage we do by our alchemicalDamage modifier.
            // todo: ? do we want magic damage to also have effect here?
            damage = (int)(damage * modPlayer.pyromancyDamage + 5E-06f);
        }

        // todo: this can be removed when tmodloader updates
        public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit) {
            if (FireWeapon(item)) return;
            int cc = item.crit;
            GetWeaponCrit(item, player, ref cc);
            crit = crit || Main.rand.Next(1, 101) <= cc;
        }

    }
}