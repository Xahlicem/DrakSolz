using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

namespace XahlicemMod
{
	public class XahlicemMod : Mod
	{
		public XahlicemMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

		public override void Load() {
			if (!Main.dedServ)
				AddEquipTexture(null, EquipType.Legs, "MoonlightLeggings_Legs", "XahlicemMod/Items/MoonlightLeggings_Legs");
		}
	}
}
