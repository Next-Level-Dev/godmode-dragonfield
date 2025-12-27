using BepInEx;
using UnityEngine;

namespace GodMode
{
    [BepInPlugin("com.nextlevel.plugin.godmode", "God Mode", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;

        private void Awake()
        {
            Instance = this;
            Logger.LogInfo("God Mode loaded!");

            // Add a persistent GameObject for the health updater
            GameObject obj = new GameObject("GodModeHealthUpdater");
            obj.AddComponent<GodModeHealthUpdater>();
            DontDestroyOnLoad(obj);
        }

        // This MonoBehaviour updates player health every frame
        private class GodModeHealthUpdater : MonoBehaviour
        {
            void Update()
            {
                if (FindObjectOfType<PlayerHealth>() == null) return;

                PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.maxHealth = 10000f;
                    playerHealth.currentHealth = playerHealth.maxHealth;
                    // Optional: also restore poise or stamina if desired
                    // playerHealth.currentPoise = playerHealth.maxPoise;
                }
            }
        }
    }
}
