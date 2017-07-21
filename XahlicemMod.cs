using Terraria.ModLoader;
using Terraria;

namespace XahlicemMod {
    public class XahlicemMod : Mod {
        public XahlicemMod() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }
}