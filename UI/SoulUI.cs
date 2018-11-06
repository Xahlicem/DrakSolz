using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace DrakSolz.UI {
    class SoulUI : UIState {
        private bool RightClicking = false;
        private int RightTime = 0;
        private int Time = 0;
        public UIPanel panel;
        public UIText num, numLevel;
        public static bool visible = true;
        private Item item;
        private int height;

        public SoulUI(ModItem modItem) {
            item = modItem.item;
        }

        public override void OnInitialize() {
            height = 25;
            if (ModLoader.GetMod("Tervania") != null) height = 62;

            panel = new UIPanel();
            panel.SetPadding(0);
            panel.Left.Set(496, 0f);
            panel.Top.Set(height, 0f);
            panel.Width.Set(135f, 0f);
            panel.Height.Set(25f, 0f);
            panel.BackgroundColor = new Color(73, 94, 171);

            numLevel = new UIText("0");
            numLevel.Left.Set(5, 0f);
            numLevel.Top.Set(4, 0f);
            numLevel.Width.Set(25, 0f);
            numLevel.Height.Set(25, 0f);
            numLevel.HAlign = UIAlign.Left;
            panel.Append(numLevel);

            Texture2D soulTex = ModLoader.GetTexture("DrakSolz/UI/Soul");
            UIImage soul = new UIImage(soulTex);
            soul.Left.Set(40, 0f);
            soul.Top.Set(2, 0f);
            soul.Width.Set(25, 0f);
            soul.Height.Set(25, 0f);
            panel.Append(soul);

            num = new UIText("0");
            num.Left.Set(55, 0f);
            num.Top.Set(4, 0f);
            num.Width.Set(65, 0f);
            num.Height.Set(25, 0f);
            num.HAlign = UIAlign.Left;
            panel.Append(num);

            base.Append(panel);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            Vector2 MousePosition = new Vector2((float) Main.mouseX, (float) Main.mouseY);
            if (panel.ContainsPoint(MousePosition)) {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (numLevel.ContainsPoint(MousePosition)) Main.hoverItemName = "Soul Level";
            if (num.ContainsPoint(MousePosition)) Main.hoverItemName = "Available Souls";
            panel.Left.Set(496, 0f);

            panel.Top.Set(height, 0f);
            Recalculate();
        }

        public void updateValue(int carrying, int level) {
            num.SetText(carrying.ToString());
            numLevel.SetText(level.ToString());
            Recipe.FindRecipes();
        }
    }
}