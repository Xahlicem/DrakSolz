using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace DrakSolz.NPCs.Town {
    [AutoloadHead]
    public class ConfusedGibbet : ModNPC {
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
            name = "ConfusedGibbet";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Confused Gibbet");
            Main.npcFrameCount[npc.type] = 23;
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
            npc.damage = 100;
            npc.defense = 100;
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Nurse;
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
            foreach (Item i in Main.LocalPlayer.inventory) {
                if (i.type == ModContent.ItemType<Items.Armor.GibbetHead>())
                return true;
            }
            return false;
        }

        public override string TownNPCName() {
            switch (WorldGen.genRand.Next(4)) {
                case 0:
                    return "Abyss";
                case 1:
                    return "Creep";
                case 2:
                    return "Minion";
                default:
                    return "Supreme Overlord Zhar";
            }
        }

        public override string GetChat() {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            foreach (Item i in Main.LocalPlayer.inventory) {
                if (i.type == ModContent.ItemType<Items.Armor.GibbetHead>()) chat.Add("How disturbingly evil!");
                if (i.type == ModContent.ItemType<Items.Armor.GibbetHead>()) chat.Add("You... look familiar. Quite evil indeed.");
                if (i.type == ModContent.ItemType<Items.Armor.GibbetHead>()) chat.Add("Gerald? No... you're not gerald. Much more evil than he ever was.");
                if (i.type == ModContent.ItemType<Items.Armor.GibbetHead>()) chat.Add("Ohhh I love it!");
                if (i.type == ModContent.ItemType<Items.Armor.GibbetHead>()) chat.Add("Everyone wants to be me, sorry love it's not possible.");
            }
            chat.Add("Ahhh, ready to do some evil?");
            chat.Add("I just want to murder everyone here, isn't it lovely?");
            chat.Add("I'm pretty sure I heard them whispering something about me, and possibly poison... We're getting along just peachy!");

            return chat.Get();
        }

        public override void SetChatButtons(ref string button, ref string button2) {
            button = Language.GetText("Shop").Value;
            DrakSolzPlayer player = Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
            if (firstButton) {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot) {
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Armor.GibbetBody>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<Items.Armor.GibbetLegs>());

        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
            damage = 100;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
            cooldown = 10;
            randExtraCooldown = 20;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
            projType = ProjectileID.ShadowFlameKnife;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}