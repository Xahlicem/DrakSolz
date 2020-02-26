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

    class PlayerUI : UIState {
        private UIPanel panel;
        private DrakSolzPlayer Player {
            get {
                try {
                    return Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>();
                } catch (Exception) {
                    return null;
                }
            }
        }
        public static bool visible = false;
        public UIText Level { get; set; }
        public UIText Cost { get; set; }
        public UIToggleImage Exit { get; set; }

        StatPanel Vit { get; set; }
        StatPanel Str { get; set; }
        StatPanel Dex { get; set; }
        StatPanel Att { get; set; }
        StatPanel Int { get; set; }
        StatPanel Fth { get; set; }

        internal UIPanel tooltip;
        internal UIText tooltipTitle = new UIText(string.Empty);
        internal UIText tooltipText = new UIText(string.Empty);
        internal UIText tooltipText1 = new UIText(string.Empty);

        public override void OnInitialize() {
            panel = new UIPanel();
            panel.SetPadding(0);
            panel.Left.Set((Main.screenWidth - 200) / 2, 0f);
            panel.Top.Set((Main.screenHeight - 150) / 2, 0f);
            panel.Width.Set(160, 0f);
            panel.Height.Set(150, 0f);
            panel.BackgroundColor = new Color(50, 50, 50); //73, 94, 171);

            UIText text = new UIText("lvl");
            text.Left.Set(10, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(25, 0f);
            text.Height.Set(20, 0f);
            text.HAlign = UIAlign.Left;
            panel.Append(text);
            Level = new UIText(string.Empty);
            Level.Left.Set(35, 0f);
            Level.Top.Set(10, 0f);
            Level.Width.Set(25, 0f);
            Level.Height.Set(20, 0f);
            Level.HAlign = UIAlign.Left;
            panel.Append(Level);

            UIPanel p = new UIPanel();
            p.SetPadding(0);
            p.BackgroundColor = new Color(50, 50, 50);
            p.Left.Set(60, 0f);
            p.Top.Set(0, 0f);
            p.Width.Set(68, 0f);
            p.Height.Set(30, 0f);
            panel.Append(p);

            Cost = new UIText(string.Empty, 0.9f);
            Cost.Left.Set(0, 0f);
            Cost.Top.Set(8, 0f);
            Cost.Width.Set(68, 0f);
            Cost.Height.Set(25, 0f);
            p.Append(Cost);

            Texture2D texture = ModContent.GetTexture("DrakSolz/UI/AttributeGUI");
            Exit = new UIToggleImage(texture, 20, 20, new Point(43, 1), new Point(43, 1));
            Exit.Left.Set(130, 0f);
            Exit.Top.Set(10, 0f);
            Exit.Width.Set(20, 0f);
            Exit.Height.Set(20, 0f);
            Exit.OnClick += Apply;
            panel.Append(Exit);

            Vit = new StatPanel(10, 35, panel, texture, new Point(1, 22));
            Str = new StatPanel(10, 70, panel, texture, new Point(1, 43));
            Dex = new StatPanel(10, 105, panel, texture, new Point(1, 64));
            Att = new StatPanel(90, 35, panel, texture, new Point(22, 22));
            Int = new StatPanel(90, 70, panel, texture, new Point(22, 43));
            Fth = new StatPanel(90, 105, panel, texture, new Point(22, 64));

            base.Append(panel);

            tooltip = new UIPanel();
            tooltip.SetPadding(0);
            tooltip.Width.Set(200, 0f);
            tooltip.Height.Set(60, 0f);
            tooltip.BackgroundColor = new Color(50, 50, 50);
            tooltipTitle.Left.Set(0, 0f);
            tooltipTitle.Top.Set(10, 0f);
            tooltipTitle.Width.Set(200, 0f);
            tooltipTitle.Height.Set(30, 0f);
            tooltip.Append(tooltipTitle);
            tooltipText.Left.Set(0, 0f);
            tooltipText.Top.Set(35, 0f);
            tooltipText.Width.Set(200, 0f);
            tooltipText.Height.Set(30, 0f);
            tooltip.Append(tooltipText);
            tooltipText1.Left.Set(0, 0f);
            tooltipText1.Top.Set(60, 0f);
            tooltipText1.Width.Set(200, 0f);
            tooltipText1.Height.Set(30, 0f);
            tooltip.Append(tooltipText1);
        }

        private void Apply(UIMouseEvent evt, UIElement listeningElement) {
            if (int.Parse(Cost.Text) > Player.Souls) return;
            visible = false;
            Player.UpdateSouls(-int.Parse(Cost.Text));

            Player.LevelUp(Str.StatAdd, Dex.StatAdd, Int.StatAdd, Fth.StatAdd, Vit.StatAdd, Att.StatAdd);

            Vit.Reset();
            Str.Reset();
            Dex.Reset();
            Att.Reset();
            Int.Reset();
            Fth.Reset();
        }

        public override void Update(GameTime gameTime) {
            if (Player == null) return;
            int level = Vit.Stat + Str.Stat + Dex.Stat + Att.Stat + Int.Stat + Fth.Stat + Vit.StatAdd + Str.StatAdd + Dex.StatAdd + Att.StatAdd + Int.StatAdd + Fth.StatAdd;
            int totalCost = 0;
            for (int i = Player.Level; i < level; i++) {
                totalCost += Player.SoulCost(i);
            }
            Level.SetText((level).ToString());
            Cost.SetText(totalCost.ToString());
            Vit.Set(Player.Vit);
            Str.Set(Player.Str);
            Dex.Set(Player.Dex);
            Att.Set(Player.Att);
            Int.Set(Player.Int);
            Fth.Set(Player.Fth);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            setControls();
            Vector2 MousePosition = new Vector2((float) Main.mouseX, (float) Main.mouseY);
            tooltip.Top.Set(MousePosition.Y + 15, 0f);
            tooltip.Left.Set(MousePosition.X + 15, 0f);
            string s = "";
            bool throwing = false;
            bool pyro = false;
            bool defense = false;
            bool MCost = false;
            if (!HasChild(tooltip)) Append(tooltip);
            if (Vit.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Vitality");
                int vit = Vit.Stat + Vit.StatAdd;
                vit = int.Parse(Level.Text) * 4 + vit * 11;
                s = ("+" + vit + " Health");
                defense = true;
            } else if (Str.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Strength");
                s = ("+" + (Str.Stat + Str.StatAdd - 20) * 2 + "% Melee Damage");
                throwing = true;
            } else if (Dex.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Dexterity");
                s = ("+" + (Dex.Stat + Dex.StatAdd - 20) * 2 + "% Ranged Damage");
                throwing = true;
            } else if (Att.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Attunement");
                s = ("+" + (Att.Stat + Att.StatAdd) * 5 + " Mana");
                MCost = true;
            } else if (Int.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Intelligence");
                s = ("+" + (Int.Stat + Int.StatAdd - 20) * 2 + "% Magic Damage");
                pyro = true;
            } else if (Fth.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Faith");
                s = ("+" + (Fth.Stat + Fth.StatAdd - 20) * 2 + "% Miracle Damage");
                pyro = true;
            } else RemoveChild(tooltip);
            if (HasChild(tooltip)) {
                tooltipText.SetText((s[1] == '-') ? s.Substring(1) : s);
                if (throwing) {
                    string t = ("+" + ((Dex.Stat + Dex.StatAdd < Str.Stat + Str.StatAdd) ? (Dex.Stat + Dex.StatAdd - 10) : (Str.Stat + Str.StatAdd - 10)) * 4 + "% Thrown Damage");
                    tooltipText1.SetText((t[1] == '-') ? t.Substring(1) : t);
                    tooltip.Height.Set(85, 0f);
                } else if (defense) {
                    string t = ("+" + (int) Math.Floor(((Vit.Stat + Vit.StatAdd) * 0.25)) + " Defense");
                    tooltipText1.SetText((t[1] == '-') ? t.Substring(1) : t);
                    tooltip.Height.Set(85, 0f);
                } else if (MCost) {
                    string t = ("-" + (int) Math.Floor(((Att.Stat + Att.StatAdd) * 0.5)) + "% Mana Cost");
                    tooltipText1.SetText((t[1] == '+') ? t.Substring(1) : t);
                    tooltip.Height.Set(85, 0f);
                } else if (pyro) {
                    string t = ("+" + ((Fth.Stat + Fth.StatAdd < Int.Stat + Int.StatAdd) ? (Fth.Stat + Fth.StatAdd - 10) : (Int.Stat + Int.StatAdd - 10)) * 4 + "% Fire Damage");
                    tooltipText1.SetText((t[1] == '-') ? t.Substring(1) : t);
                    tooltip.Height.Set(85, 0f);
                } else {
                    tooltipText1.SetText(string.Empty);
                    tooltip.Height.Set(60, 0f);
                }
            }

            Recalculate();
            if (Player == null) return;
            if (int.Parse(Cost.Text) > Player.Souls) {
                Level.Parent.RemoveChild(Exit);
                Cost.TextColor = Color.Red;
            } else {
                Level.Parent.Append(Exit);
                Cost.TextColor = Color.White;
            }
        }

        private void setControls() {
            Main.playerInventory = false;

            Player p = Main.LocalPlayer;
            p.mouseInterface = true;
            p.talkNPC = -1;
            p.headcovered = true;
        }
    }
}