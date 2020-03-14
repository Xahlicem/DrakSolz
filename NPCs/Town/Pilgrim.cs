using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace DrakSolz.NPCs.Town {
    [AutoloadHead]
    public class Pilgrim : ModNPC {
        /*public override string Texture
        {
            get
            {
                return "DrakSolz/NPCs/Pilgrim";
            }
        }

        public override string[] AltTextures
        {
            get
            {
                return new string[] { "DrakSolz/NPCs/Pilgrim_Alt_1" };
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
            return true;
        }

        public override bool CheckConditions(int left, int right, int top, int bottom) {
            return true;
        }

        public override string TownNPCName() {
            switch (WorldGen.genRand.Next(4)) {
                case 0:
                    return "Yoel";
                case 1:
                    return "Manus";
                case 2:
                    return "Pigmy";
                default:
                    return "Gael";
            }
        }

        public override string GetChat() {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            foreach (Item i in Main.LocalPlayer.inventory) {
                if (i.type == ModContent.ItemType<Items.Melee.Sword>()) chat.Add("That sword seems to have potential.");
                if (i.type == ModContent.ItemType<Items.Melee.SwordHilt>()) chat.Add("That sword hilt had so much potential.");
            }

            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.Next(4) == 0) {
                chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
            }

            int Smithy = NPC.FindFirstNPC(ModContent.NPCType<NPCs.Town.Blacksmith>());
            if (Smithy <= -1 && Main.rand.Next(4) == 0) {
                chat.Add("Rumor has it there is a blacksmith around these parts. He tends to journey towards adventurers holding tools for him to use. I wonder what would entice him...");
            }
            if (Smithy >= 0 && Main.rand.Next(4) == 0) {
                chat.Add("Did you know that "  + Main.npc[Smithy].GivenName +  " was once friends with a giant blacksmith?");
            }
            chat.Add("Oh, sweet champion, you've returned.");
            chat.Add("Gathering Estus Shards will allow you to fortify your Flask.");
            chat.Add("Resting at a Firelink Shrine restores all Estus Flasks, lost mana, and increases hollow recovery speed.");
            chat.Add("Some items require special powers to forge, a Firelink Shrine has unique properties attuned to these items, but often times a price must be made in exchange");
            chat.Add("May the dark sigil guide your way.");
            chat.Add("Stay safe champion.");

            return chat.Get();
        }

        public override void SetChatButtons(ref string button, ref string button2) {
            button = Language.GetText("Shop").Value;
            DrakSolzPlayer player = Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
            button2 = "Level up";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
            if (firstButton) {
                shop = true;
            } else {
                UI.PlayerUI.visible = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot) {
            if(NPC.downedMechBoss1){
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingAvarice>());}
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingCat>());
            if(NPC.downedBoss2){
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingRuby>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingSapphire>());}
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingEstus>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingAshenEstus>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingCloranthy>());
            if(NPC.downedSlimeKing){
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingBinding>());}
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingReversal>());
            if(NPC.downedBoss3){
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingThorns>());}
            if(NPC.downedBoss1){
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingKnuckleBrace>());}
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Accessory.RingRusty>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.ScrollHolyHomeward>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.ScrollHoly>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.PyroScroll>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.Scroll>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.HomewardBone>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.Lifegem>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.GreenBlossom>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Misc.PrismStone>());
            if(NPC.downedBoss3){
            shop.item[nextSlot++].SetDefaults(ItemID.UnholyWater);
            shop.item[nextSlot++].SetDefaults(ItemID.BloodWater);}
            if (Main.hardMode) {
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Throwing.FireBomb>());
            }
            if (NPC.downedPlantBoss) {
                shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Throwing.BlackFireBomb>());
            }
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