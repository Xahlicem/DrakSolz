using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Souls {
    public abstract class BossSoul : ModItem {
        public int Place { get; internal set; }
        public string Ring { get; internal set; }
        public int Ticks { get; internal set; }
        public int Total { get { return TicksToValue(); } }

        public BossSoul(int place, int value, string ring) {
            Place = 1 << place;
            Ticks = ValueToTicks(value);
            Ring = ring;
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

        private int TicksToValue() {
            int ret = 0;
            for (int i = Ticks; i > 0; i--) {
                if (i <= 40) ret += 25;
                else if (i <= 80) ret += 100;
                else if (i <= 130) ret += 500;
                else ret += 1000;
            }
            return ret;
        }

        private int ValueToTicks(int value) {
            int ret = 0;
            while (value > 0) {
                ret++;
                if (ret <= 40) value -= 25;
                else if (ret <= 80) value -= 100;
                else if (ret <= 130) value -= 500;
                else value -= 1000;
            }
            return ret;
        }
    }

    class BossSoulMod : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            Item item = new Item();
            switch (npc.type) {
                case NPCID.KingSlime:
                    item.netDefaults(mod.ItemType<SlimeSoul>());
                    break;
                case NPCID.EyeofCthulhu:
                    item.netDefaults(mod.ItemType<EyeSoul>());
                    break;
                case NPCID.EaterofWorldsHead:
                case NPCID.EaterofWorldsBody:
                case NPCID.EaterofWorldsTail:
                    if (!npc.boss) return;
                    item.netDefaults(mod.ItemType<EaterSoul>());
                    break;
                case NPCID.BrainofCthulhu:
                    item.netDefaults(mod.ItemType<BrainSoul>());
                    break;
                case NPCID.QueenBee:
                    item.netDefaults(mod.ItemType<BeeSoul>());
                    break;
                case NPCID.SkeletronHead:
                    item.netDefaults(mod.ItemType<SkeletronSoul>());
                    break;
                case NPCID.WallofFlesh:
                    item.netDefaults(mod.ItemType<WallSoul>());
                    break;
                case NPCID.TheDestroyer:
                    item.netDefaults(mod.ItemType<DestSoul>());
                    break;
                case NPCID.Retinazer:
                    item.netDefaults(mod.ItemType<RetSoul>());
                    break;
                case NPCID.Spazmatism:
                    item.netDefaults(mod.ItemType<SpazSoul>());
                    break;
                case NPCID.SkeletronPrime:
                    item.netDefaults(mod.ItemType<SkeletronPrimeSoul>());
                    break;
                case NPCID.Plantera:
                    item.netDefaults(mod.ItemType<PlantSoul>());
                    break;
                case NPCID.Golem:
                    item.netDefaults(mod.ItemType<GolemSoul>());
                    break;
                case NPCID.CultistBoss:
                    item.netDefaults(mod.ItemType<LunaticSoul>());
                    break;
                case NPCID.DukeFishron:
                    item.netDefaults(mod.ItemType<DukeSoul>());
                    break;
                case NPCID.MoonLordHand:
                case NPCID.MoonLordCore:
                case NPCID.MoonLordFreeEye:
                case NPCID.MoonLordHead:
                    if (!npc.boss) return;
                    item.netDefaults(mod.ItemType<MoonSoul>());
                    break;
            }

            if (npc.type == mod.NPCType<NPCs.Enemy.Boss.AbyssStalker>()) {
                item.netDefaults(mod.ItemType<ArtoriasSoul>());
            }

            if (npc.type == mod.NPCType<NPCs.Enemy.Boss.TitaniteDemon>()) {
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