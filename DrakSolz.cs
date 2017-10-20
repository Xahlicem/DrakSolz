using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DrakSolz.NPCs.Enemy.WhitePillar;
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
            ui = new SoulUI(GetItem<Items.Souls.Soul>());
            ui.Activate();
            userInterface = new UserInterface();
            userInterface.SetState(ui);
            playerUI = new PlayerUI();
            playerUI.Activate();
            userInterfacePlayer = new UserInterface();
            userInterfacePlayer.SetState(playerUI);

            WhitePillarSky.PlanetTexture = GetTexture("NPCs/Enemy/WhitePillar/WhitePillarPlanet");
            Filters.Scene["DrakSolz:WhitePillar"] = new Filter(new WhitePillarData("FilterMiniTower").UseColor(0.7f, 0.7f, 0.7f).UseOpacity(0.82f), EffectPriority.VeryHigh);
            SkyManager.Instance["DrakSolz:WhitePillar"] = new WhitePillarSky();
        }

        public override void Unload() {
            ListBossSoul = null;
            instance = null;
            if (!Main.dedServ) {
                //WhitePillarGlowMask.Unload();
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
                bossChecklist.Call("AddBossWithInfo", "White Pillar", 13.5f, (Func<bool>)(() => DrakSolzWorld.Boss.WhitePillar.IsDowned()), "Kill the Lunatic Cultist outside the dungeon");
            }
        }

        public override void HandlePacket(System.IO.BinaryReader reader, int whoAmI) {
            MessageType msgType = (MessageType) reader.ReadByte();
            Player player = Main.player[reader.ReadInt32()];
            DrakSolzPlayer modPlayer = player.GetModPlayer<DrakSolzPlayer>();

            switch (msgType) {
                case MessageType.FromClient:
                    if (Main.netMode == NetmodeID.Server) {
                        modPlayer.Souls = reader.ReadInt32();
                        modPlayer.LastHurt = reader.ReadInt64();

                        modPlayer.GetPacket((byte) MessageType.FromServer).Send();
                        //NetMessage.BroadcastChatMessage(Terraria.Localization.NetworkText.FromLiteral(player.name + " " + race.ToString()), Microsoft.Xna.Framework.Color.White);
                    }
                    break;

                case MessageType.FromClieBuff:
                    if (Main.netMode == NetmodeID.Server) {
                        int index = reader.ReadInt32();
                        if (index != -1) player.AddBuff(BuffType<Buffs.Hollow>(), reader.ReadInt32());

                        GetBuff<Buffs.Hollow>().GetPacket(MessageType.FromServBuff, player, index).Send();
                        //NetMessage.BroadcastChatMessage(Terraria.Localization.NetworkText.FromLiteral(player.name + " " + race.ToString()), Microsoft.Xna.Framework.Color.White);
                    }
                    break;

                case MessageType.FromServer:
                    if (!player.Equals(Main.LocalPlayer)) {
                        modPlayer.Souls = reader.ReadInt32();
                        modPlayer.LastHurt = reader.ReadInt64();
                    }
                    break;

                case MessageType.FromServBuff:
                    if (!player.Equals(Main.LocalPlayer)) {
                        int index = reader.ReadInt32();
                        if (index != -1) player.AddBuff(BuffType<Buffs.Hollow>(), reader.ReadInt32());
                    }
                    break;

                default:
                    ErrorLogger.Log("Drak Solz: Unknown Message type: " + msgType);
                    break;
            }
        }
    }

    public enum MessageType : byte {
        FromServer,
        FromClient,
        FromServBuff,
        FromClieBuff
    }
}