using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;


namespace DrakSolz.UI {

    class StatPanel {
        public int Stat { get; set; }
        public int StatAdd { get; set; }

        internal UIToggleImage up, down, icon;
        public UIText StatText { get; set; }

        public StatPanel(int x, int y, UIPanel panel, Texture2D texture, Point point) {
            Stat = 0;
            StatAdd = 0;

            StatText = new UIText(string.Empty);
            StatText.Left.Set(x, 0f);
            StatText.Top.Set(y, 0f);
            StatText.Width.Set(60, 0f);
            StatText.Height.Set(20, 0f);
            panel.Append(StatText);

            Point p = new Point(1, 1);
            up = new UIToggleImage(texture, 20, 20, p, p);
            up.Left.Set(x, 0f);
            up.Top.Set(y + 15, 0f);
            up.Width.Set(20, 0f);
            up.Height.Set(20, 0f);
            up.SetState(false);
            up.OnClick += OnClick;
            panel.Append(up);

            icon = new UIToggleImage(texture, 20, 20, point, point);
            icon.Left.Set(x + 20, 0f);
            icon.Top.Set(y + 15, 0f);
            icon.Width.Set(20, 0f);
            icon.Height.Set(20, 0f);
            icon.OnClick += Reset;
            panel.Append(icon);

            p = new Point(22, 1);
            down = new UIToggleImage(texture, 20, 20, p, p);
            down.Left.Set(x + 40, 0f);
            down.Top.Set(y + 15, 0f);
            down.Width.Set(20, 0f);
            down.Height.Set(20, 0f);
            down.SetState(true);
            down.OnClick += OnClick;
            panel.Append(down);
        }

        public void Set(int stat) {
            Stat = stat;
            Set();
        }

        public void Set() {
            if (StatAdd < 0) StatAdd = 0;
            StatText.SetText((Stat + StatAdd).ToString());
        }

        public void Reset(UIMouseEvent evt, UIElement listeningElement) {
            StatAdd = 0;
            Set();
        }

        public void Reset() {
            Reset(null, icon);
        }

        private void OnClick(UIMouseEvent evt, UIElement listeningElement) {
            UIToggleImage button = listeningElement as UIToggleImage;
            if (button.IsOn) StatAdd--;
            else StatAdd++;
            Set();
            button.SetState(!button.IsOn);
        }
    }
}