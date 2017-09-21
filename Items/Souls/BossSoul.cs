using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public class BossSoul : ModItem {
        public int Place { get; internal set; }
        public string Ring { get; internal set; }
        public int Ticks { get; internal set; }
        public int Total { get { return TicksToInt(); } }

        public BossSoul(int place, int ticks, string ring) {
            Place = 1 << place;
            Ticks = ticks;
            Ring = ring;
        }
        public T CastExamp1<T>(object input) {
            return (T) input;
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Boss Soul");
            Tooltip.SetDefault("Soul of the Boss");
        }

        public override void SetDefaults() {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.ManaCrystal);
            item.width = refItem.width;
            item.height = refItem.height;
            item.useStyle = refItem.useStyle;
            item.UseSound = refItem.UseSound;
            item.useAnimation = 160;
            item.useTime = 160;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = 4;
            item.consumable = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            tooltips.Add(new TooltipLine(mod, "TotalSouls", "+" + Total + " Souls when consumed."));
        }

        public override bool CanUseItem(Player player) {
            if (item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer != player.whoAmI) return false;
            item.useAnimation = Ticks;
            item.useTime = Ticks;
            return true;
        }

        public override bool UseItem(Player player) {
            player.ManaEffect(Total);
            player.GetModPlayer<DrakSolzPlayer>().BossSoulTicks += Ticks;
            return true;
        }

        public override bool CanPickup(Player player) {
            int fromPlayer = item.GetGlobalItem<Items.DSGlobalItem>().FromPlayer;
            return (player.whoAmI == fromPlayer);
        }

        public override void AddRecipes() {
            if (Ring == string.Empty) return;
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.SetResult(mod.ItemType(Ring));
            recipe.AddTile(mod.TileType<Tiles.FirelinkShrineTile>());
            recipe.AddRecipe();
        }

        private int TicksToInt() {
            int ret = 0;
            for (int i = Ticks; i > 0; i--) {
                if (i <= 40) ret += 25;
                else if (i <= 80) ret += 100;
                else if (i <= 130) ret += 500;
                else ret += 1000;
            }
            return ret;
        }

        public override bool Autoload(ref string name) {
            return (GetType() == typeof (BossSoul)) ? false : base.Autoload(ref name);
        }
    }

    class BossSoulMod : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            Item item = new Item();
            switch (npc.type) {
                case NPCID.KingSlime:
                    item.netDefaults(mod.ItemType<Items.Souls.SlimeSoul>());
                    break;
                case NPCID.EyeofCthulhu:
                    item.netDefaults(mod.ItemType<Items.Souls.EyeSoul>());
                    break;
                case NPCID.EaterofWorldsHead:
                case NPCID.EaterofWorldsBody:
                case NPCID.EaterofWorldsTail:
                    if (!npc.boss) return;
                    item.netDefaults(mod.ItemType<Items.Souls.EaterSoul>());
                    break;
                case NPCID.BrainofCthulhu:
                    item.netDefaults(mod.ItemType<Items.Souls.BrainSoul>());
                    break;
                case NPCID.QueenBee:
                    item.netDefaults(mod.ItemType<Items.Souls.BeeSoul>());
                    break;
                case NPCID.SkeletronHead:
                    item.netDefaults(mod.ItemType<Items.Souls.SkeletronSoul>());
                    break;
                case NPCID.WallofFlesh:
                    item.netDefaults(mod.ItemType<Items.Souls.WallSoul>());
                    break;
                case NPCID.TheDestroyer:
                    item.netDefaults(mod.ItemType<Items.Souls.DestSoul>());
                    break;
                case NPCID.Retinazer:
                    item.netDefaults(mod.ItemType<Items.Souls.RetSoul>());
                    break;
                case NPCID.Spazmatism:
                    item.netDefaults(mod.ItemType<Items.Souls.SpazSoul>());
                    break;
                case NPCID.SkeletronPrime:
                    item.netDefaults(mod.ItemType<Items.Souls.SkeletronPrimeSoul>());
                    break;
                case NPCID.Plantera:
                    item.netDefaults(mod.ItemType<Items.Souls.PlantSoul>());
                    break;
                case NPCID.Golem:
                    item.netDefaults(mod.ItemType<Items.Souls.GolemSoul>());
                    break;
                case NPCID.CultistBoss:
                    item.netDefaults(mod.ItemType<Items.Souls.LunaticSoul>());
                    break;
                case NPCID.DukeFishron:
                    item.netDefaults(mod.ItemType<Items.Souls.DukeSoul>());
                    break;
                case NPCID.MoonLordHand:
                case NPCID.MoonLordCore:
                case NPCID.MoonLordFreeEye:
                case NPCID.MoonLordHead:
                    if (!npc.boss) return;
                    item.netDefaults(mod.ItemType<Items.Souls.MoonSoul>());
                    break;
            }

            if (npc.type == mod.NPCType<NPCs.Enemy.Abysswalker>()) {
                item.netDefaults(mod.ItemType<Items.Souls.ArtoriasSoul>());
            }

            if (npc.type == mod.NPCType<NPCs.Enemy.TitaniteDemon>()) {
                item.netDefaults(mod.ItemType<Items.Souls.TitaniteSoul>());
            }

            BossSoul soul = item.modItem as BossSoul;

            if (soul == null) return;

            List<int> players = new List<int>();
            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i] != null)
                    if (npc.WithinRange(Main.player[i].Center, 800f))
                        players.Add(Main.player[i].whoAmI);
            if (players.Count != 0)
                for (int i = 0; i < players.Count; i++) {
                    if ((Main.player[players[i]].GetModPlayer<DrakSolzPlayer>().BossSouls & soul.Place) > 0) continue;
                    int index = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, item.type);
                    Main.item[index].GetGlobalItem<Items.DSGlobalItem>().FromPlayer = players[i];
                    Main.player[players[i]].GetModPlayer<DrakSolzPlayer>().BossSouls |= soul.Place;
                }
        }
    }
}