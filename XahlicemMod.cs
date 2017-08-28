using System;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
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

            xUI = new XUI();
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