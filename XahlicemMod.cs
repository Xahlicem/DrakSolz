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
using DrakSolz.UI;

namespace DrakSolz {
    public class DrakSolz : Mod {
        public static List<int> ListMeleeThrow { get; set; }
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
            ui = new SoulUI(GetItem<Items.Craft.Soul>());
            ui.Activate();
            userInterface = new UserInterface();
            userInterface.SetState(ui);
            playerUI = new PlayerUI();
            playerUI.Activate();
            userInterfacePlayer = new UserInterface();
            userInterfacePlayer.SetState(playerUI);
        }

        public override void Unload() {
            ListMeleeThrow = null;
            ListBossSoul = null;
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