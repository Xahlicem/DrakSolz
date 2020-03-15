using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DrakSolz.Items {
    public class DSGlobalItem : GlobalItem {
        public long Owner { get; set; }

        public bool Owned { get; set; }
        public bool ArcaneRolled { get; set; }
        public int ArcaneMana { get; set; }
        public bool Used { get; set; }
        public bool Restricted { get; set; }
        public bool WrongOwner { get; set; }
        public override bool CloneNewInstances { get { return true; } }
        public override bool InstancePerEntity { get { return true; } }

        public DSGlobalItem() {
            ArcaneRolled = false;
            Restricted = false;
            WrongOwner = false;
        }

        public override GlobalItem Clone(Item item, Item itemClone) {
            var source = item.GetGlobalItem<DSGlobalItem>();
            var destination = itemClone.GetGlobalItem<DSGlobalItem>();
            if (source != null && destination != null) {
                destination.Owned = source.Owned;
                destination.Restricted = Restricted;
                destination.Used = source.Used;
                destination.Owner = Owner;
                destination.ArcaneRolled = ArcaneRolled;
                destination.ArcaneMana = ArcaneMana;
            }
            return destination;
        }

        public override void Update(Item item, ref float gravity, ref float maxFallSpeed) {
            if (Owner == 0L) Owner = -1L;
        }

        public override bool CanPickup(Item item, Player player) {
            bool owner = true;
            if (Restricted) owner = player.GetModPlayer<DrakSolzPlayer>().UID == Owner || Owner < 0;
            return base.CanPickup(item, player) && owner;
        }

        public override bool CanUseItem(Item item, Player player) {
            bool owner = true;
            if (Restricted) owner = player.GetModPlayer<DrakSolzPlayer>().UID == Owner;
            return base.CanUseItem(item, player) && owner;
        }

        public override void UpdateInventory(Item item, Player player) {
            if (Owner < 0) Owner = player.GetModPlayer<DrakSolzPlayer>().UID;
            if (!Restricted) return;
            WrongOwner = (item.GetGlobalItem<DSGlobalItem>().Owner != player.GetModPlayer<DrakSolzPlayer>().UID);
        }

        public override void OnCraft(Item item, Recipe recipe) {
            ReRoll(item);
            Owned = true;
        }

        public override bool UseItem(Item item, Player player) {
            Used = true;
            return base.UseItem(item, player);
        }

        public override void PostReforge(Item item) {
            ReRoll(item);
            Owner = Main.player[item.owner].GetModPlayer<DrakSolzPlayer>().UID;
            Owned = true;
        }

        public override bool OnPickup(Item item, Player player) {
            ReRoll(item);
            Owner = player.GetModPlayer<DrakSolzPlayer>().UID;
            Owned = true;
            return true;
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual) {
            ReRoll(item);
            if (ArcaneRolled)
                player.statManaMax2 += ArcaneMana * 5 + 5;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            ReRoll(item);
            if (ArcaneRolled) {
                string name = string.Empty;
                switch (ArcaneMana) {
                    case 0:
                        name = "Attuned ";
                        break;
                    case 1:
                        name = "Magic ";
                        break;
                    case 2:
                        name = "Runic ";
                        break;
                    case 3:
                        name = "Arcane ";
                        break;
                }
                for (int index = 0; index < tooltips.Count; index++) {
                    if (tooltips[index].Name.Equals("ItemName")) tooltips[index].text = name + item.Name;
                }
                TooltipLine t = new TooltipLine(mod, "PrefixAccMaxMana", "+" + (ArcaneMana * 5 + 5) + " mana");
                t.isModifier = true;
                tooltips.Add(t);
            }
            if (WrongOwner) {
                tooltips.Insert(0, new TooltipLine(mod, "DSOwner", "This Does not belong to you!"));
                tooltips[0].overrideColor = Color.Red;
            } else if (tooltips[0].Name == "DSOwner") tooltips.RemoveAt(0);
            //tooltips.Add(new TooltipLine(mod, "Owners", "Restricted:" + Restricted + " | Owner:" + Owner));
        }

        public override void NetSend(Item item, System.IO.BinaryWriter writer) {
            writer.Write(Owner);
            writer.Write(Restricted);
            writer.Write(Used);
            writer.Write(ArcaneRolled);
            writer.Write(ArcaneMana);
        }

        public override void NetReceive(Item item, System.IO.BinaryReader reader) {
            Owner = reader.ReadInt64();
            Restricted = reader.ReadBoolean();
            Used = reader.ReadBoolean();
            ArcaneRolled = reader.ReadBoolean();
            ArcaneMana = reader.ReadInt32();
        }

        public override bool NeedsSaving(Item item) {
            if (Restricted) return true;
            if ((item.type == 0 || item.consumable || item.ammo > 0 || item.type == ModLoader.GetMod("ModLoader").ItemType("MysteryItem")) && !(item.modItem is SoulItem)) {
                return false;
            }
            return true;
        }

        public override TagCompound Save(Item item) {
            if (item.type == 0 || item.type == ModLoader.GetMod("ModLoader").ItemType("MysteryItem")) {
                return null;
            }
            return new TagCompound { { "owned", Owned }, { "restricted", Restricted }, { "used", Used }, { "FromPlayer", Owner }, { "ArcaneRolled", ArcaneRolled }, { "ArcaneMana", ArcaneMana } };
        }

        public override void Load(Item item, TagCompound tag) {
            Owned = tag.GetBool("owned");
            Restricted = tag.GetBool("restricted");
            Used = tag.GetBool("used");
            Owner = tag.GetLong("FromPlayer");
            if (Owner == 0) Owner = Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().UID;;
            ArcaneRolled = tag.GetBool("ArcaneRolled");
            ArcaneMana = tag.GetInt("ArcaneMana");
        }

        private void ReRoll(Item item) {
            if (item.prefix != PrefixID.Arcane) return;
            item.prefix = 0;
            ArcaneMana = Main.rand.Next(4);
            ArcaneRolled = true;
        }
    }

    public abstract class SoulItem : ModItem {
        public int SoulValue { get; internal set; }

        public SoulItem(int value) {
            SoulValue = value;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            if (item.GetGlobalItem<DSGlobalItem>().Owned) return;
            tooltips[0].text += " (" + SoulValue + " Souls required)";
        }
    }

    public class SoulRecipe : ModRecipe {
        private int requiredSouls;
        public SoulRecipe(Mod mod, SoulItem result) : base(mod) {
            requiredSouls = result.SoulValue;
            SetResult(result);
        }

        public override bool RecipeAvailable() {
            return (Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().Souls >= requiredSouls);
        }

        public override void OnCraft(Item item) {
            Main.LocalPlayer.GetModPlayer<DrakSolzPlayer>().Souls -= requiredSouls;
        }
    }
}