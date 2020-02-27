using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Hollow {
    [AutoloadEquip(EquipType.Body)]
    public class HollowShirt : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hollow Tatters");
            Tooltip.SetDefault("Increases movement speed by 5%" +
            "\ndecreases max life by 5");
        }

        public override void SetDefaults() {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.Gray;
            item.defense = 1;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed *= 1.05f;
            player.maxRunSpeed *= 1.05f;
            player.GetModPlayer<DrakSolzPlayer>().MiscHP -= 5;
        }
        public override void DrawHands(ref bool drawHands, ref bool drawArms){
            drawHands = true;
            drawArms = true;
        }

        public class HollowShirtNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(20) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow>() || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Arm>() ||
                    npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Armor>() || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Armor_Shirtless>() ||
                    npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Base>() || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Helmet>() ||
                    npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Pants>() || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Shirt>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.Hollow.HollowShirt>(), 1);
                    }
                }
            }
        }
    }
}