using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Items.Ranged {
	public class DragonslayerGreatbow : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dragonslayer Greatbow");
			Tooltip.SetDefault("Greatbow used by Silver Knights to slay dragons with specially designed arrows.");
		}

		public override void SetDefaults() {
			item.damage = 750;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10;
			item.value = Item.sellPrice(0, 35, 0, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = (ModContent.ItemType<Items.Ranged.DragonslayerGreatarrow>());
		}
		
		public override Vector2? HoldoutOffset() {
			return new Vector2(-2, 0);
		}
	}
}