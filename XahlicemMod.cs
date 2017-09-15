using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using XahlicemMod.UI;

namespace XahlicemMod {
    public class XahlicemMod : Mod {
        public static List<int> ListMeleeThrow { get; set; }
        public static List<int> ListBossSoul { get; set; }

        private UserInterface userInterface;
        internal XUI xUI;
        private UserInterface userInterfacePlayer;
        internal XPlayerUI xPUI;

        public XahlicemMod() {

            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load() {
            ListMeleeThrow = new List<int>();
            ListMeleeThrow.AddRange(new int[] { 284, 55, 1918, 1825, 670, 191, 119, 3030, 1324, 561, 1122, 1513, 3054, 1569, 3543 });
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
            xUI = new XUI(GetItem<Items.Craft.Soul>());
            xUI.Activate();
            userInterface = new UserInterface();
            userInterface.SetState(xUI);
            xPUI = new XPlayerUI();
            xPUI.Activate();
            userInterfacePlayer = new UserInterface();
            userInterfacePlayer.SetState(xPUI);
        }

        public override void Unload() {
            ListMeleeThrow = null;
            ListBossSoul = null;
        }

        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> layers) {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1) {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "XahlicemMod: Souls",
                    delegate {
                        if (XUI.visible) {
                            userInterface.Update(Main._drawInterfaceGameTime);
                            xUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "XahlicemMod: Level",
                    delegate {
                        if (XPlayerUI.visible) {
                            userInterfacePlayer.Update(Main._drawInterfaceGameTime);
                            xPUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        public override void HandlePacket(System.IO.BinaryReader reader, int whoAmI) {
            XModMessageType msgType = (XModMessageType) reader.ReadByte();
            Player player = Main.player[reader.ReadInt32()];
            XahlicemPlayer modPlayer = player.GetModPlayer<XahlicemPlayer>();

            switch (msgType) {
                case XModMessageType.FromClient:
                    if (Main.netMode == NetmodeID.Server) {
                        modPlayer.Souls = reader.ReadInt32();
                        modPlayer.LastHurt = reader.ReadInt64();

                        modPlayer.GetPacket((byte) XModMessageType.FromServer).Send();
                        //NetMessage.BroadcastChatMessage(Terraria.Localization.NetworkText.FromLiteral(player.name + " " + race.ToString()), Microsoft.Xna.Framework.Color.White);
                    }
                    break;

                case XModMessageType.FromClieBuff:
                    if (Main.netMode == NetmodeID.Server) {
                        int index = reader.ReadInt32();
                        if (index != -1) player.AddBuff(BuffType<Buffs.Hollow>(), reader.ReadInt32());

                        GetBuff<Buffs.Hollow>().GetPacket(XModMessageType.FromServBuff, player, index).Send();
                        //NetMessage.BroadcastChatMessage(Terraria.Localization.NetworkText.FromLiteral(player.name + " " + race.ToString()), Microsoft.Xna.Framework.Color.White);
                    }
                    break;

                case XModMessageType.FromServer:
                    if (!player.Equals(Main.LocalPlayer)) {
                        modPlayer.Souls = reader.ReadInt32();
                        modPlayer.LastHurt = reader.ReadInt64();
                    }
                    break;

                case XModMessageType.FromServBuff:
                    if (!player.Equals(Main.LocalPlayer)) {
                        int index = reader.ReadInt32();
                        if (index != -1) player.AddBuff(BuffType<Buffs.Hollow>(), reader.ReadInt32());
                    }
                    break;

                default:
                    ErrorLogger.Log("XRaces: Unknown Message type: " + msgType);
                    break;
            }
        }
    }

    public enum XModMessageType : byte {
        FromServer,
        FromClient,
        FromServBuff,
        FromClieBuff
    }
}