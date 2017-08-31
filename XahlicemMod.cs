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

        private UserInterface exampleUserInterface;
        internal XUI xUI;
        public static int SoulCustomCurrencyID;

        public XahlicemMod() {

            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load() {
            SoulCustomCurrencyID = CustomCurrencyManager.RegisterCurrency(new SoulCustomCurrency(ItemType<Items.Craft.Soul>(), 999L));
            if (Main.dedServ) return;
            xUI = new XUI(GetItem<Items.Craft.Soul>());
            xUI.Activate();
            exampleUserInterface = new UserInterface();
            exampleUserInterface.SetState(xUI);
        }

        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> layers) {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1) {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "XahlicemMod: Souls",
                    delegate {
                        if (XUI.visible) {
                            exampleUserInterface.Update(Main._drawInterfaceGameTime);
                            xUI.Draw(Main.spriteBatch);
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

    public class SoulRecipe : ModRecipe {
        private int requiredSouls;
        public SoulRecipe(Mod mod, ModItem modItem, int souls) : base(mod) {
            requiredSouls = souls;
            SetResult(modItem);
        }

        public override bool RecipeAvailable() {
            return (Main.LocalPlayer.GetModPlayer<XahlicemPlayer>().Souls >= requiredSouls);
        }

        public override void OnCraft(Item item) {
            Main.LocalPlayer.GetModPlayer<XahlicemPlayer>().Souls -= requiredSouls;
        }
    }
}