using UnityModManagerNet;

namespace ModTemplate {
    public class MainSettings : UnityModManager.ModSettings, IDrawable {
        // [Draw("A")] public int A = 0;

        public override void Save(UnityModManager.ModEntry modEntry) {
            UnityModManager.ModSettings.Save(this, modEntry);
        }
        
        public void OnChange() {
            
        }
    }
}