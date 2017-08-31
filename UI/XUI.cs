using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace XahlicemMod.UI {

    class XUI : UIState {
        private bool RightClicking = false;
        private int RightTime = 0;
        private int Time = 0;
        public UIPanel panel;
        public UIText num;
        public static bool visible = true;
        private Item item;

        public XUI(ModItem modItem) {
            item = modItem.item;
        }

        public override void OnInitialize() {
            panel = new UIPanel();
            panel.SetPadding(0);
            panel.Left.Set(Main.screenWidth - 160, 0f);
            panel.Top.Set(Main.screenHeight - 50, 0f);
            panel.Width.Set(135f, 0f);
            panel.Height.Set(35f, 0f);
            panel.BackgroundColor = new Color(73, 94, 171);
            panel.OnClick += Click;
            panel.OnRightMouseDown += RightDown;
            panel.OnRightMouseUp += RightUp;

            Texture2D buttonPlayTexture = ModLoader.GetTexture("XahlicemMod/Items/Craft/SoulSingle");
            UIImage playButton = new UIImage(buttonPlayTexture);
            playButton.Left.Set(10, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(25, 0f);
            playButton.Height.Set(25, 0f);
            panel.Append(playButton);

            num = new UIText("0");
            num.Left.Set(35, 0f);
            num.Top.Set(10, 0f);
            num.Width.Set(90, 0f);
            num.Height.Set(25, 0f);
            num.HAlign = UIAlign.Left;
            panel.Append(num);

            base.Append(panel);
        }

        private void RightDown(UIMouseEvent evt, UIElement listeningElement) {
            RightClicking = true;
        }

        private void RightUp(UIMouseEvent evt, UIElement listeningElement) {
            RightClicking = false;
        }

        private void Click(UIMouseEvent evt, UIElement listeningElement) {
            XahlicemPlayer player = Main.LocalPlayer.GetModPlayer<XahlicemPlayer>();
            if (!Main.playerInventory) return;
            if (Main.mouseItem.type == item.type) {
                player.Souls += Main.mouseItem.stack;
                Main.mouseItem.stack = 0;
            } else if (Main.mouseItem.type == 0) {
                Main.mouseItem.netDefaults(item.type);
                Main.mouseItem.stack = player.Souls;
                player.Souls = 0;
            }
            Recipe.FindRecipes();
        }

        public override void Update(GameTime gameTime) {
            if (!RightClicking || !Main.playerInventory) {
                if (Main.mouseItem.type == 0 || Main.mouseItem.stack == 0) Main.mouseItem = new Item();
                RightClicking = false;
                return;
            }
            if (RightClicking) {
                XahlicemPlayer player = Main.LocalPlayer.GetModPlayer<XahlicemPlayer>();
                Main.playerInventory = true;
                if (Main.stackSplit <= 1 && item.type > 0 && (Main.mouseItem.type == item.type || Main.mouseItem.type == 0)) {
                    int num2 = Main.superFastStack + 1;
                    for (int j = 0; j < num2; j++) {
                        if ((Main.mouseItem.stack < 9999 || Main.mouseItem.type == 0) && player.Souls > 0) {
                            if (j == 0) {
                                Main.PlaySound(18, -1, -1, 1);
                            }
                            if (Main.mouseItem.type == 0) {
                                Main.mouseItem.netDefaults(item.type);
                                Main.mouseItem.type = item.type;
                                Main.mouseItem.stack = 0;
                            }
                            Main.mouseItem.stack++;
                            player.Souls--;
                            if (Main.stackSplit == 0) {
                                Main.stackSplit = 15;
                            } else {
                                Main.stackSplit = Main.stackDelay;
                            }
                        }
                    }
                }
            }

        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            Vector2 MousePosition = new Vector2((float) Main.mouseX, (float) Main.mouseY);
            if (panel.ContainsPoint(MousePosition)) {
                Main.LocalPlayer.mouseInterface = true;
            }
            panel.Left.Set(500, 0f);
            panel.Top.Set(25, 0f);
            Recalculate();
        }

        public void updateValue(int carrying) {
            num.SetText(carrying.ToString());
            Recipe.FindRecipes();
        }
    }
}