using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DrakSolz.NPCs.Enemy.VoidPillar;
using DrakSolz.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace DrakSolz {
    public class DrakSolz : Mod {
        internal static DrakSolz instance;
        public static List<int> ListBossSoul { get; set; }

        private UserInterface userInterface;
        internal SoulUI ui;
        private UserInterface userInterfacePlayer;
        internal PlayerUI playerUI;

        public DrakSolz() {

            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public static float RoundToClosest(float f, float closest) {
            f = (float) Math.Round(f / closest) * closest;
            return f;
        }

        public static Vector2 AdjustMagnitude(ref Vector2 vector, float min, float max) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > max) vector *= max / magnitude;
            if (magnitude < min) vector *= min / magnitude;
            return vector;
        }

        public static int CreateGore(Mod mod, NPC npc, string gore) {
            int g = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot(gore));
            Main.gore[g].scale = npc.scale;
            return g;
        }

        public static int DropItem(NPC npc, float chance, params int[] types) {
            if (Main.rand.NextFloat(100f) > chance) return 0;
            return Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, types));
        }

        public static int DropItem(NPC npc, float chance, int type, int qty = 1) {
            if (Main.rand.NextFloat(100f) > chance) return 0;
            return Item.NewItem(npc.Center, npc.width, npc.height, type, qty);
        }

        public static Vector2 AdjustMagnitude(ref Vector2 vector, float speed) {
            return AdjustMagnitude(ref vector, speed, speed);
        }

        public override void Load() {
            instance = this;

            ListBossSoul = new List<int>();
            ListBossSoul.AddRange(new int[] {
                NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail, NPCID.BrainofCthulhu,
                    NPCID.QueenBee, NPCID.SkeletronHead, NPCID.SkeletronHand, NPCID.WallofFlesh, NPCID.WallofFleshEye,
                    NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail, NPCID.Retinazer, NPCID.Spazmatism,
                    NPCID.SkeletronPrime, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.Plantera,
                    NPCID.Golem, NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree, NPCID.CultistBoss, NPCID.DukeFishron,
                    NPCID.MoonLordCore, NPCID.MoonLordFreeEye, NPCID.MoonLordHand, NPCID.MoonLordHead
            });

            if (Main.dedServ) return;
            ui = new SoulUI(ModContent.GetInstance<Items.Souls.Soul>());
            ui.Activate();
            userInterface = new UserInterface();
            userInterface.SetState(ui);
            playerUI = new PlayerUI();
            playerUI.Activate();
            userInterfacePlayer = new UserInterface();
            userInterfacePlayer.SetState(playerUI);

            VoidPillarSky.PlanetTexture = GetTexture("NPCs/Enemy/VoidPillar/VoidPillarPlanet");
            Filters.Scene["DrakSolz:VoidPillar"] = new Filter(new VoidPillarData("FilterMiniTower").UseColor(0.7f, 0.7f, 0.7f).UseOpacity(0.82f), EffectPriority.VeryHigh);
            SkyManager.Instance["DrakSolz:VoidPillar"] = new VoidPillarSky();
        }

        public override void Unload() {
            ListBossSoul = null;
            instance = null;
            if (!Main.dedServ) {
                //VoidPillarGlowMask.Unload();
            }
        }

        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> layers) {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1) {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "DrakSolz: Souls",
                    delegate {
                        if (SoulUI.visible) {
                            userInterface.Update(Main._drawInterfaceGameTime);
                            ui.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "DrakSolz: Level",
                    delegate {
                        if (PlayerUI.visible) {
                            userInterfacePlayer.Update(Main._drawInterfaceGameTime);
                            playerUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }
        public override void PostSetupContent() {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null) {
                //SlimeKing = 1f;
                //EyeOfCthulhu = 2f;
                //EaterOfWorlds = 3f;
                //QueenBee = 4f;
                //Skeletron = 5f;
                //WallOfFlesh = 6f;
                //TheTwins = 7f;
                //TheDestroyer = 8f;
                //SkeletronPrime = 9f;
                //Plantera = 10f;
                //Golem = 11f;
                //DukeFishron = 12f;
                //LunaticCultist = 13f;
                //Moonlord = 14f;
                bossChecklist.Call("AddBossWithInfo", "White Pillar", 13.5f, (Func<bool>) (() => DrakSolzWorld.Boss.VoidPillar.IsDowned()), "Kill the Lunatic Cultist outside the dungeon");
            }
        }

        public override void HandlePacket(System.IO.BinaryReader reader, int whoAmI) {
            MessageType msgType = (MessageType) reader.ReadByte();
            DrakSolzPlayer p = Main.player[reader.ReadByte()].GetModPlayer<DrakSolzPlayer>();
            //if (p.player.Equals(Main.LocalPlayer) || Main.netMode != NetmodeID.Server) return;

            switch (msgType) {
                case MessageType.Stats:
                    p.Stats = reader.ReadInt64();
                    break;
                case MessageType.Hurt:
                    p.HurtWait = reader.ReadInt32();
                    p.Hollow = reader.ReadInt32();
                    break;
                case MessageType.UID:
                    p.UID = reader.ReadInt64();;
                    break;
                default:
                    Logger.Error("Drak Solz: Unknown Message type: " + msgType);
                    break;
            }
        }
    }

    public enum MessageType : byte {
        Stats,
        Hurt,
        UID
    }
}