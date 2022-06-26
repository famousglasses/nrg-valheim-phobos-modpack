using BepInEx;
using BepInEx.Configuration;
using System.IO;

namespace PhobosModpack {
	[BepInPlugin("nrg.valheim.phobosmodpack", "Phobos", "1.1.1")]
	public class PhobosModpack : BaseUnityPlugin {
		private ConfigEntry<bool> cfgCopy;

		private void Awake() {
			cfgCopy = Config.Bind(
				"General", // config section
				"Copy Configs", // config key
				true, // default value
				"If true, all Phobos configs will be automatically copied into your BepInEx config directory." // config description
			);

			// Setup paths
			string dllPath = this.Info.Location;
			FileInfo fi = new FileInfo(dllPath);
			string phobosPath = fi.Directory.ToString() + Path.DirectorySeparatorChar + "config";
			string bepinPath = Paths.ConfigPath;

			// Copy config files
			if (cfgCopy.Value) {
				if (Directory.Exists(phobosPath)) {
					string[] files = Directory.GetFiles(phobosPath);
					foreach (string s in files) {
						string fileName = Path.GetFileName(s);
						string destFile = Path.Combine(bepinPath, fileName);
						File.Copy(s, destFile, true);
					}

					Logger.LogInfo("all configs copied");
				} else {
					Logger.LogError("phobos config path does not exist");
				}
			} else {
				Logger.LogInfo("config copy is false, skipping");
			}
		}
	}
}
