using System;
using System.Collections.Generic;
using System.IO;
using DrakSolz.Items;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz {

    public class DrakSolzPlayer : ModPlayer {
        private long _uid;
        public long UID { get { if (_uid == 0) _uid = DateTime.Now.Ticks; return _uid; } set { _uid = value; } }
        private static readonly int HURT_WAIT_MAX = 3600;
        public int HurtWait { get; internal set; }
        public int HurtWaitDec { get; internal set; }
        public int Hollow { get; internal set; }
        public int HollowDec { get; internal set; }

        public int Level { get { return Vit + Str + Dex + Att + Int + Fth; } }
        public int Souls { get; set; }
        public int SoulCost(int level) {
            if (level < 20) {
                return (int) (Math.Round((Math.Pow(0.02 * level, 3) + Math.Pow(4.06 * level, 2) + 105.6 * level) * 0.1, 0) * 4);
            } else if (level < 40) {
                return (int) (Math.Round((Math.Pow(0.02 * level, 3) + Math.Pow(4.06 * level, 2) + 105.6 * level) * 0.1, 0) * 10);
            } else if (level < 60) {
                return (int) (Math.Round((Math.Pow(0.02 * level, 3) + Math.Pow(4.06 * level, 2) + 105.6 * level) * 0.1, 0) * 17);
            } else if (level < 80) {
                return (int) (Math.Round((Math.Pow(0.02 * level, 3) + Math.Pow(4.06 * level, 2) + 105.6 * level) * 0.1, 0) * 25);
            } else {
                return (int) (Math.Round((Math.Pow(0.02 * level, 3) + Math.Pow(4.06 * level, 2) + 105.6 * level) * 0.1, 0) * 30);
            }
        }

        public long Stats { get; set; }
        private static readonly byte VIT = 0 * 7;
        private static readonly byte STR = 1 * 7;
        private static readonly byte DEX = 2 * 7;
        private static readonly byte ATT = 3 * 7;
        private static readonly byte INT = 4 * 7;
        private static readonly byte FTH = 5 * 7;
        private static readonly byte BOSS_SOULS = 6 * 7;
        private static readonly byte COALS = 6 * 7 + 17;

        public int Vit { get { return (int) (Stats >> VIT & 127L); } set { Stats = Stats & ~(127L << VIT) | ((uint) value & 127L) << VIT; } }
        public int Str { get { return (int) (Stats >> STR & 127L); } set { Stats = Stats & ~(127L << STR) | ((uint) value & 127L) << STR; } }
        public int Dex { get { return (int) (Stats >> DEX & 127L); } set { Stats = Stats & ~(127L << DEX) | ((uint) value & 127L) << DEX; } }
        public int Att { get { return (int) (Stats >> ATT & 127L); } set { Stats = Stats & ~(127L << ATT) | ((uint) value & 127L) << ATT; } }
        public int Int { get { return (int) (Stats >> INT & 127L); } set { Stats = Stats & ~(127L << INT) | ((uint) value & 127L) << INT; } }
        public int Fth { get { return (int) (Stats >> FTH & 127L); } set { Stats = Stats & ~(127L << FTH) | ((uint) value & 127L) << FTH; } }
        public int BossSouls { get { return (int) (Stats >> BOSS_SOULS & 127L); } set { Stats = Stats & ~(127L << BOSS_SOULS) | ((uint) value & 127L) << BOSS_SOULS; } }
        public int Coals { get { return (int) (Stats >> COALS & 127L); } set { Stats = Stats & ~(127L << COALS) | ((uint) value & 127L) << COALS; } }

        public float SoulTicks { get; set; }
        public int BossSoulTicks { get; set; }

        public bool ZoneTowerVoidPillar;
        public bool VoidMonolith = false;

        public bool SoulSummon { get; set; }
        public bool HumSummon { get; set; }
        public bool SunSummon { get; set; }
        public bool IceSummon { get; set; }
        public bool FireSummon { get; set; }
        public bool DungeonSummon { get; set; }
        public bool SoulMassSum { get; set; }

        public bool CrystalPet { get; set; }

        public bool EvilEye { get; set; }
        public int Avarice { get; set; }
        public int MiscHP { get; set; }
        public int Estus { get; set; }
        public bool Rotate { get; set; }
        public float Rotation { get; set; }

        public override void Initialize() {
            UID = 0;

            HurtWait = 0;
            HurtWaitDec = 1;
            Hollow = 0;
            HollowDec = 1;

            Souls = 0;
            Stats = 0;

            SoulTicks = 0;
            BossSoulTicks = 0;

            SoulSummon = false;
            HumSummon = false;
            SunSummon = false;
            IceSummon = false;
            FireSummon = false;
            DungeonSummon = false;
            SoulMassSum = false;
            CrystalPet = false;
            EvilEye = false;
            Avarice = 0;
            Estus = 0;

            Rotation = 0f;
        }

        public override void ResetEffects() {
            MiscHP = 0;
            SoulSummon = false;
            HumSummon = false;
            SunSummon = false;
            IceSummon = false;
            FireSummon = false;
            DungeonSummon = false;
            SoulMassSum = false;
            EvilEye = false;
            Avarice = 0;
            Rotate = false;

            player.fullRotationOrigin = player.Center - player.position;
            player.fullRotation = Rotation;
        }

        public void SetBossSouls(int place) {
            BossSouls |= place;
            SendPacket(MessageType.Stats);
        }

        public override void PreUpdate() {
            if (SoulTicks > 0) {
                float num = 0.5f;
                if (SoulTicks >= 10000) num = 10000;
                else if (SoulTicks >= 1000) num = 1000;
                else if (SoulTicks >= 100) num = 100;
                else if (SoulTicks >= 10) num = 5;
                SoulTicks -= num;
                if (num == 0.5f && SoulTicks % 1 != 0f) num = 1;
                Souls += ((int) Math.Floor(num));
            }

            if (BossSoulTicks > 0) {
                if (BossSoulTicks <= 40) Souls += 25;
                else if (BossSoulTicks <= 80) Souls += 100;
                else if (BossSoulTicks <= 130) Souls += 500;
                else Souls += 1000;
                BossSoulTicks--;
                Main.dust[Dust.NewDust(player.position, player.width, player.height, DustID.AncientLight)].noGravity = true;
            }
        }

        public override void UpdateBiomes() {
            ZoneTowerVoidPillar = false;
            if (!player.ZoneTowerSolar && !player.ZoneTowerVortex && !player.ZoneTowerNebula && !player.ZoneTowerStardust) {
                for (int i = 0; i < Main.maxNPCs; i++) {
                    var npc = Main.npc[i];
                    if (npc != null && npc.active && npc.type == ModContent.NPCType<NPCs.Enemy.VoidPillar.VoidPillar>() && player.Distance(npc.Center) <= 4000f) {
                        ZoneTowerVoidPillar = true;
                    }
                }
            }
        }

        public override bool CustomBiomesMatch(Player other) {
            var modOther = other.GetModPlayer<DrakSolzPlayer>();
            return ZoneTowerVoidPillar == modOther.ZoneTowerVoidPillar;
        }

        public override void CopyCustomBiomesTo(Player other) {
            var modOther = other.GetModPlayer<DrakSolzPlayer>();
            modOther.ZoneTowerVoidPillar = ZoneTowerVoidPillar;
        }

        public override void SendCustomBiomes(BinaryWriter writer) {
            byte flags = 0;
            if (ZoneTowerVoidPillar) {
                flags |= 1;
            }
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader) {
            byte flags = reader.ReadByte();
            ZoneTowerVoidPillar = ((flags & 1) == 1);
        }

        public override void UpdateBiomeVisuals() {
            DrakSolzPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<DrakSolzPlayer>();
            bool useWhite = ZoneTowerVoidPillar || VoidMonolith;
            player.ManageSpecialBiomeVisuals("DrakSolz:VoidPillar", useWhite);
        }

        public override void ProcessTriggers(TriggersSet triggersSet) { }

        public override void SetControls() {
            if (UI.PlayerUI.visible) {
                player.controlDown = false;
                player.controlUp = false;
                player.controlLeft = false;
                player.controlRight = false;
                player.controlMount = false;
                player.controlThrow = false;
                player.controlSmart = false;
                player.controlTorch = false;
                player.controlMap = false;
                player.controlHook = false;
                player.controlInv = false;
                player.controlJump = false;
                player.controlQuickHeal = false;
                player.controlQuickMana = false;
                player.controlUseItem = false;
                player.controlUseTile = false;
            }
        }

        public override void PostUpdateBuffs() {
            if (player.armor[0].type == ModContent.ItemType<Items.Armor.Channeler.ChannelerHelmet>() &&
                player.armor[1].type == ModContent.ItemType<Items.Armor.Channeler.ChannelerRobe>() &&
                player.armor[2].type == ModContent.ItemType<Items.Armor.Channeler.ChannelerSkirt>())
                player.extraAccessorySlots += 1;
        }

        public override void PostUpdateEquips() {
            UpdateStats();
        }

        public override void PostUpdate() {
            if (player.Equals(Main.LocalPlayer)) (mod as DrakSolz).ui.updateValue(Souls, Level);

            if (Rotate) Rotation += player.velocity.X * 0.025f;
            else Rotation = 0f;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            HurtWait = HURT_WAIT_MAX;
            Hollow += (int) (damage * 120.0);

            if (Main.netMode != NetmodeID.SinglePlayer)
                SendPacket(MessageType.Hurt);
        }

        public override void UpdateDead() {
            Hollow += 30;
            HurtWait = HURT_WAIT_MAX;
            UpdateHollow();
            SendPacket(MessageType.Hurt);

            if (Souls != 0) {
                SendPacket(MessageType.Souls);
                int i = Item.NewItem((int) player.position.X, (int) player.position.Y, player.width, player.height, ModContent.ItemType<Items.Souls.Soul>(), Souls);
                Main.item[i].GetGlobalItem<Items.DSGlobalItem>().Owner = UID;
                Souls = 0;
                if (player.Equals(Main.LocalPlayer)) (mod as DrakSolz).ui.updateValue(Souls, Level);
            }
        }

        public void LevelUp(int strength, int dexterity, int intelligence, int faith, int vitality, int attunement) {
            Str += strength;
            Dex += dexterity;
            Int += intelligence;
            Fth += faith;
            Vit += vitality;
            Att += attunement;

            SendPacket(MessageType.Stats);
        }
        private void UpdateStats() {
            player.meleeDamage *= 0.6f + Str * 0.02f;;
            player.rangedDamage *= 0.6f + Dex * 0.02f;;
            player.thrownDamage *= 0.6f + ((Str < Dex) ? Str : Dex) * 0.04f;;
            player.GetModPlayer<MPlayer>().pyromancyDamage *= 0.6f + ((Int < Fth) ? Int : Fth) * 0.04f;;
            player.magicDamage *= 0.6f + Int * 0.02f;;
            player.minionDamage *= 0.6f + Fth * 0.02f;;
            player.statLifeMax = Level * 4 + 100 + MiscHP;
            player.statLifeMax2 = player.statLifeMax + Vit * 11;
            player.statManaMax = 0;
            player.statManaMax2 += Att * 5;
            player.manaCost *= 1 - (Att * 0.005f);
            player.statDefense += (int) Math.Floor(Vit * 0.25f);

            UpdateHollow();
        }

        public void DecreaseHollow(int amount) {
            if (player.HasBuff(ModContent.BuffType<Buffs.WarmthBuff>()) || player.HasBuff(ModContent.BuffType<Buffs.Firelink>())) {
                amount *= 3;
            }
            Hollow -= amount;
            if (Hollow < 0) Hollow = 0;
        }

        public void DecreaseHurtWait(int amount) {
            if (player.HasBuff(ModContent.BuffType<Buffs.WarmthBuff>()) || player.HasBuff(ModContent.BuffType<Buffs.Firelink>()) || player.HasBuff(ModContent.BuffType<Buffs.FirelinkKeep>())) {
                amount *= 20;
            }
            HurtWait -= amount;
            if (HurtWait < 0) HurtWait = 0;
        }

        private void UpdateHollow() {
            HurtWaitDec = 1;
            if (player.FindBuffIndex(BuffID.Regeneration) != -1) HurtWaitDec++;
            DecreaseHurtWait(HurtWaitDec);

            HollowDec = 1;
            if (player.FindBuffIndex(BuffID.Regeneration) != -1) HollowDec++;
            if (HurtWait == 0 && Hollow > 0) DecreaseHollow(HollowDec);

            if (Hollow > 0) player.AddBuff(ModContent.BuffType<Buffs.Hollow>(), (Hollow / HollowDec) + (HurtWait / HurtWaitDec));
            int life = (int) ((Hollow + 1) / 300f);
            player.statLifeMax2 -= life;
            int min = 20 + Vit * 5;
            if (player.statLifeMax2 < min) player.statLifeMax2 = min;

            if (Hollow == 0 && player.FindBuffIndex(ModContent.BuffType<Buffs.Hollow>()) != -1) player.ClearBuff(ModContent.BuffType<Buffs.Hollow>());
        }

        public override TagCompound Save() {
            TagCompound save = new TagCompound();
            save.Add("UID", UID);
            save.Add("HurtWait", HurtWait);
            save.Add("Hollow", Hollow);
            save.Add("Souls", Souls);
            save.Add("Stats", Stats);
            save.Add("Estus", Estus);
            return save;
        }

        public override void Load(TagCompound tag) {
            _uid = tag.GetLong("UID");
            HurtWait = tag.GetInt("HurtWait");
            Hollow = tag.GetInt("Hollow");
            Souls = tag.GetInt("Souls");
            Stats = tag.GetLong("Stats");
            Estus = tag.GetInt("Estus");

        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
            items.Clear();
            Item item = new Item();
            item.netDefaults(ModContent.ItemType<Items.Melee.Sword>());
            item.GetGlobalItem<DSGlobalItem>().Owned = true;
            item.GetGlobalItem<DSGlobalItem>().Owner = UID;
            items.Add(item);
            Item item2 = new Item();
            item2.netDefaults(ModContent.ItemType<Items.Misc.EstusFlask>());
            item2.GetGlobalItem<DSGlobalItem>().Owned = true;
            item2.GetGlobalItem<DSGlobalItem>().Owner = UID;
            items.Add(item2);
            Item item3 = new Item();
            item3.netDefaults(ModContent.ItemType<Items.Misc.Classes.ClassEmpty>());
            item3.GetGlobalItem<DSGlobalItem>().Owned = true;
            item3.GetGlobalItem<DSGlobalItem>().Owner = UID;
            items.Add(item3);
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
            SendPacket(MessageType.Hurt, toWho, fromWho);
            SendPacket(MessageType.Stats, toWho, fromWho);
            SendPacket(MessageType.UID, toWho, fromWho);
            SendPacket(MessageType.Souls, toWho, fromWho);
        }

        public override void clientClone(ModPlayer clone) {
            base.clientClone(clone);
            DrakSolzPlayer p = clone as DrakSolzPlayer;
            p.Stats = Stats;
            p.UID = UID;
            p.Souls = Souls;
        }

        public override void SendClientChanges(ModPlayer clientPlayer) {
            DrakSolzPlayer client = clientPlayer as DrakSolzPlayer;
            if (client.Stats != Stats) SendPacket(MessageType.Stats);
            if (client.UID != UID) SendPacket(MessageType.UID);
            if (client.Souls != Souls) SendPacket(MessageType.Souls);
        }

        public override void OnEnterWorld(Player player) {
            Main.NewText(UID);
            foreach (Item i in player.inventory)
                if (i.type > 0 && i.GetGlobalItem<DSGlobalItem>().Owner == 0) i.GetGlobalItem<DSGlobalItem>().Owner = UID;
        }

        public void SendPacket(MessageType packetType, int toWho = -1, int fromWho = -1) {
            if (Main.netMode == NetmodeID.SinglePlayer) return;

            ModPacket packet = this.mod.GetPacket();

            packet.Write((byte) packetType);
            packet.Write((byte) this.player.whoAmI);
            if (packetType == MessageType.Stats) {
                packet.Write(Stats);
            }
            if (packetType == MessageType.Hurt) {
                packet.Write(HurtWait);
                packet.Write(Hollow);
            }
            if (packetType == MessageType.UID) {
                packet.Write(UID);
            }
            if (packetType == MessageType.Souls) {
                packet.Write(Souls);
            }
            packet.Send(toWho, fromWho);
        }
    }
}