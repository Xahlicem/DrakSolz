using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace DrakSolz {
    public class DrakSolzWorld : ModWorld {
        public enum Boss {
            //AbyssStalker,
            TitaniteDemon,
            VoidPillar
        }

        private Boss FindBossMatch(string boss) =>(Boss) Enum.Parse(typeof(Boss), boss, true);

        public static Dictionary<Boss, bool> downedBoss;

        private void Init() {
            if (downedBoss == null) {
                downedBoss = new Dictionary<Boss, bool>();
            }
            foreach (Boss boss in Enum.GetValues(typeof(Boss)).Cast<Boss>()) {
                downedBoss[boss] = false;
            }
        }

        public override void Initialize() {
            Init();
        }

        public override TagCompound Save() {
            var downed = new List<string>();

            foreach (var pair in downedBoss.Where(kvp => kvp.Value)) {
                string boss = pair.Key.ToString();
                downed.Add(char.ToLowerInvariant(boss[0]) + boss.Substring(1));
            }

            return new TagCompound {
                ["downed"] = downed
            };
        }

        public override void Load(TagCompound tag) {
            var downed = tag.GetList<string>("downed");
            foreach (string boss in downed) {
                try {
                    downedBoss[FindBossMatch(boss)] = true;
                } catch (Exception) {

                }
            }
        }

        public override void LoadLegacy(BinaryReader reader) {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0) {
                BitsByte flags = reader.ReadByte();

                foreach (Boss boss in Enum.GetValues(typeof(Boss)).Cast<Boss>()) {
                    downedBoss[boss] = flags[(int) boss];
                }
            } else {
                ErrorLogger.Log("DrakSolz: Unknown loadVersion: " + loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer) {
            int bossCount = Enum.GetNames(typeof(Boss)).Length;
            int allocations = (int) Math.Ceiling(bossCount / 8f);

            if (allocations > 0) {
                writer.Write(bossCount);
                writer.Write(allocations);

                BitsByte[] bits = new BitsByte[allocations];

                for (int i = 0; i < bossCount; i++) {
                    bits[i / 8][i % 8] = downedBoss[(Boss) i];
                }

                foreach (BitsByte b in bits) {
                    writer.Write(b);
                }
            }
        }

        //NetReceive is called before Initialize when joining a server
        public override void NetReceive(BinaryReader reader) {
            Init();

            int bossCount = reader.ReadInt32();
            int allocations = reader.ReadInt32();

            if (allocations > 0) {
                BitsByte[] bits = new BitsByte[allocations];

                for (int i = 0; i < allocations; i++) {
                    bits[i] = reader.ReadByte();
                }

                for (int i = 0; i < bossCount; i++) {
                    downedBoss[(Boss) i] = bits[i / 8][i % 8];
                }
            }
        }
        public override void ResetNearbyTileEffects() {
            DrakSolzPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<DrakSolzPlayer>(mod);
            modPlayer.VoidMonolith = false;
        }
    }

}