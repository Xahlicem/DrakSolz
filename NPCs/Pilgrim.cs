using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.NPCs
{
    [AutoloadHead]
    public class Pilgrim : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "Xahlicemod/NPCs/Pilgrim";
            }
        }

        /*public override string[] AltTextures
         {
        get
         {
        return new string[] { "Xahlicem/NPCs/Pilgrim_Alt_1" };
        }
        }*/

        public override bool Autoload(ref string name)
        {
            name = "Pilgrim";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
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

        public override void SetDefaults()
        {
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

        public override void HitEffect(int hitDirection, double damage)
        {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Smoke);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active)
                {
                    for (int j = 0; j < player.inventory.Length; j++)
                    {
                        if (player.inventory[j].type == mod.ItemType("Soul") || player.inventory[j].type == mod.ItemType("SkullLantern"))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            int score = 0;
            for (int x = left; x <= right; x++)
            {
                for (int y = top; y <= bottom; y++)
                {
                    int type = Main.tile[x, y].type;
                    if (type == TileID.WoodBlock || type == TileID.Chairs || type == TileID.WorkBenches || type == TileID.Beds || type == TileID.OpenDoor || type == TileID.ClosedDoor)
                    {
                        score++;
                    }
                    if (Main.tile[x, y].wall == WallID.Wood)
                    {
                        score++;
                    }
                }
            }
            return score >= (right - left) * (bottom - top) / 2;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
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

        public override void FindFrame(int frameHeight)
        {
            /*npc.frame.Width = 36;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 36;
			}
			else
			{
				npc.frame.X = 0;
			}*/
        }

        public override string GetChat()
        {
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.Next(4) == 0)
            {
                return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
            }
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Oh, sweet champion, you've returned.";
                case 1:
                    return "May the dark sigil guide your way.";
                default:
                    return "Stay safe champion.";
            }
        }

        /* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.Next(4) == 0)
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("Eater1"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("Leecher1"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingFavor"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingCalamity"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingRedTear"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingBlueTear"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingCloranthy"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingCat"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("RingSteelProt"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("MorianBlade"));
            nextSlot++;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.BoneDagger;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}