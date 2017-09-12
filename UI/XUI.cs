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
        public UIImageButton Exit { get; set; }
        StatPanel Vit { get; set; }
        StatPanel Str { get; set; }
        StatPanel Dex { get; set; }
        StatPanel Att { get; set; }
        StatPanel Int { get; set; }
        StatPanel Fth { get; set; }

        public override void OnInitialize() {
            panel = new UIPanel();
            panel.SetPadding(0);
            panel.Left.Set((Main.screenWidth - 200) / 2, 0f);
            panel.Top.Set((Main.screenHeight - 150) / 2, 0f);
            panel.Width.Set(200, 0f);
            panel.Height.Set(150, 0f);
            panel.BackgroundColor = new Color(73, 94, 171);

            Level = new UIText("");
            Level.Left.Set(10, 0f);
            Level.Top.Set(10, 0f);
            Level.Width.Set(25, 0f);
            Level.Height.Set(25, 0f);
            Level.HAlign = UIAlign.Left;
            panel.Append(Level);

            Cost = new UIText("");
            Cost.Left.Set(40, 0f);
            Cost.Top.Set(10, 0f);
            Cost.Width.Set(120, 0f);
            Cost.Height.Set(25, 0f);
            Cost.HAlign = UIAlign.Left;
            panel.Append(Cost);

            Texture2D soulTex = ModLoader.GetTexture("XahlicemMod/Items/Craft/SoulSingle");
            Exit = new UIImageButton(soulTex);
            Exit.Left.Set(165, 0f);
            Exit.Top.Set(10, 0f);
            Exit.Width.Set(25, 0f);
            Exit.Height.Set(25, 0f);
            Exit.OnClick += Apply;
            panel.Append(Exit);

            Vit = new StatPanel(10, 45, panel);
            Str = new StatPanel(10, 80, panel);
            Dex = new StatPanel(10, 115, panel);
            Att = new StatPanel(115, 45, panel);
            Int = new StatPanel(115, 80, panel);
            Fth = new StatPanel(115, 115, panel);

            base.Append(panel);
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
            int level = Vit.Stat + Str.Stat + Dex.Stat + Att.Stat + Int.Stat + Fth.Stat;
            level += Vit.StatAdd + Str.StatAdd + Dex.StatAdd + Att.StatAdd + Int.StatAdd + Fth.StatAdd;
            int totalCost = 0;
            for (int i = 0; i < level; i++) {
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
            Main.playerInventory = false;
            Main.LocalPlayer.frozen = true;
            Main.LocalPlayer.headcovered = true;
            Main.LocalPlayer.mouseInterface = true;
            Main.LocalPlayer.talkNPC = -1;
            Recalculate();
            if (Player == null) return;
            if (int.Parse(Cost.Text) > Player.Souls) Level.Parent.RemoveChild(Exit);
            else Level.Parent.Append(Exit);
        }

        private class StatPanel {
            public int Stat { get; set; }
            public int StatAdd { get; set; }

            public UIText Up { get; set; }
            public UIText Down { get; set; }
            public UIText StatText { get; set; }

            public StatPanel(int x, int y, UIPanel panel) {
                Stat = 0;
                StatAdd = 0;

                Up = new UIText("-");
                Up.Left.Set(x, 0f);
                Up.Top.Set(y, 0f);
                Up.Width.Set(20, 0f);
                Up.Height.Set(25, 0f);
                Up.OnMouseOver += OnOver;
                Up.OnMouseOut += OnOut;
                Up.OnMouseDown += OnDown;
                Up.OnMouseUp += OnUp;
                Up.TextColor = Color.Gray;
                panel.Append(Up);

                StatText = new UIText("");
                StatText.Left.Set(x + 20, 0f);
                StatText.Top.Set(y, 0f);
                StatText.Width.Set(35, 0f);
                StatText.Height.Set(25, 0f);
                panel.Append(StatText);

                Down = new UIText("+");
                Down.Left.Set(x + 55, 0f);
                Down.Top.Set(y, 0f);
                Down.Width.Set(20, 0f);
                Down.Height.Set(25, 0f);
                Down.OnMouseOver += OnOver;
                Down.OnMouseOut += OnOut;
                Down.OnMouseDown += OnDown;
                Down.OnMouseUp += OnUp;
                Down.TextColor = Color.Gray;
                panel.Append(Down);
            }

            public void Set(int stat) {
                Stat = stat;
                Set();
            }

            public void Set() {
                if (StatAdd < 0) StatAdd = 0;
                StatText.SetText((Stat + StatAdd).ToString());
            }

            public void Reset() {
                StatAdd = 0;
                Set();
            }

            private void OnOver(UIMouseEvent evt, UIElement listeningElement) {
                UIText text = listeningElement as UIText;
                text.TextColor = Color.LightGray;
            }

            private void OnOut(UIMouseEvent evt, UIElement listeningElement) {
                UIText text = listeningElement as UIText;
                text.TextColor = Color.Gray;
            }

            private void OnDown(UIMouseEvent evt, UIElement listeningElement) {
                UIText text = listeningElement as UIText;
                text.TextColor = Color.White;
            }

            private void OnUp(UIMouseEvent evt, UIElement listeningElement) {
                UIText text = listeningElement as UIText;
                text.TextColor = Color.LightGray;
                if (text.Text.Equals("-")) StatAdd--;
                else StatAdd++;
                Set();
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