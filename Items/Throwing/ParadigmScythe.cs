using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items.Throwing {
    public class ParadigmScythe : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Paradigm Scythe");
            Tooltip.SetDefault("Scythe attached by a powerful thread." +
                "\n???.");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.Terrarian);
            item.useStyle = 5;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shootSpeed = 16f;
            item.knockBack = 5.5f;
            item.damage = 1000;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = 0;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.thrown = true;
            item.shoot = mod.ProjectileType<Projectiles.ParadigmScytheProj>();
        }
    }
        public class ParadigmScytheGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(15) == 0) {
                    if (npc.type == mod.NPCType<NPCs.Enemy.Endgame.Desert.Paradigm>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType<Items.Throwing.ParadigmScythe>(), 1);
                    }
                }
            }
        }
}