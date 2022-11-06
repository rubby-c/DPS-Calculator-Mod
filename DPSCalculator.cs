using Terraria.ModLoader;

namespace DPSCalculator {
	public class DPSCalculator : Mod {
		internal static ModKeybind RestartCounting;

		public override void Load() {
			RestartCounting = KeybindLoader.RegisterKeybind(this, "Restart Calculator", "Home");
		}
	}
}