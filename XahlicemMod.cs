using Terraria.ModLoader;

namespace XahlicemMod
{
	class XahlicemMod : Mod
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
	}
}
