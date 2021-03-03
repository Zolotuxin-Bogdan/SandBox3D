using Assets.LocalizationSystem;
using Assets.Scripts.Enums;
using Assets.Scripts.Tools_and_Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class VideoSettingsController: MonoBehaviour, ILocalization
    {

        public SettingsManager settingsManager;
        [Header("Sliders")]
        public Slider resolution;
        public Slider biomeBlend;
        public Slider renderDistance;
        public Slider maxFramerate;
        public Slider brightness;
        public Slider mipmapLevels;
        
        [Header("Buttons")]
        public Button graphics;
        public Button smoothLighting;
        public Button useVSync;
        public Button guiScale;
        public Button fullscreen;
        public Button viewBobbing;
        public Button attackIndicator;
        public Button clouds;
        public Button particles;
        public Button entityShadows;
        public Button done;


        Resolutions resolutions;
        int scale;
        //Unity Start Message
        void Start()
        {
            resolutions = new Resolutions();
            // Buttons listener's 
            graphics.onClick.AddListener(UpdateGraphics);
            smoothLighting.onClick.AddListener(UpdateSmoothLighting);
            useVSync.onClick.AddListener(UpdateUseVSync);
            guiScale.onClick.AddListener(UpdateGUIScale);
            fullscreen.onClick.AddListener(UpdateFullscreen);
            viewBobbing.onClick.AddListener(UpdateViewBobbing);
            attackIndicator.onClick.AddListener(UpdateAttackIndicator);
            clouds.onClick.AddListener(UpdateClouds);
            particles.onClick.AddListener(UpdateParticles);
            entityShadows.onClick.AddListener(UpdateEntityShadows);
            done.onClick.AddListener(Submit);
            // Sliders listener's
            resolution.onValueChanged.AddListener(UpdateResolution);
            biomeBlend.onValueChanged.AddListener(UpdateBiomeBlend);
            renderDistance.onValueChanged.AddListener(UpdateRenderDistance);
            maxFramerate.onValueChanged.AddListener(UpdateMaxFramerate);
            brightness.onValueChanged.AddListener(UpdateBrightness);
            mipmapLevels.onValueChanged.AddListener(UpdateMipmapLevels);
            scale = settingsManager.GetSettings().graphic.guiScale;
        }

        private void Submit()
        {
            action.Invoke();
        }

        private void UpdateMipmapLevels(float arg0)
        { 
            if (arg0 < 1)
                mipmapLevels.GetComponentInChildren<TextMeshProUGUI>().text = $"Mipmap Levels: OFF";
            else            
                mipmapLevels.GetComponentInChildren<TextMeshProUGUI>().text = $"Mipmap Levels: {arg0}";
            settingsManager.GetSettings().graphic.mipmap = (int)arg0;
        }

        private void UpdateBrightness(float arg0)
        {
            //var value = Converter.FromIdToString<Brightness>((int)arg0);
            if (arg0 < 1)
                brightness.GetComponentInChildren<TextMeshProUGUI>().text = $"Brightness: Moody";
            else if (arg0 > 99)
                brightness.GetComponentInChildren<TextMeshProUGUI>().text = $"Brightness: Bright";    
            else
                brightness.GetComponentInChildren<TextMeshProUGUI>().text = $"Brightness: +{arg0}%";
            settingsManager.GetSettings().graphic.brightness = (int)arg0;
        }

        private void UpdateMaxFramerate(float arg0)
        {
            if (arg0 > 120)
                maxFramerate.GetComponentInChildren<TextMeshProUGUI>().text = $"Max Framerate: Unlimited";
            else
                maxFramerate.GetComponentInChildren<TextMeshProUGUI>().text = $"Max Framerate: {arg0} frames";
            
            settingsManager.GetSettings().graphic.maxFramerate = (int)arg0;
        }

        private void UpdateRenderDistance(float arg0)
        {
            renderDistance.GetComponentInChildren<TextMeshProUGUI>().text = $"Render Distance: {arg0} chunks";
            settingsManager.GetSettings().graphic.renderDistance = (int)arg0;
        }

        private void UpdateBiomeBlend(float arg0)
        {
            var value = (BiomeBlend)((int)arg0);
            biomeBlend.GetComponentInChildren<TextMeshProUGUI>().text = arg0 < 1 ? $"Biome Blend: OFF ({value})" : $"Biome Blend: {value}";
            settingsManager.GetSettings().graphic.biomeBlend = value;
        }

        private void UpdateResolution(float arg0)
        {
            var (x, y) = ((int x, int y))resolutions.resTuple.GetValue((int)arg0);
            resolution.GetComponentInChildren<TextMeshProUGUI>().text = $"Resolution: {x}x{y}";
            settingsManager.GetSettings().screenResolution = new Vector2(x, y);
        }

        private void UpdateEntityShadows()
        {
            var text = entityShadows.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "Entity Shadows: ON";
                settingsManager.GetSettings().graphic.entityShadows = true;
            }
            else if (text.Contains("ON"))
            {
                text = "Entity Shadows: OFF";
                settingsManager.GetSettings().graphic.entityShadows = false;
            }
            entityShadows.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateParticles()
        {
            var text = particles.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("Decreast"))
            {
                text = $"Graphics: {ParticlesMode.Minimal}";
            }
            else if (text.Contains("Minimal"))
            {
                text = $"Graphics: {ParticlesMode.All}";
            }
            else if (text.Contains("All"))
            {
                text = $"Graphics: {ParticlesMode.Decreast}";
            }
            particles.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateClouds()
        {
            var text = clouds.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "Clouds: ON";
                settingsManager.GetSettings().graphic.clouds = true;
            }
            else if (text.Contains("ON"))
            {
                text = "Clouds: OFF";
                settingsManager.GetSettings().graphic.clouds = false;
            }
            clouds.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateAttackIndicator()
        {
           var text = attackIndicator.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "Attack Indicator: Crosshair";
            }
            else if (text.Contains("Crosshair"))
            {
                text = "Attack Indicator: Hotbar";;
            }
            else if (text.Contains("Hotbar"))
            {
                text = "Attack Indicator: OFF";;
            }
            attackIndicator.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateViewBobbing()
        {
            var text = viewBobbing.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "View Bobbing: ON";
                settingsManager.GetSettings().graphic.viewBobbing = true;
            }
            else if (text.Contains("ON"))
            {
                text = "View Bobbing: OFF";
                settingsManager.GetSettings().graphic.viewBobbing = false;
            }
            viewBobbing.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        private void UpdateFullscreen()
        {
           var text = fullscreen.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "Fullscreen: ON";
                settingsManager.GetSettings().graphic.fullscreen = true;
            }
            else if (text.Contains("ON"))
            {
                text = "Fullscreen: OFF";
                settingsManager.GetSettings().graphic.fullscreen = false;
            }
            fullscreen.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void UpdateGraphics()
        {
            var text = graphics.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("High"))
            {
                text = $"Graphics: {Quality.Fast}";
                settingsManager.GetSettings().graphic.quality = Quality.Fast;
            }
            else if (text.Contains("Low"))
            {
                text = $"Graphics: {Quality.Fancy}";
                settingsManager.GetSettings().graphic.quality = Quality.Fancy;
            }
            else if (text.Contains("Medium"))
            {
                text = $"Graphics: {Quality.High}";
                settingsManager.GetSettings().graphic.quality = Quality.High;
            }
            graphics.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void UpdateSmoothLighting()
        {
            var text = smoothLighting.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "Smooth Lighting: ON";
                settingsManager.GetSettings().graphic.smoothLighting = true;
            }
            else if (text.Contains("ON"))
            {
                text = "Smooth Lighting: OFF";
                settingsManager.GetSettings().graphic.smoothLighting = false;
            }
            smoothLighting.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void UpdateUseVSync()
        {
            var text = useVSync.GetComponentInChildren<TextMeshProUGUI>().text;
            if (text.Contains("OFF"))
            {
                text = "Use VSync: ON";
                settingsManager.GetSettings().graphic.useVSync = true;
            }
            else if (text.Contains("ON"))
            {
                text = "Use VSync: OFF";
                settingsManager.GetSettings().graphic.useVSync = false;
            }
            useVSync.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }

        void UpdateGUIScale()
        {
            scale++;
            if (scale > 3)
            {
                scale = 1;
            }
            guiScale.GetComponentInChildren<TextMeshProUGUI>().text = $"GUI Scale: {scale}";
            settingsManager.GetSettings().graphic.guiScale = scale;
        }

        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }

        public void SetLocalization()
        {
            throw new System.NotImplementedException();
        }
    }
}