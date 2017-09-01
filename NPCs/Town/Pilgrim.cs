using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace XahlicemMod.NPCs.Town {
    [AutoloadHead]
    public class Pilgrim : ModNPC {
        /*public override string Texture
        {
            get
            {
                return "XahlicemMod/NPCs/Pilgrim";
            }
        }

        public override string[] AltTextures
        {
            get
            {
                return new string[] { "XahlicemMod/NPCs/Pilgrim_Alt_1" };
            }
        }*/

        public override bool Autoload(ref string name) {
            name = "Pilgrim";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pilgrim");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override void HitEffect(int hitDirection, double damage) {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++) {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Smoke);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            bool soul = false, lantern = false;
            for (int k = 0; k < 255; k++) {
                Player player = Main.player[k];
                if (player.active) {
                    for (int j = 0; j < player.inventory.Length; j++) {
                        if (player.inventory[j].type == mod.ItemType("Soul")) soul = true;
                        if (player.inventory[j].type == mod.ItemType("HomewardBone")) lantern = true;
                    }
                }
            }
            return soul && lantern;
        }

        public override bool CheckConditions(int left, int right, int top, int bottom) {
            return true;
        }

        public override string TownNPCName() {
            switch (WorldGen.genRand.Next(4)) {
                case 0:
                    return "Yoel";
                case 1:
                    return "Anri";
                case 2:
                    return "Artorias";
                default:
                    return "Gael";
            }
        }

        public override string GetChat() {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.Next(4) == 0) {
                chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
            }
            chat.Add("Oh, sweet champion, you've returned.");
            chat.Add("May the dark sigil guide your way.");
            chat.Add("Stay safe champion.");

            return chat.Get();
        }

        public override void SetChatButtons(ref string button, ref string button2) {
            button = Language.GetText("Shop").Value;
            XahlicemPlayer player = Main.LocalPlayer.GetModPlayer<XahlicemPlayer>();
            if (player.Souls >= player.SoulCost) button2 = "Level Up!";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
            if (firstButton) {
                shop = true;
            } else {
                Main.NewText("Level Up!!!", Colors.CoinGold);
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot) {
            shop.item[nextSlot].SetDefaults(mod.ItemType("ScrollHolyHomeward"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("GreenBlossom"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("HomewardBone"));
            shop.item[nextSlot].shopCustomPrice = new int ? (100);
            shop.item[nextSlot].shopSpecialCurrency = XahlicemMod.SoulCustomCurrencyID;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("Lifegem"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("PrismStone"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("ScrollSoulDart"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingCloranthy"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingBlades"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingTinyBeing"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Silk);
            nextSlot++;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
            projType = ProjectileID.BoneDagger;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}