using System;
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
            Items.MeleeThrow.list = null;
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