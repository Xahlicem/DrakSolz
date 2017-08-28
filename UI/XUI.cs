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
        public UIPanel panel;
        public UIText num;
        public static bool visible = true;

        public override void OnInitialize() {
            panel = new UIPanel();
            panel.SetPadding(0);
            panel.Left.Set(Main.screenWidth - 160, 0f);
            panel.Top.Set(Main.screenHeight - 50, 0f);
            panel.Width.Set(135f, 0f);
            panel.Height.Set(35f, 0f);
            panel.BackgroundColor = new Color(73, 94, 171);
            panel.OnMouseDown += new UIElement.MouseEvent(DragStart);
            panel.OnMouseUp += new UIElement.MouseEvent(DragEnd);
            panel.OnClick += Click;

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

        private void Click(UIMouseEvent evt, UIElement listeningElement) {
            
            XahlicemPlayer player = Main.LocalPlayer.GetModPlayer<XahlicemPlayer>();
            if (!Main.playerInventory) return;
            int type = ModLoader.GetMod("XahlicemMod").ItemType<Items.Craft.Soul>();
            if (Main.mouseItem.type == type) {
                player.Souls += Main.mouseItem.stack;
                Main.mouseItem.stack = 0;
                Main.mouseItem.type = 0;
            } else if (Main.mouseItem.type == 0) {
                Main.mouseItem.netDefaults(type);
                Main.mouseItem.stack = player.Souls;
                player.Souls = 0;
            }
            Recipe.FindRecipes();
        }

        Vector2 offset;

        public bool dragging = false;

        private void DragStart(UIMouseEvent evt, UIElement listeningElement) {
            offset = new Vector2(evt.MousePosition.X - panel.Left.Pixels, evt.MousePosition.Y - panel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement) {
            Vector2 end = evt.MousePosition;
            dragging = false;
            panel.Left.Set(end.X - offset.X, 0f);
            panel.Top.Set(end.Y - offset.Y, 0f);
            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            Vector2 MousePosition = new Vector2((float) Main.mouseX, (float) Main.mouseY);
            if (panel.ContainsPoint(MousePosition)) {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging) {
                panel.Left.Set(MousePosition.X - offset.X, 0f);
                panel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }

            if (panel.Left.Pixels > Main.screenWidth - 160 || panel.Top.Pixels > Main.screenHeight - 50) {
                panel.Left.Set(Main.screenWidth - 160, 0f);
                panel.Top.Set(Main.screenHeight - 50, 0f);
                Recalculate();
            }
        }

        public void updateValue(int carrying) {
            num.SetText(carrying.ToString());
            Recipe.FindRecipes();
        }
    }
}