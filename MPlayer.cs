using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DrakSolz.Items;
using DrakSolz.Items.Magic;
using DrakSolz.Items.Magic.Pyro;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace DrakSolz {
    // Todo: transfer more to a general class
    public class MPlayer : ModPlayer {
        public static MPlayer GetModPlayer(Player player) => player.GetModPlayer<MPlayer>();

        // Buffs and debuffs
        public bool fragileContiion;

        // Pyromancer
        public float pyromancyDamage;
        public float pyromancyKbAddition;
        public float pyromancyKbMult;
        public int pyromancyCrit;

        // Undocumented
        public bool pyro;
        public bool nitro;
        public bool spirit;
        public bool enchanted;
        public bool glove;
        public bool core;
        public bool novaAura;
        public bool novaSet;
        public bool novaHelmet;
        public bool novaChestplate;

        public override void ResetEffects() {
            // Buffs and debuffs
            fragileContiion = false;

            // Alchemist
            pyromancyDamage = 1f;
            pyromancyKbAddition = 0f;
            pyromancyKbMult = 1f;
            pyromancyCrit = 0;

            // Undocumented
            pyro = false;
            nitro = false;
            spirit = false;
            enchanted = false;
            glove = false;
            core = false;
            novaAura = false;
            novaSet = false;
            novaHelmet = false;
            novaChestplate = false;
        }

        public override void PostUpdateMiscEffects() {
            // Reset conditions
            if (fragileContiion)
                player.statDefense = 0;
        }

    }
}