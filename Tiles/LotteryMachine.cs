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

        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Spend gold coins for a chance to get lucky!");
        }

        public override void SetDefaults() {

            item.width = 46;
            item.height = 46;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.LotteryMachineTile>();
        }
    }

    public class LotteryMachineTile : ModTile {
        public override void SetDefaults() {
            Main.tileLighted[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("LotteryMachine");
            AddMapEntry(new Color(250, 250, 0), name);

            dustType = DustID.Dirt;
            disableSmartCursor = true;
            minPick = 10;
        }
        public override void NumDust(int i, int j, bool fail, ref int num) {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY) {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Tiles.LotteryMachine>());
        }

        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) {
            Tile tile = Main.tile[i, j];
            Texture2D texture;
            if (Main.canDrawColorTile(i, j)) {
                texture = Main.tileTexture[Type];
            } else {
                texture = Main.tileTexture[Type];
            }
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen) {
                zero = Vector2.Zero;
            }
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int) Main.screenPosition.X, j * 16 - (int) Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, 16), Lighting.GetColor(i, j), 0f, default(Vector2), 1f, SpriteEffects.None, 1f);
            return false;
        }

        public override bool NewRightClick(int i, int j) {
            HitWire(i, j);
            Player player = Main.LocalPlayer;
            foreach (Item g in player.inventory) {
                if (g.type == ItemID.GoldCoin && g.stack >= 1) {
                    g.stack -= 1;
                    Main.PlaySound(SoundID.CoinPickup, player.position);
                    int c = (Main.rand.Next(999));
                    if (c >= 999) {
                        Item.NewItem(player.position, player.width, player.height, ItemID.GoldCoin, Main.rand.Next(99) + 1);
                        Main.NewText(player.name + " just hit the jackpot!", 255, 255, 0);
                        Main.PlaySound(SoundID.CoinPickup, player.position);
                        return true;
                    } else if (c >= 997) {
                        int[] DSItems = {
                        ModContent.ItemType<Items.Accessory.RejuvenatorShield>(),
                        ModContent.ItemType<Items.Accessory.RingCalamity>(),
                        ModContent.ItemType<Items.Accessory.RingAvarice>(),
                        ModContent.ItemType<Items.Accessory.RingDarkGrain>(),
                        ModContent.ItemType<Items.Accessory.RingDuskCrown>(),
                        ModContent.ItemType<Items.Accessory.RingFavor>(),
                        ModContent.ItemType<Items.Accessory.RingHavels>(),
                        ModContent.ItemType<Items.Accessory.RingMagicPower>(),
                        ModContent.ItemType<Items.Accessory.RingMeleePower>(),
                        ModContent.ItemType<Items.Accessory.RingPriestess>(),
                        ModContent.ItemType<Items.Accessory.RingPyromancyPower>(),
                        ModContent.ItemType<Items.Accessory.RingRangePower>(),
                        ModContent.ItemType<Items.Accessory.RingSummonPower>(),
                        ModContent.ItemType<Items.Accessory.RingThrowingPower>(),
                        ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherChest>(),
                        ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherHelmet>(),
                        ModContent.ItemType<Items.Armor.AbyssWatcher.WatcherLeggings>(),
                        ModContent.ItemType<Items.Armor.Artorias.ArtoriasArmor>(),
                        ModContent.ItemType<Items.Armor.Artorias.ArtoriasHelmet>(),
                        ModContent.ItemType<Items.Armor.Artorias.ArtoriasLeggings>(),
                        ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightArmor>(),
                        ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightHelmet>(),
                        ModContent.ItemType<Items.Armor.BlackKnight.BlackKnightLeggings>(),
                        ModContent.ItemType<Items.Armor.Cornyx.CornyxRobe>(),
                        ModContent.ItemType<Items.Armor.Cornyx.CornyxSkirt>(),
                        ModContent.ItemType<Items.Armor.Cornyx.CornyxWrap>(),
                        ModContent.ItemType<Items.Armor.Father.GiantArmor>(),
                        ModContent.ItemType<Items.Armor.Father.GiantLeggings>(),
                        ModContent.ItemType<Items.Armor.FireKeeper.FireKeeperMask>(),
                        ModContent.ItemType<Items.Armor.FireKeeper.FireKeeperShirt>(),
                        ModContent.ItemType<Items.Armor.FireKeeper.FireKeeperSkirt>(),
                        ModContent.ItemType<Items.Armor.FireWitchHelmet>(),
                        ModContent.ItemType<Items.Armor.GibbetBody>(),
                        ModContent.ItemType<Items.Armor.GibbetHead>(),
                        ModContent.ItemType<Items.Armor.GibbetLegs>(),
                        ModContent.ItemType<Items.Armor.Havels.HavelsArmor>(),
                        ModContent.ItemType<Items.Armor.Havels.HavelsHelmet>(),
                        ModContent.ItemType<Items.Armor.Havels.HavelsLeggings>(),
                        ModContent.ItemType<Items.Armor.Moonlight.MoonlightChest>(),
                        ModContent.ItemType<Items.Armor.Moonlight.MoonlightHead>(),
                        ModContent.ItemType<Items.Armor.Moonlight.MoonlightLeggings>(),
                        ModContent.ItemType<Items.Armor.Paladin.PaladinArmor>(),
                        ModContent.ItemType<Items.Armor.Paladin.PaladinHelmet>(),
                        ModContent.ItemType<Items.Armor.Paladin.PaladinLeggings>(),
                        ModContent.ItemType<Items.Armor.Ringed.RingedArmor>(),
                        ModContent.ItemType<Items.Armor.Ringed.RingedHelmet>(),
                        ModContent.ItemType<Items.Armor.Ringed.RingedLeggings>(),
                        ModContent.ItemType<Items.Armor.SilverKnight.SilverKnightArmor>(),
                        ModContent.ItemType<Items.Armor.SilverKnight.SilverKnightHelmet>(),
                        ModContent.ItemType<Items.Armor.SilverKnight.SilverKnightLeggings>(),
                        ModContent.ItemType<Items.Armor.Thorns.ThornsArmor>(),
                        ModContent.ItemType<Items.Armor.Thorns.ThornsHelmet>(),
                        ModContent.ItemType<Items.Armor.Thorns.ThornsLeggings>(),
                        ModContent.ItemType<Items.Armor.TitaniteHead>(),
                        ModContent.ItemType<Items.Armor.Void.VoidChest>(),
                        ModContent.ItemType<Items.Armor.Void.VoidLeggings>(),
                        ModContent.ItemType<Items.Armor.Void.VoidMask>(),
                        ModContent.ItemType<Items.Armor.Xanthous.XanthousCrown>(),
                        ModContent.ItemType<Items.Armor.Xanthous.XanthousOvercoat>(),
                        ModContent.ItemType<Items.Armor.Xanthous.XanthousWaistcloth>(),
                        ModContent.ItemType<Items.Magic.ArcaneShiv>(),
                        ModContent.ItemType<Items.Magic.Holy.DivineSpearFragment>(),
                        ModContent.ItemType<Items.Magic.Holy.LightningArrow>(),
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolySunlightSpear>(),
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyWhiteCorona>(),
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyWrathofGods>(),
                        ModContent.ItemType<Items.Magic.IT>(),
                        ModContent.ItemType<Items.Magic.MagnetSphere.FulminatingSphere>(),
                        ModContent.ItemType<Items.Magic.MoonGS>(),
                        ModContent.ItemType<Items.Magic.Pyro.DemonsScar>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollChaosStorm>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollChaosWhip>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollFloatingChaos>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollLingeringFlame>(),
                        ModContent.ItemType<Items.Magic.ScrollHomingCrystalSoulMass>(),
                        ModContent.ItemType<Items.Magic.ScrollSpear>(),
                        ModContent.ItemType<Items.Magic.ScrollSpearBarrage>(),
                        ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades2>(),
                        ModContent.ItemType<Items.Melee.ArtoriasSword>(),
                        ModContent.ItemType<Items.Melee.BlackKnightHalberd>(),
                        ModContent.ItemType<Items.Melee.CrowTalon>(),
                        ModContent.ItemType<Items.Melee.KeroKhi>(),
                        ModContent.ItemType<Items.Melee.Khi>(),
                        ModContent.ItemType<Items.Melee.Lament>(),
                        ModContent.ItemType<Items.Melee.OnyxBlade>(),
                        ModContent.ItemType<Items.Melee.QrowQuills>(),
                        ModContent.ItemType<Items.Melee.SplitLeaf>(),
                        ModContent.ItemType<Items.Melee.TitanitePole>(),
                        ModContent.ItemType<Items.Melee.RejuvenatorSword>(),
                        ModContent.ItemType<Items.Misc.CoalBlue>(),
                        ModContent.ItemType<Items.Misc.CoalLord>(),
                        ModContent.ItemType<Items.Misc.CovenentArterRias>(),
                        ModContent.ItemType<Items.Misc.CrystalPet>(),
                        ModContent.ItemType<Items.Misc.DemonTitanite>(),
                        ModContent.ItemType<Items.Misc.EstusShard>(),
                        ModContent.ItemType<Items.Misc.PyroScrollPower>(),
                        ModContent.ItemType<Items.Misc.ScrollHolyMajorHeal>(),
                        ModContent.ItemType<Items.Misc.Titanite>(),
                        ModContent.ItemType<Items.Misc.VoidFragment>(),
                        ModContent.ItemType<Items.Ranged.DragonslayerGreatarrow>(),
                        ModContent.ItemType<Items.Ranged.DragonslayerGreatbow>(),
                        ModContent.ItemType<Items.Summon.Consumable.XahlicemEye>(),
                        ModContent.ItemType<Items.Throwing.SolarEclipse>(),
                        ModContent.ItemType<Tiles.FirelinkShrine>(),
                        ModContent.ItemType<Tiles.LotteryMachine>()
                        };
                        player.QuickSpawnItem(Utils.SelectRandom(Main.rand, DSItems));
                        Main.NewText(player.name + " just got a powerful dark item.", 0, 0, 0);
                        Main.PlaySound(SoundID.DD2_EtherianPortalSpawnEnemy, player.position);
                        return true;
                    } else if (c >= 975) {
                        int[] DItems = {
                        ModContent.ItemType<Items.Accessory.RingAgape>(),
                        ModContent.ItemType<Items.Accessory.RingAshenEstus>(),
                        ModContent.ItemType<Items.Accessory.RingBinding>(),
                        ModContent.ItemType<Items.Accessory.RingEstus>(),
                        ModContent.ItemType<Items.Accessory.RingKnuckleBrace>(),
                        ModContent.ItemType<Items.Accessory.RingReversal>(),
                        ModContent.ItemType<Items.Accessory.RingRuby>(),
                        ModContent.ItemType<Items.Accessory.RingRusty>(),
                        ModContent.ItemType<Items.Accessory.RingSapphire>(),
                        ModContent.ItemType<Items.Accessory.RingThorns>(),
                        ModContent.ItemType<Items.Accessory.PyromancerEmblem>(),
                        ModContent.ItemType<Items.Accessory.RingBlueTear>(),
                        ModContent.ItemType<Items.Accessory.RingBlades>(),
                        ModContent.ItemType<Items.Accessory.RingCat>(),
                        ModContent.ItemType<Items.Accessory.RingCharred>(),
                        ModContent.ItemType<Items.Accessory.RingClearBlue>(),
                        ModContent.ItemType<Items.Accessory.RingCloranthy>(),
                        ModContent.ItemType<Items.Accessory.RingEvilEye>(),
                        ModContent.ItemType<Items.Accessory.RingLoyds>(),
                        ModContent.ItemType<Items.Accessory.RingPoisBite>(),
                        ModContent.ItemType<Items.Accessory.RingRedTear>(),
                        ModContent.ItemType<Items.Accessory.RingSteelProt>(),
                        ModContent.ItemType<Items.Accessory.RingTinyBeing>(),
                        ModContent.ItemType<Items.Accessory.SkullLantern>(),
                        ModContent.ItemType<Items.Accessory.ThiefEmblem>(),
                        ModContent.ItemType<Items.Armor.Channeler.ChannelerHelmet>(),
                        ModContent.ItemType<Items.Armor.Channeler.ChannelerRobe>(),
                        ModContent.ItemType<Items.Armor.Channeler.ChannelerSkirt>(),
                        ModContent.ItemType<Items.Armor.Crimson.CrimsonHood>(),
                        ModContent.ItemType<Items.Armor.Crimson.CrimsonRobe>(),
                        ModContent.ItemType<Items.Armor.Crimson.CrimsonSkirt>(),
                        ModContent.ItemType<Items.Armor.CrownoftheDarkSun>(),
                        ModContent.ItemType<Items.Armor.DesertSorceress.SorceressHood>(),
                        ModContent.ItemType<Items.Armor.DesertSorceress.SorceressSkirt>(),
                        ModContent.ItemType<Items.Armor.DesertSorceress.SorceressTop>(),
                        ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerChest>(),
                        ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerHelmet>(),
                        ModContent.ItemType<Items.Armor.DragonSlayer.DragonSlayerLeggings>(),
                        ModContent.ItemType<Items.Armor.Father.FatherMask>(),
                        ModContent.ItemType<Items.Armor.HardmodeFire.AdamantiteCrown>(),
                        ModContent.ItemType<Items.Armor.HardmodeFire.ChlorophyteCrown>(),
                        ModContent.ItemType<Items.Armor.HardmodeFire.CobaltCrown>(),
                        ModContent.ItemType<Items.Armor.HardmodeFire.HallowedCrown>(),
                        ModContent.ItemType<Items.Armor.HardmodeFire.MythrilCrown>(),
                        ModContent.ItemType<Items.Armor.HardmodeFire.OrichalcumCrown>(),
                        ModContent.ItemType<Items.Armor.HardmodeFire.PalladiumCrown>(),
                        ModContent.ItemType<Items.Armor.HardmodeFire.TitaniumCrown>(),
                        ModContent.ItemType<Items.Armor.HardmodeThrow.AdamantiteHeadgear>(),
                        ModContent.ItemType<Items.Armor.HardmodeThrow.ChlorophyteHeadgear>(),
                        ModContent.ItemType<Items.Armor.HardmodeThrow.CobaltHeadgear>(),
                        ModContent.ItemType<Items.Armor.HardmodeThrow.HallowedHeadgear>(),
                        ModContent.ItemType<Items.Armor.HardmodeThrow.MythrilHeadgear>(),
                        ModContent.ItemType<Items.Armor.HardmodeThrow.OrichalcumHeadgear>(),
                        ModContent.ItemType<Items.Armor.HardmodeThrow.PalladiumHeadgear>(),
                        ModContent.ItemType<Items.Armor.HardmodeThrow.TitaniumHeadgear>(),
                        ModContent.ItemType<Items.Armor.Hollow.HollowLoin>(),
                        ModContent.ItemType<Items.Armor.Hollow.HollowMask>(),
                        ModContent.ItemType<Items.Armor.Hollow.HollowShirt>(),
                        ModContent.ItemType<Items.Armor.PaintingGuardian.PaintingGuardianHood>(),
                        ModContent.ItemType<Items.Armor.PaintingGuardian.PaintingGuardianLeggings>(),
                        ModContent.ItemType<Items.Armor.PaintingGuardian.PaintingGuardianRobe>(),
                        ModContent.ItemType<Items.Armor.Pilgrim.PilgrimHood>(),
                        ModContent.ItemType<Items.Armor.Pilgrim.PilgrimRobe>(),
                        ModContent.ItemType<Items.Armor.Pilgrim.PilgrimWaistcloth>(),
                        ModContent.ItemType<Items.Armor.Tattered.TatteredBoots>(),
                        ModContent.ItemType<Items.Armor.Tattered.TatteredHat>(),
                        ModContent.ItemType<Items.Armor.Tattered.TatteredTunic>(),
                        ModContent.ItemType<Items.Banners.BlackKnightBanner>(),
                        ModContent.ItemType<Items.Banners.ChannelerBanner>(),
                        ModContent.ItemType<Items.Banners.ChickenBanner>(),
                        ModContent.ItemType<Items.Banners.CrystalLizardBanner>(),
                        ModContent.ItemType<Items.Banners.CthulhunBanner>(),
                        ModContent.ItemType<Items.Banners.DesertSorceressBanner>(),
                        ModContent.ItemType<Items.Banners.DragonSlayerBanner>(),
                        ModContent.ItemType<Items.Banners.FlameWarmageBanner>(),
                        ModContent.ItemType<Items.Banners.GiantCrystalLizardBanner>(),
                        ModContent.ItemType<Items.Banners.HollowBanner>(),
                        ModContent.ItemType<Items.Banners.HollowDogBanner>(),
                        ModContent.ItemType<Items.Banners.HumanityBanner>(),
                        ModContent.ItemType<Items.Banners.InhumanityBanner>(),
                        ModContent.ItemType<Items.Banners.LittleMushroomBanner>(),
                        ModContent.ItemType<Items.Banners.ManEaterShellBanner>(),
                        ModContent.ItemType<Items.Banners.MoonButterflyBanner>(),
                        ModContent.ItemType<Items.Banners.NightMareBanner>(),
                        ModContent.ItemType<Items.Banners.NinjaBanner>(),
                        ModContent.ItemType<Items.Banners.PursuerBanner>(),
                        ModContent.ItemType<Items.Banners.RavelordBanner>(),
                        ModContent.ItemType<Items.Banners.RingedKnightBanner>(),
                        ModContent.ItemType<Items.Banners.SilverKnightBanner>(),
                        ModContent.ItemType<Items.Banners.SpinwheelBanner>(),
                        ModContent.ItemType<Items.Banners.VoidEaterBanner>(),
                        ModContent.ItemType<Items.Banners.VoidlingBanner>(),
                        ModContent.ItemType<Items.Banners.VoidWalkerBanner>(),
                        ModContent.ItemType<Items.Banners.WheelSkeletonBanner>(),
                        ModContent.ItemType<Items.BoneWheel>(),
                        ModContent.ItemType<Items.Magic.ADagger>(),
                        ModContent.ItemType<Items.Magic.Holy.RitualSpearFragment>(),
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyForce>(),
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyGnash>(),
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyGnaw>(),
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyGreatLightningSpear>(),
                        ModContent.ItemType<Items.Magic.Holy.ScrollHolyLightningSpear>(),
                        ModContent.ItemType<Items.Magic.IE>(),
                        ModContent.ItemType<Items.Magic.MagnetSphere.ElectricSphere>(),
                        ModContent.ItemType<Items.Magic.Pyro.FlameFan>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollAcidSurge>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollBlackFireball>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollBlackFlame>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollBurstingFireBall>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollCombustion>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireBall>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireStorm>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireSurge>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollFireWhip>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollFlameWeapon>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollImmolation>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollPoison>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollProfanedFlame>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroScrollToxin>(),
                        ModContent.ItemType<Items.Magic.Pyro.PyroTorch>(),
                        ModContent.ItemType<Items.Magic.ScrollGreatSword>(),
                        ModContent.ItemType<Items.Magic.ScrollHomingSoulMass>(),
                        ModContent.ItemType<Items.Magic.ScrollSword>(),
                        ModContent.ItemType<Items.Magic.SoulArrow.ScrollSoulArrow>(),
                        ModContent.ItemType<Items.Magic.SoulArrow.ScrollSoulArrowGreat>(),
                        ModContent.ItemType<Items.Magic.SoulArrow.ScrollSoulDart>(),
                        ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades>(),
                        ModContent.ItemType<Items.Magic.SoulBlades.ScrollSoulBlades1>(),
                        ModContent.ItemType<Items.Melee.GibbetSword>(),
                        ModContent.ItemType<Items.Melee.SwordNineMoons>(),
                        ModContent.ItemType<Items.Melee.ChannelT>(),
                        ModContent.ItemType<Items.Melee.DragonSlayerSpear>(),
                        ModContent.ItemType<Items.Melee.GravelordSword>(),
                        ModContent.ItemType<Items.Melee.MorianBlade>(),
                        ModContent.ItemType<Items.Melee.SpearOfCthulhu>(),
                        /*ModContent.ItemType<Items.Melee.SwordHilt> (),*/
                        ModContent.ItemType<Items.Misc.Classes.ClassEmpty>(),
                        ModContent.ItemType<Items.Misc.CoalRed>(),
                        ModContent.ItemType<Items.Misc.CoalWhite>(),
                        ModContent.ItemType<Items.Misc.CoalYellow>(),
                        ModContent.ItemType<Items.Misc.CthulhunEmbryo>(),
                        ModContent.ItemType<Items.Misc.CthulhunTentacle>(),
                        ModContent.ItemType<Items.Misc.GreenBlossom>(),
                        ModContent.ItemType<Items.Misc.HomewardBone>(),
                        ModContent.ItemType<Items.Misc.InfernoBar>(),
                        ModContent.ItemType<Items.Misc.Lifegem>(),
                        ModContent.ItemType<Items.Misc.MoonButterflyHorn>(),
                        ModContent.ItemType<Items.Misc.PrismStone>(),
                        ModContent.ItemType<Items.Misc.PyroScroll>(),
                        ModContent.ItemType<Items.Misc.PyroScrollIron>(),
                        ModContent.ItemType<Items.Misc.PyroScrollWarmth>(),
                        ModContent.ItemType<Items.Misc.Scroll>(),
                        ModContent.ItemType<Items.Misc.ScrollCastLight>(),
                        ModContent.ItemType<Items.Misc.ScrollFallControl>(),
                        ModContent.ItemType<Items.Misc.ScrollHiddenBody>(),
                        ModContent.ItemType<Items.Misc.ScrollHoly>(),
                        ModContent.ItemType<Items.Misc.ScrollHolyHeal>(),
                        ModContent.ItemType<Items.Misc.ScrollHolyHomeward>(),
                        ModContent.ItemType<Items.Misc.ScrollHolyMinorHeal>(),
                        ModContent.ItemType<Items.Misc.ScrollHolyRegen>(),
                        ModContent.ItemType<Items.Misc.ScrollRemedy>(),
                        ModContent.ItemType<Items.Misc.ScrollVelocity>(),
                        ModContent.ItemType<Items.Misc.Twink>(),
                        ModContent.ItemType<Items.Ranged.SolpiercerBow>(),
                        ModContent.ItemType<Items.Ranged.GoldenSlingshot>(),
                        ModContent.ItemType<Items.Ranged.Moltenshot>(),
                        ModContent.ItemType<Items.Ranged.ReinforcedSlingshot>(),
                        ModContent.ItemType<Items.Ranged.Slingshot>(),
                        ModContent.ItemType<Items.Ranged.SlingshotStones>(),
                        ModContent.ItemType<Items.Summon.Consumable.PossesedArmorHelmet>(),
                        ModContent.ItemType<Items.Summon.Consumable.SkeletonSkull>(),
                        ModContent.ItemType<Items.Summon.Consumable.ZombieHand>(),
                        ModContent.ItemType<Items.Summon.EffigyStaff>(),
                        ModContent.ItemType<Items.Summon.SoulSummonStaff>(),
                        ModContent.ItemType<Items.Throwing.BlackFireBomb>(),
                        ModContent.ItemType<Items.Throwing.FireBomb>(),
                        ModContent.ItemType<Tiles.LordVessel>(),
                        ModContent.ItemType<Tiles.ThrowingTarget>()
                        };
                        player.QuickSpawnItem(Utils.SelectRandom(Main.rand, DItems));
                        Main.NewText(player.name + " just got a dark item.", 0, 0, 0);
                        Main.PlaySound(SoundID.DD2_EtherianPortalSpawnEnemy, player.position);
                        return true;
                    } else if (c >= 650) {
                        player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(99) + 1);
                        return true;
                    } else if (c >= 200) {
                        player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(99) + 1);
                        return true;
                    } else {
                        int r = (Main.rand.Next(3929));
                        if (r == 1230 || r == 1231 || r == 1254 || r == 1260 || r == 1266 || r == 1292 || r == 1293 || r == 1294 ||
                            r == 1295 || r == 1296 || r == 1297 || r == 1316 || r == 1317 || r == 1318 || r == 1326 || r == 1327 ||
                            r == 1444 || r == 1445 || r == 1446 || r == 1506 || r == 1503 || r == 1504 || r == 1505 || r == 1513 ||
                            r == 1546 || r == 1547 || r == 1548 || r == 1549 || r == 1550 || r == 1553 || r == 1571 || r == 1572 ||
                            r == 1801 || r == 1802 || r == 1826 || r == 1832 || r == 1833 || r == 1834 || r == 1835 || r == 1928 ||
                            r == 1929 || r == 1931 || r == 1947 || r == 2176 || r == 2189 || r == 2199 || r == 2200 || r == 2201 ||
                            r == 2202 || r == 2223 || r == 2611 || r == 2622 || r == 2623 || r == 2624 || r == 2749 || r == 2757 ||
                            r == 2758 || r == 2759 || r == 2760 || r == 2761 || r == 2762 || r == 2763 || r == 2764 || r == 2765 ||
                            r == 2768 || r == 2769 || r == 2771 || r == 2774 || r == 2776 || r == 2779 || r == 2781 || r == 2784 ||
                            r == 2786 || r == 2795 || r == 2796 || r == 2797 || r == 2798 || r == 2880 || r == 2881 || r == 2882 ||
                            r == 3063 || r == 3065 || r == 3107 || r == 3249 || r == 3291 || r == 3292 || r == 3329 || r == 3330 ||
                            r == 3331 || r == 3332 || r == 3335 || r == 3381 || r == 3382 || r == 3383 || r == 3384 || r == 3389 ||
                            r == 3464 || r == 3466 || r == 3473 || r == 3474 || r == 3475 || r == 3476 || r == 3531 || r == 3540 ||
                            r == 3541 || r == 3542 || r == 3543 || r == 3569 || r == 3570 || r == 3571 || r == 3820 || r == 3826 ||
                            r == 3827 || r == 3831 || r == 3834 || r == 3858 || r == 3859 || r == 3860 || r == 3870) {
                            r = (Main.rand.Next(3929));
                        }
                        player.QuickSpawnItem(r);
                        return true;
                    }
                }
            }
            return false;
        }

        public override void MouseOver(int i, int j) {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<Tiles.LotteryMachine>();
        }

        public override void HitWire(int i, int j) {
            int x = i - (Main.tile[i, j].frameX / 18) % 2;
            int y = j - (Main.tile[i, j].frameY / 18) % 3;
            for (int l = x; l < x + 2; l++) {
                for (int m = y; m < y + 3; m++) {
                    if (Main.tile[l, m] == null) {
                        Main.tile[l, m] = new Tile();
                    }
                }
            }
            if (Wiring.running) {
                Wiring.SkipWire(x, y);
                Wiring.SkipWire(x, y + 1);
                Wiring.SkipWire(x, y + 2);
                Wiring.SkipWire(x + 1, y);
                Wiring.SkipWire(x + 1, y + 1);
                Wiring.SkipWire(x + 1, y + 2);
            }
            NetMessage.SendTileSquare(-1, x, y + 1, 3);
        }
    }
}