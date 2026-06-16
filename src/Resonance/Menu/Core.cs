using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Logger = Resonance.Utils.Logger;

namespace Resonance.Menus
{
    public static class MenuCore
    {
        private static Sprite LogoSprite;
        private static bool _isInitialized = false;

        public static void Initialize()
        {
            if (_isInitialized) return;
            _isInitialized = true;

            LoadLogoTexture();
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }

        #region LogoLoading
        private static void LoadLogoTexture()
        {
            try
            {
                string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string logoPath = Path.Combine(assemblyDir, "logo.png");

                if (!File.Exists(logoPath))
                {
                    Logger.Error("ResonanceMenu", $"Critical asset missing: logo.png not found at {logoPath}");
                    return;
                }

                byte[] fileData = File.ReadAllBytes(logoPath);
                Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, true);

                bool success = false;
                var imageConversionType = Type.GetType("UnityEngine.ImageConversion, UnityEngine.ImageConversionModule")
                                         ?? Type.GetType("UnityEngine.ImageConversion, UnityEngine");

                if (imageConversionType != null)
                {
                    var loadImageMethod = imageConversionType.GetMethod("LoadImage", new[] { typeof(Texture2D), typeof(byte[]) });
                    if (loadImageMethod != null)
                    {
                        success = (bool)loadImageMethod.Invoke(null, new object[] { texture, fileData });
                    }
                }

                if (success)
                {
                    texture.filterMode = FilterMode.Bilinear;
                    texture.anisoLevel = 9;
                    texture.wrapMode = TextureWrapMode.Clamp;
                    texture.Apply(true);

                    LogoSprite = Sprite.Create(
                        texture,
                        new Rect(0, 0, texture.width, texture.height),
                        new Vector2(0.5f, 0.5f),
                        100f
                    );

                    Logger.Log("ResonanceMenu", "logo.png successfully compiled with high-res anti-aliased alpha transparency filters.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("ResonanceMenu", "Failed to properly map logo.png payload to texture buffers.", ex);
            }
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != "Menu_Title") return;

            try
            {
                InjectLogoToMenu();
            }
            catch (Exception ex)
            {
                Logger.Error("ResonanceMenu", "Unexpected exception assembling Main Menu visual modifications.", ex);
            }
        }

        private static void InjectLogoToMenu()
        {
            if (LogoSprite == null) return;

            GameObject uiCanvas = GameObject.Find("UICanvas");
            if (uiCanvas == null) return;

            Transform teamCherryLogoTransform = uiCanvas.transform.Find("MainMenuScreen/TeamCherryLogo");

            if (teamCherryLogoTransform == null)
            {
                Logger.Error("ResonanceMenu", "Could not locate TeamCherryLogo to execute brand swap.");
                return;
            }

            Type logoLanguageType = Type.GetType("LogoLanguage, Assembly-CSharp");

            if (logoLanguageType != null)
            {
                if (teamCherryLogoTransform.TryGetComponent(logoLanguageType, out Component logoLangComponent))
                {
                    if (logoLangComponent is MonoBehaviour monoBehaviour)
                    {
                        monoBehaviour.enabled = false;
                    }
                }
            }

            if (teamCherryLogoTransform.TryGetComponent<Image>(out var tcImage))
            {
                tcImage.sprite = LogoSprite;
                if (teamCherryLogoTransform.TryGetComponent<RectTransform>(out var rectTransform))
                {
                    rectTransform.sizeDelta = new Vector2(180f, 180f);
                }
            }
            else
            {
                Logger.Error("Resonance", "Image component not found on TeamCherryLogo target");
            }
        }
        #endregion
    }
}