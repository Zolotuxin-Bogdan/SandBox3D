using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class VideoSettingsController: MonoBehaviour
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
        }

        private void Submit()
        {
            action.Invoke();
        }

        private void UpdateMipmapLevels(float arg0)
        { 
            //var value = Converter.FromIdToString<MipmapLevels>((int)arg0);
            mipmapLevels.GetComponentInChildren<TextMeshProUGUI>().text = $"Mipmap Levels: {arg0}";
            settingsManager.GetSettings().graphic.mipmap = arg0;
        }

        private void UpdateBrightness(float arg0)
        {
            //var value = Converter.FromIdToString<Brightness>((int)arg0);
            brightness.GetComponentInChildren<TextMeshProUGUI>().text = $"Brightness: {arg0}";
            settingsManager.GetSettings().graphic.brightness = arg0;
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
            var value = Converter.FromIdToString<BiomeBlend>((int)arg0);
            if (arg0 < 1)
                biomeBlend.GetComponentInChildren<TextMeshProUGUI>().text = $"Biome Blend: OFF ({value})";
            else
                biomeBlend.GetComponentInChildren<TextMeshProUGUI>().text = $"Biome Blend: {value}";
            settingsManager.GetSettings().graphic.biomeBlend = value;
        }

        private void UpdateResolution(float arg0)
        {
            var value = ((int x, int y))resolutions.resTuple.GetValue((int)arg0);
            resolution.GetComponentInChildren<TextMeshProUGUI>().text = $"{value.x}x{value.y}";
            settingsManager.GetSettings().screenResolution = new Vector2(value.x, value.y);
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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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
            var value = 0;
            guiScale.GetComponentInChildren<TextMeshProUGUI>().text = $"GUI Scale: {++value}";
            settingsManager.GetSettings().graphic.guiScale = value;
        }

        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}