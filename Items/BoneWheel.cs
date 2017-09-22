using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items {
    public class BoneWheel : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bone Wheel");
            Tooltip.SetDefault("Used by Wheel Skeletons as a means of transportation. Are you going to ride it or something?");
        }

        public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
            //item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.mountType = mod.MountType<Mounts.BoneWheel>();
        }
    }
}