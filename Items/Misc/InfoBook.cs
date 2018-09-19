using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Misc {
    public class InfoBook : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Book of Information");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.Pho);
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = 0;
            item.maxStack = 1;
            item.consumable = false;
        }
        public override bool UseItem(Player player) {
            player.AddBuff(BuffID.Confused, 15);
            item.alpha += 1;
            if (item.alpha == 1) {
                Main.NewText("122 - NPCs", 255, 0, 0);
            } else if (item.alpha == 2) {
                Main.NewText("002 - Bosses", 255, 255, 0);
            } else if (item.alpha == 3) {
                Main.NewText("002 - Friendly NPCs", 0, 255, 0);
            } else if (item.alpha == 4) {
                Main.NewText("025 - Accessories", 75, 150, 150);
            } else if (item.alpha == 5) {
                Main.NewText("051 - Armor(pieces)", 150, 75, 75);
            } else if (item.alpha == 6) {
                Main.NewText("014 - Melee Weapons", 150, 25, 0);
            } else if (item.alpha == 7) {
                Main.NewText("007 - Throwing Weapons", 150, 150, 0);
            } else if (item.alpha == 8) {
                Main.NewText("008 - Ranged Weapons", 0, 150, 0);
            } else if (item.alpha == 9) {
                Main.NewText("001 - Ammo", 0, 75, 0);
            } else if (item.alpha == 10) {
                Main.NewText("023 - Magic Weapons", 0, 0, 200);
            } else if (item.alpha == 11) {
                Main.NewText("017 - Summoning(Miracle) Weapons", 150, 0, 150);
            } else if (item.alpha == 12) {
                Main.NewText("003 - (Stand Alone)Spells", 0, 150, 150);
            } else if (item.alpha == 13) {
                Main.NewText("006 - Consumables", 0, 255, 255);
            } else if (item.alpha == 14) {
                Main.NewText("007 - Materials", 200, 200, 200);
            } else if (item.alpha == 15) {
                Main.NewText("002 - Structures", 150, 150, 150);
            } else if (item.alpha == 16) {
                Main.NewText("001 - Mounts", 75, 75, 0);
            } else if (item.alpha == 17) {
                Main.NewText("066 - Banners", 200, 150, 50);
            } else if (item.alpha == 18) {
                Main.NewText("018 - Buffs", 150, 255, 0);
            } else if (item.alpha == 19) {
                Main.NewText("001 - Pillar", 50, 50, 50);
                item.alpha = 0;
            }

            return true;
        }
    }
}