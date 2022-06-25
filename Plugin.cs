using BepInEx;

namespace PhobosModpack {
	[BepInPlugin("nrg.valheim.phobosmodpack", "Phobos Modpack", "1.0.0")]

	/**
	 *
	 */
	public class PhobosModpack : BaseUnityPlugin {
		/**
		 *
		 */
		private void Awake() {
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
		}
	}
}
