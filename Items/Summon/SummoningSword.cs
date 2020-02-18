using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Summon {
    public class SummoningSword : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Summoning Sword");
            Tooltip.SetDefault("Summons a Sword to slay your enemies.");
        }

        public override void SetDefaults() {
            item.CloneDefaults(ItemID.RavenStaff);
            item.damage = 1600;
            item.summon = true;
            item.mana = 250;
            item.scale = 1f;
            item.width = 28;
            item.height = 28;
            item.useStyle = 1;
            item.noMelee = false;
            item.knockBack = 10;
            item.value = Item.sellPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item44;
            item.shoot = ModContent.ProjectileType<Projectiles.Minion.SwordSumProj>();
            item.buffType = ModContent.BuffType<Buffs.SwordSumBuff>();
            item.buffTime = 3600;
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-4, 0);
        }
        
        public override bool CanUseItem(Player player) {
            float MSpeed = player.meleeSpeed * 10;
            item.useTime = (22 * ((int)MSpeed)) / 10;
            item.useAnimation = (22 * ((int)MSpeed)) / 10;
            return base.CanUseItem(player);
        }

        public override bool AltFunctionUse(Player player) {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            return player.altFunctionUse != 2;
        }

        public override bool UseItem(Player player) {
            if (player.altFunctionUse == 2) {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips) {
            tooltips.RemoveAt(tooltips.Count - 1);
        }
        public class SummoningSwordGlobalNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(50) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.Endgame.Dungeon.SwordofAkrane>() ) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Summon.SummoningSword>(), 1);
                    }
                }
            }
        }
    }
}