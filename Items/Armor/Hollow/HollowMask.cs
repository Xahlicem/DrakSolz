using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Armor.Hollow {
    [AutoloadEquip(EquipType.Head)]
    public class HollowMask : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Hollow Mask");
            Tooltip.SetDefault("Increases movement speed by 5%");
        }

        public override void SetDefaults() {
            item.width = 40;
            item.height = 28;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.Gray;
            item.defense = 1;
        }

        public override void UpdateEquip(Player player) {
            player.moveSpeed *= 1.05f;
        }
        public override bool DrawHead() {
            return true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == ModContent.ItemType<Items.Armor.Hollow.HollowShirt>() && legs.type == ModContent.ItemType<Items.Armor.Hollow.HollowLoin>();
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = ("Fleeting Humanity" +
                "\nIncreases movement speed by 10%");
            player.moveSpeed *= 1.10f;
            player.maxRunSpeed *= 1.10f;
        }

        public class HollowMaskNPC : GlobalNPC {
            public override void NPCLoot(NPC npc) {
                if (Main.rand.Next(20) == 0) {
                    if (npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow>() || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Arm>() ||
                    npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Armor>() || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Armor_Shirtless>() ||
                    npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Base>() || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Helmet>() ||
                    npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Pants>() || npc.type == ModContent.NPCType<NPCs.Enemy.PreHardMode.Hollow.Hollow_Shirt>()) {
                        Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.Hollow.HollowMask>(), 1);
                    }
                }
            }
        }
    }
}