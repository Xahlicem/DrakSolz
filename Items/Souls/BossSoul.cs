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
            item.value = 0;
            item.rare = ItemRarityID.LightRed;
            item.consumable = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            tooltips.Add(new TooltipLine(mod, "TotalSouls", "+" + Total + " Souls when consumed."));
        }

        public override bool CanUseItem(Player player) {
            if (item.GetGlobalItem<Items.DSGlobalItem>().Owner != player.GetModPlayer<DrakSolzPlayer>().UID) return false;
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
            return (player.GetModPlayer<DrakSolzPlayer>().UID == item.GetGlobalItem<Items.DSGlobalItem>().Owner);
        }

        public override void AddRecipes() {
            if (Ring == string.Empty) return;
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.SetResult(DrakSolz.instance.ItemType(Ring));
            recipe.AddTile(ModContent.TileType<Tiles.FirelinkShrineTile>());
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
            Item item2 = new Item();
            item2.netDefaults(ItemID.HealingPotion);
            switch (npc.type) {
                case NPCID.KingSlime:
                    item.netDefaults(ModContent.ItemType<SlimeSoul>());
                    item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
                    break;
                case NPCID.EyeofCthulhu:
                    item.netDefaults(ModContent.ItemType<EyeSoul>());
                    break;
                case NPCID.EaterofWorldsHead:
                case NPCID.EaterofWorldsBody:
                case NPCID.EaterofWorldsTail:
                    if (!npc.boss) return;
                    item.netDefaults(ModContent.ItemType<EaterSoul>());
                    break;
                case NPCID.BrainofCthulhu:
                    item.netDefaults(ModContent.ItemType<BrainSoul>());
                    break;
                case NPCID.QueenBee:
                    item.netDefaults(ModContent.ItemType<BeeSoul>());
                    item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
                    break;
                case NPCID.SkeletronHead:
                    item.netDefaults(ModContent.ItemType<SkeletronSoul>());
                    break;
                case NPCID.WallofFlesh:
                    item.netDefaults(ModContent.ItemType<WallSoul>());
                    item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
                    break;
                case NPCID.TheDestroyer:
                    item.netDefaults(ModContent.ItemType<DestSoul>());
                    break;
                case NPCID.Retinazer:
                    item.netDefaults(ModContent.ItemType<RetSoul>());
                    break;
                case NPCID.Spazmatism:
                    item.netDefaults(ModContent.ItemType<SpazSoul>());
                    break;
                case NPCID.SkeletronPrime:
                    item.netDefaults(ModContent.ItemType<SkeletronPrimeSoul>());
                    item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
                    break;
                case NPCID.Plantera:
                    item.netDefaults(ModContent.ItemType<PlantSoul>());
                    item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
                    break;
                case NPCID.Golem:
                    item.netDefaults(ModContent.ItemType<GolemSoul>());
                    break;
                case NPCID.CultistBoss:
                    item.netDefaults(ModContent.ItemType<LunaticSoul>());
                    item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
                    break;
                case NPCID.DukeFishron:
                    item.netDefaults(ModContent.ItemType<DukeSoul>());
                    item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
                    break;
                case NPCID.MoonLordHand:
                case NPCID.MoonLordCore:
                case NPCID.MoonLordFreeEye:
                case NPCID.MoonLordHead:
                    if (!npc.boss) return;
                    item.netDefaults(ModContent.ItemType<MoonSoul>());
                    item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
                    break;
            }

            if (npc.type == ModContent.NPCType<NPCs.Enemy.Boss.AbyssStalker>()) {
                item.netDefaults(ModContent.ItemType<ArtoriasSoul>());
                item2.netDefaults(ModContent.ItemType<Misc.EstusShard>());
            }

            if (npc.type == ModContent.NPCType<NPCs.Enemy.Boss.TitaniteDemon>()) {
                item.netDefaults(ModContent.ItemType<Items.Souls.TitaniteSoul>());
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
                    int index2 = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, item2.type);
                    Main.item[index].GetGlobalItem<Items.DSGlobalItem>().Owner = Main.player[players[i]].GetModPlayer<DrakSolzPlayer>().UID;
                    Main.player[players[i]].GetModPlayer<DrakSolzPlayer>().SetBossSouls(soul.Place);
                }
        }
    }
}