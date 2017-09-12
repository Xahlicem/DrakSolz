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

    class XPlayerUI : UIState {
        private UIPanel panel;
        private XahlicemPlayer Player {
            get {
                try {
                    return Main.LocalPlayer.GetModPlayer<XahlicemPlayer>();
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

            Texture2D texture = ModLoader.GetTexture("XahlicemMod/UI/AttributeGUI");
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
            Player.Souls -= int.Parse(Cost.Text);
            Player.Level = int.Parse(Level.Text);
            Player.Vit += Vit.StatAdd;
            Vit.Reset();
            Player.Str += Str.StatAdd;
            Str.Reset();
            Player.Dex += Dex.StatAdd;
            Dex.Reset();
            Player.Att += Att.StatAdd;
            Att.Reset();
            Player.Int += Int.StatAdd;
            Int.Reset();
            Player.Fth += Fth.StatAdd;
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
            if (!HasChild(tooltip)) Append(tooltip);
            if (Vit.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Vitality");
                s = ("+" + (Vit.Stat + Vit.StatAdd) * 10 + " Health");
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
            } else if (Int.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Intelligence");
                s = ("+" + (Int.Stat + Int.StatAdd - 20) * 2 + "% Magic Damage");
            } else if (Fth.icon.ContainsPoint(MousePosition)) {
                tooltipTitle.SetText("Faith");
                s = ("+" + (Fth.Stat + Fth.StatAdd - 20) * 2 + "% Summon Damage");
            } else RemoveChild(tooltip);
            if (HasChild(tooltip)) {
                tooltipText.SetText((s[1] == '-') ? s.Substring(1) : s);
                if (throwing) {
                    string t = ("+" + ((Dex.Stat + Dex.StatAdd < Str.Stat + Str.StatAdd) ? (Dex.Stat + Dex.StatAdd - 10) : (Str.Stat + Str.StatAdd - 10)) * 4 + "% Thrown Damage");
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

        private class StatPanel {
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

    class XUI : UIState {
        private bool RightClicking = false;
        private int RightTime = 0;
        private int Time = 0;
        public UIPanel panel;
        public UIText num, numLevel;
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

            numLevel = new UIText("0");
            numLevel.Left.Set(10, 0f);
            numLevel.Top.Set(10, 0f);
            numLevel.Width.Set(25, 0f);
            numLevel.Height.Set(25, 0f);
            numLevel.HAlign = UIAlign.Left;
            panel.Append(numLevel);

            Texture2D soulTex = ModLoader.GetTexture("XahlicemMod/Items/Craft/SoulSingle");
            UIImage soul = new UIImage(soulTex);
            soul.Left.Set(45, 0f);
            soul.Top.Set(10, 0f);
            soul.Width.Set(25, 0f);
            soul.Height.Set(25, 0f);
            panel.Append(soul);

            num = new UIText("0");
            num.Left.Set(60, 0f);
            num.Top.Set(10, 0f);
            num.Width.Set(65, 0f);
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

        public void updateValue(int carrying, int level) {
            num.SetText(carrying.ToString());
            numLevel.SetText(level.ToString());
            Recipe.FindRecipes();
        }
    }
}