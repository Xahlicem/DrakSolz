using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using Terraria.World.Generation;

namespace DrakSolz.Tiles {
    public class LotteryMachine : ModItem {

        public override void SetStaticDefaults () {
            Tooltip.SetDefault ("Grants increased damage to 'On Fire' effects.");
        }

        public override void SetDefaults () {

            item.width = 46;
            item.height = 46;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.LotteryMachineTile> ();
        }
    }

    public class LotteryMachineTile : ModTile {
        public override void SetDefaults () {
            Main.tileLighted[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom (TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile (Type);

            ModTranslation name = CreateMapEntryName ();
            name.SetDefault ("LotteryMachine");
            AddMapEntry (new Color (250, 250, 0), name);

            dustType = DustID.Dirt;
            disableSmartCursor = true;
            minPick = 10;
        }
        public override void NumDust (int i, int j, bool fail, ref int num) {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile (int i, int j, int frameX, int frameY) {
            Item.NewItem (i * 16, j * 16, 32, 16, ModContent.ItemType<Tiles.LotteryMachine> ());
        }

        public override bool PreDraw (int i, int j, SpriteBatch spriteBatch) {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            if (Main.canDrawColorTile (i, j)) {
                texture = Main.tileTexture[Type];
            } else {
                texture = Main.tileTexture[Type];
            }
            Vector2 zero = new Vector2 (Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen) {
                zero = Vector2.Zero;
            }
            Main.spriteBatch.Draw (texture, new Vector2 (i * 16 - (int) Main.screenPosition.X, j * 16 - (int) Main.screenPosition.Y) + zero, new Rectangle (tile.frameX, tile.frameY, 16, 16), Lighting.GetColor (i, j), 0f, default (Vector2), 1f, SpriteEffects.None, 1f);
            return false;
        }

        public override bool NewRightClick (int i, int j) {
            HitWire (i, j);
            Player player = Main.LocalPlayer;
            foreach (Item g in player.inventory) {
                if (g.type == ItemID.GoldCoin) {
                    int c = (Main.rand.Next (12));
                    if (c == 11) {
                        int[] DItems = {ModContent.ItemType<Items.Accessory.PyromancerEmblem> (), ModContent.ItemType<Items.Accessory.RingCalamity> (), 
                        ModContent.ItemType<Items.Accessory.RingBlueTear> (), ModContent.ItemType<Items.Accessory.RingAvarice> (), ModContent.ItemType<Items.Accessory.RingBlades> (), 
                        ModContent.ItemType<Items.Accessory.RingCat> (), ModContent.ItemType<Items.Accessory.RingCharred> (), ModContent.ItemType<Items.Accessory.RingClearBlue> (), 
                        ModContent.ItemType<Items.Accessory.RingCloranthy> (), ModContent.ItemType<Items.Accessory.RingDarkGrain> (), ModContent.ItemType<Items.Accessory.RingDuskCrown> (), 
                        ModContent.ItemType<Items.Accessory.RingEvilEye> (), ModContent.ItemType<Items.Accessory.RingFavor> (), ModContent.ItemType<Items.Accessory.RingHavels> (), 
                        ModContent.ItemType<Items.Accessory.RingLoyds> (), ModContent.ItemType<Items.Accessory.RingMagicPower> (), ModContent.ItemType<Items.Accessory.RingMeleePower> (), 
                        ModContent.ItemType<Items.Accessory.RingPoisBite> (), ModContent.ItemType<Items.Accessory.RingPriestess> (), ModContent.ItemType<Items.Accessory.RingPyromancyPower> (), 
                        ModContent.ItemType<Items.Accessory.RingRangePower> (), ModContent.ItemType<Items.Accessory.RingRedTear> (), ModContent.ItemType<Items.Accessory.RingSteelProt> (),
                        ModContent.ItemType<Items.Accessory.RingSummonPower> (), ModContent.ItemType<Items.Accessory.RingThrowingPower> (), ModContent.ItemType<Items.Accessory.RingTinyBeing> (), 
                        ModContent.ItemType<Items.Accessory.SkullLantern> (), ModContent.ItemType<Items.Accessory.ThiefEmblem> (), ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherChest> (), 
                        ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherHelmet> (), ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherLeggings> (), ModContent.ItemType<Items.Armor.Artorias.ArtoriasArmor> (), 
                        ModContent.ItemType<Items.Armor.Artorias.ArtoriasHelmet> (), ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherLeggings> (), ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightArmor> (), 
                        ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightHelmet> (), ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightLeggings> (), ModContent.ItemType<Items.Armor.Channeler.ChannelerHelmet> (), 
                        ModContent.ItemType<Items.Armor.Channeler.ChannelerRobe> (), ModContent.ItemType<Items.Armor.Channeler.ChannelerSkirt> (), ModContent.ItemType<Items.Armor.Cornyx.CornyxRobe> (), 
                        ModContent.ItemType<Items.Armor.Cornyx.CornyxSkirt> (), ModContent.ItemType<Items.Armor.Cornyx.CornyxWrap> (), ModContent.ItemType<Items.Armor.Crimson.CrimsonHood> (), 
                        ModContent.ItemType<Items.Armor.Crimson.CrimsonRobe> (), ModContent.ItemType<Items.Armor.Crimson.CrimsonSkirt> (), ModContent.ItemType<Items.Armor.CrownoftheDarkSun> (), 
                        ModContent.ItemType<Items.Armor.DesertSorceress.SorceressHood> (), ModContent.ItemType<Items.Armor.DesertSorceress.SorceressSkirt> (), ModContent.ItemType<Items.Armor.DesertSorceress.SorceressTop> (), 
                        ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerChest> (), ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerHelmet> (), ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerLeggings> (), 
                        ModContent.ItemType<Items.Armor.Father.FatherMask> (), ModContent.ItemType<Items.Armor.Father.GiantArmor> (), ModContent.ItemType<Items.Armor.Father.GiantLeggings> (), 
                        ModContent.ItemType<Items.Armor.FireKeeper.FireKeeperMask> (), ModContent.ItemType<Items.Armor.FireKeeper.FireKeeperShirt> (), ModContent.ItemType<Items.Armor.FireKeeper.FireKeeperSkirt> (), 
                        ModContent.ItemType<Items.Armor.FireWitchHelmet> (), ModContent.ItemType<Items.Armor.GibbetBody> (), ModContent.ItemType<Items.Armor.GibbetHead> (), 
                        ModContent.ItemType<Items.Armor.GibbetLegs> (), ModContent.ItemType<Items.Armor.HardmodeFire.AdamantiteCrown> (), ModContent.ItemType<Items.Armor.HardmodeFire.ChlorophyteCrown> (), 
                        ModContent.ItemType<Items.Armor.HardmodeFire.CobaltCrown> (), ModContent.ItemType<Items.Armor.HardmodeFire.HallowedCrown> (), ModContent.ItemType<Items.Armor.HardmodeFire.MythrilCrown> (), 
                        ModContent.ItemType<Items.Armor.HardmodeFire.OrichalcumCrown> (), ModContent.ItemType<Items.Armor.HardmodeFire.PalladiumCrown> (), ModContent.ItemType<Items.Armor.HardmodeFire.TitaniumCrown> (), 
                        ModContent.ItemType<Items.Armor.HardmodeThrow.AdamantiteHeadgear> (), ModContent.ItemType<Items.Armor.HardmodeThrow.ChlorophyteHeadgear> (), ModContent.ItemType<Items.Armor.HardmodeThrow.CobaltHeadgear> (), 
                        ModContent.ItemType<Items.Armor.HardmodeThrow.HallowedHeadgear> (), ModContent.ItemType<Items.Armor.HardmodeThrow.MythrilHeadgear> (), ModContent.ItemType<Items.Armor.HardmodeThrow.OrichalcumHeadgear> (), 
                        ModContent.ItemType<Items.Armor.HardmodeThrow.PalladiumHeadgear> (), ModContent.ItemType<Items.Armor.HardmodeThrow.TitaniumHeadgear> (), ModContent.ItemType<Items.Armor.Havels.HavelsArmor> (), 
                        ModContent.ItemType<Items.Armor.Havels.HavelsHelmet> (), ModContent.ItemType<Items.Armor.Havels.HavelsLeggings> (), ModContent.ItemType<Items.Armor.Hollow.HollowLoin> (), 
                        ModContent.ItemType<Items.Armor.Hollow.HollowMask> (), ModContent.ItemType<Items.Armor.Hollow.HollowShirt> (), ModContent.ItemType<Items.Armor.Moonlight.MoonlightChest> (), 
                        ModContent.ItemType<Items.Armor.Moonlight.MoonlightHead> (), ModContent.ItemType<Items.Armor.Moonlight.MoonlightLeggings> (), ModContent.ItemType<Items.Armor.PaintingGuardian.PaintingGuardianHood> (), 
                        ModContent.ItemType<Items.Armor.PaintingGuardian.PaintingGuardianLeggings> (), ModContent.ItemType<Items.Armor.PaintingGuardian.PaintingGuardianRobe> (), ModContent.ItemType<Items.Armor.Paladin.PaladinArmor> (), 
                        ModContent.ItemType<Items.Armor.Paladin.PaladinHelmet> (), ModContent.ItemType<Items.Armor.Paladin.PaladinLeggings> (), ModContent.ItemType<Items.Armor.Pilgrim.PilgrimHood> (), 
                        ModContent.ItemType<Items.Armor.Pilgrim.PilgrimRobe> (), ModContent.ItemType<Items.Armor.Pilgrim.PilgrimWaistcloth> (), ModContent.ItemType<Items.Armor.Ringed.RingedArmor> (), 
                        ModContent.ItemType<Items.Armor.Ringed.RingedHelmet> (), ModContent.ItemType<Items.Armor.Ringed.RingedLeggings> (), ModContent.ItemType<Items.Armor.SilverKnight.SilverKnightArmor> (), 
                        ModContent.ItemType<Items.Armor.SilverKnight.SilverKnightHelmet> (), ModContent.ItemType<Items.Armor.SilverKnight.SilverKnightLeggings> (), ModContent.ItemType<Items.Armor.Tattered.TatteredBoots> (), 
                        ModContent.ItemType<Items.Armor.Tattered.TatteredHat> (), ModContent.ItemType<Items.Armor.Tattered.TatteredTunic> (), ModContent.ItemType<Items.Armor.Thorns.ThornsArmor> (), 
                        ModContent.ItemType<Items.Armor.Thorns.ThornsHelmet> (), ModContent.ItemType<Items.Armor.Thorns.ThornsLeggings> (), ModContent.ItemType<Items.Armor.TitaniteHead> (), 
                        ModContent.ItemType<Items.Armor.Void.VoidChest> (), ModContent.ItemType<Items.Armor.Void.VoidLeggings> (), ModContent.ItemType<Items.Armor.Void.VoidMask> (), 
                        ModContent.ItemType<Items.Armor.Xanthous.XanthousCrown> (), ModContent.ItemType<Items.Armor.Xanthous.XanthousOvercoat> (), ModContent.ItemType<Items.Armor.Xanthous.XanthousWaistcloth> (), 
                        ModContent.ItemType<Items.Banners.BlackKnightBanner> (), ModContent.ItemType<Items.Banners.ChannelerBanner> (), ModContent.ItemType<Items.Banners.ChickenBanner> (), 
                        ModContent.ItemType<Items.Banners.CrystalLizardBanner> (), ModContent.ItemType<Items.Banners.CthulhunBanner> (), ModContent.ItemType<Items.Banners.DesertSorceressBanner> (), 
                        ModContent.ItemType<Items.Banners.DragonSlayerBanner> (), ModContent.ItemType<Items.Banners.FlameWarmageBanner> (), ModContent.ItemType<Items.Banners.GiantCrystalLizardBanner> (), 
                        ModContent.ItemType<Items.Banners.HollowBanner> (), ModContent.ItemType<Items.Banners.HollowDogBanner> (), ModContent.ItemType<Items.Banners.HumanityBanner> (), 
                        ModContent.ItemType<Items.Banners.InhumanityBanner> (), ModContent.ItemType<Items.Banners.LittleMushroomBanner> (), ModContent.ItemType<Items.Banners.ManEaterShellBanner> (), 
                        ModContent.ItemType<Items.Banners.MoonButterflyBanner> (), ModContent.ItemType<Items.Banners.NightMareBanner> (), ModContent.ItemType<Items.Banners.NinjaBanner> (), 
                        ModContent.ItemType<Items.Banners.PursuerBanner> (), ModContent.ItemType<Items.Banners.RavelordBanner> (), ModContent.ItemType<Items.Banners.RingedKnightBanner> (), 
                        ModContent.ItemType<Items.Banners.SilverKnightBanner> (), ModContent.ItemType<Items.Banners.SpinwheelBanner> (), ModContent.ItemType<Items.Banners.VoidEaterBanner> (), 
                        ModContent.ItemType<Items.Banners.VoidlingBanner> (), ModContent.ItemType<Items.Banners.VoidWalkerBanner> (), ModContent.ItemType<Items.Banners.WheelSkeletonBanner> (), 
                        ModContent.ItemType<Items.BoneWheel> (), ModContent.ItemType<Items.Magic.ADagger> (), ModContent.ItemType<Items.Magic.ArcaneShiv> (), 
                        ModContent.ItemType<Items.Magic.Holy.DivineSpearFragment> (), ModContent.ItemType<Items.Magic.Holy.LightningArrow> (), ModContent.ItemType<Items.Magic.Holy.RitualSpearFragment> (), 
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyForce> (), ModContent.ItemType<Items.Magic.Holy.ScrollHolyGnash> (), ModContent.ItemType<Items.Magic.Holy.ScrollHolyGnaw> (), 
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyGreatLightningSpear> (), ModContent.ItemType<Items.Magic.Holy.ScrollHolyLightningSpear> (), ModContent.ItemType<Items.Magic.Holy.ScrollHolySunlightSpear> (), 
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyWhiteCorona> (), ModContent.ItemType<Items.Magic.Holy.ScrollHolyWrathofGods> (), ModContent.ItemType<Items.Magic.IE> (), 
                        ModContent.ItemType<Items.Magic.IT> (), ModContent.ItemType<Items.Magic.MagnetSphere.ElectricSphere> (), ModContent.ItemType<Items.Magic.MagnetSphere.FulminatingSphere> (), 
                        ModContent.ItemType<Items.Magic.MoonGS> (), ModContent.ItemType<Items.Magic.Pyro.DemonsScar> (), ModContent.ItemType<Items.Magic.Pyro.FlameFan> (), 
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollAcidSurge> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollBlackFireball> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollBlackFlame> (), 
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollBurstingFireBall> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollChaosStorm> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollChaosWhip> (), 
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollCombustion> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireBall> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireStorm> (), 
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireSurge> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireWhip> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollFlameWeapon> (), 
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollFloatingChaos> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollImmolation> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollLingeringFlame> (), 
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollPoison> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollProfanedFlame> (), ModContent.ItemType<Items.Magic.Pyro.PyroScrollToxin> (), 
                        ModContent.ItemType<Items.Magic.Pyro.PyroTorch> (), ModContent.ItemType<Items.Magic.ScrollGreatSword> (), ModContent.ItemType<Items.Magic.ScrollHomingCrystalSoulMass> (), 
                        ModContent.ItemType<Items.Magic.ScrollHomingSoulMass> (), ModContent.ItemType<Items.Magic.ScrollSpear> (), ModContent.ItemType<Items.Magic.ScrollSpearBarrage> (), 
                        ModContent.ItemType<Items.Magic.ScrollSword> (), ModContent.ItemType<Items.Magic.SoulArrow.ScrollSoulArrow> (), ModContent.ItemType<Items.Magic.SoulArrow.ScrollSoulArrowGreat> (), 
                        ModContent.ItemType<Items.Magic.SoulArrow.ScrollSoulDart> (), ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades> (), ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades1> (), 
                        ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades2> (), ModContent.ItemType<Items.Melee.ArtoriasSword> (), ModContent.ItemType<Items.Melee.BlackKnightHalberd> (), 
                        ModContent.ItemType<Items.Melee.ChannelT> (), ModContent.ItemType<Items.Melee.CrowTalon> (), ModContent.ItemType<Items.Melee.DragonSlayerSpear> (), 
                        ModContent.ItemType<Items.Melee.GravelordSword> (), ModContent.ItemType<Items.Melee.KeroKhi> (), ModContent.ItemType<Items.Melee.Khi> (), 
                        ModContent.ItemType<Items.Melee.Lament> (), ModContent.ItemType<Items.Melee.MorianBlade> (), ModContent.ItemType<Items.Melee.OnyxBlade> (), 
                        ModContent.ItemType<Items.Melee.QrowQuills> (), ModContent.ItemType<Items.Melee.SpearOfCthulhu> (), ModContent.ItemType<Items.Melee.SplitLeaf> (), 
                        /*ModContent.ItemType<Items.Melee.SwordHilt> (),*/ ModContent.ItemType<Items.Melee.TitanitePole> (), ModContent.ItemType<Items.Misc.Classes.ClassEmpty> (), 
                        ModContent.ItemType<Items.Misc.CoalBlue> (), ModContent.ItemType<Items.Misc.CoalLord> (), ModContent.ItemType<Items.Misc.CoalRed> (), 
                        ModContent.ItemType<Items.Misc.CoalWhite> (), ModContent.ItemType<Items.Misc.CoalYellow> (), ModContent.ItemType<Items.Misc.CovenentArterRias> (), 
                        ModContent.ItemType<Items.Misc.CrystalPet> (), ModContent.ItemType<Items.Misc.CthulhunEmbryo> (), ModContent.ItemType<Items.Misc.CthulhunTentacle> (), 
                        ModContent.ItemType<Items.Misc.DemonTitanite> (), ModContent.ItemType<Items.Misc.EstusShard> (), ModContent.ItemType<Items.Misc.GreenBlossom> (), 
                        ModContent.ItemType<Items.Misc.HomewardBone> (), ModContent.ItemType<Items.Misc.InfernoBar> (), ModContent.ItemType<Items.Misc.Lifegem> (), 
                        ModContent.ItemType<Items.Misc.MoonButterflyHorn> (), ModContent.ItemType<Items.Misc.PrismStone> (), ModContent.ItemType<Items.Misc.PyroScroll> (), 
                        ModContent.ItemType<Items.Misc.PyroScrollIron> (), ModContent.ItemType<Items.Misc.PyroScrollPower> (), ModContent.ItemType<Items.Misc.PyroScrollWarmth> (), 
                        ModContent.ItemType<Items.Misc.Scroll> (), ModContent.ItemType<Items.Misc.ScrollCastLight> (), ModContent.ItemType<Items.Misc.ScrollFallControl> (), 
                        ModContent.ItemType<Items.Misc.ScrollHiddenBody> (), ModContent.ItemType<Items.Misc.ScrollHoly> (), ModContent.ItemType<Items.Misc.ScrollHolyHeal> (), 
                        ModContent.ItemType<Items.Misc.ScrollHolyHomeward> (), ModContent.ItemType<Items.Misc.ScrollHolyMajorHeal> (), ModContent.ItemType<Items.Misc.ScrollHolyMinorHeal> (), 
                        ModContent.ItemType<Items.Misc.ScrollHolyRegen> (), ModContent.ItemType<Items.Misc.ScrollRemedy> (), ModContent.ItemType<Items.Misc.ScrollVelocity> (), 
                        ModContent.ItemType<Items.Misc.Titanite> (), ModContent.ItemType<Items.Misc.Twink> (), ModContent.ItemType<Items.Misc.VoidFragment> (), 
                        ModContent.ItemType<Items.Ranged.DragonslayerGreatarrow> (), ModContent.ItemType<Items.Ranged.DragonslayerGreatbow> (), ModContent.ItemType<Items.Ranged.GoldenSlingshot> (), 
                        ModContent.ItemType<Items.Ranged.Moltenshot> (), ModContent.ItemType<Items.Ranged.ReinforcedSlingshot> (), ModContent.ItemType<Items.Ranged.Slingshot> (), 
                        ModContent.ItemType<Items.Ranged.SlingshotStones> (), ModContent.ItemType<Items.Summon.Consumable.PossesedArmorHelmet> (), ModContent.ItemType<Items.Summon.Consumable.SkeletonSkull> (), 
                        ModContent.ItemType<Items.Summon.Consumable.XahlicemEye> (), ModContent.ItemType<Items.Summon.Consumable.ZombieHand> (), ModContent.ItemType<Items.Summon.EffigyStaff> (), 
                        ModContent.ItemType<Items.Summon.SoulSummonStaff> (), ModContent.ItemType<Items.Throwing.BlackFireBomb> (), ModContent.ItemType<Items.Throwing.FireBomb> (), 
                        ModContent.ItemType<Items.Throwing.SolarEclipse> (), ModContent.ItemType<Tiles.FirelinkShrine> (), ModContent.ItemType<Tiles.LordVessel> (), 
                        ModContent.ItemType<Tiles.LotteryMachine> (), ModContent.ItemType<Tiles.ThrowingTarget> ()};
                        Item.NewItem (player.position, player.width, player.height, Utils.SelectRandom (Main.rand, DItems));
                    return true;
                    }
                    else{
                    int r = (Main.rand.Next (3929));
                    Item.NewItem (player.position, player.width, player.height, r);
                    g.stack -= 1;
                    return true;
                    }
                }
            }
            return false;
        }

        public override void MouseOver (int i, int j) {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<Tiles.LotteryMachine> ();
        }

        public override void HitWire (int i, int j) {
            int x = i - (Main.tile[i, j].frameX / 18) % 2;
            int y = j - (Main.tile[i, j].frameY / 18) % 3;
            for (int l = x; l < x + 2; l++) {
                for (int m = y; m < y + 3; m++) {
                    if (Main.tile[l, m] == null) {
                        Main.tile[l, m] = new Tile ();
                    }
                }
            }
            if (Wiring.running) {
                Wiring.SkipWire (x, y);
                Wiring.SkipWire (x, y + 1);
                Wiring.SkipWire (x, y + 2);
                Wiring.SkipWire (x + 1, y);
                Wiring.SkipWire (x + 1, y + 1);
                Wiring.SkipWire (x + 1, y + 2);
            }
            NetMessage.SendTileSquare (-1, x, y + 1, 3);
        }
    }
}