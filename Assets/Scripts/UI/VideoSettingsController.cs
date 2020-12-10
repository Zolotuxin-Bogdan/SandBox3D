using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class VideoSettingsController: MonoBehaviour
    {
        [Header("Sliders")]
        public Slider Resolution;
        public Slider BiomeBlend;
        public Slider RenderDistance;
        public Slider MaxFramerate;
        public Slider Brightness;
        public Slider MipmapLevels;
        
        [Header("Buttons")]
        public Button Graphics;
        public Button SmoothLighting;
        public Button UseVSync;
        public Button GUIScale;
        public Button Fullscreen;
        public Button ViewBobbing;
        public Button AttackIndicator;
        public Button Clouds;
        public Button Particles;
        public Button EntityShadows;
        public Button Done;


        //Unity Start Message
        void Start()
        {
            Debug.Log(">");
            Graphics.onClick.AddListener(UpdateGraphics);
            SmoothLighting.onClick.AddListener(UpdateSmoothLighting);
            UseVSync.onClick.AddListener(UpdateUseVSync);
            GUIScale.onClick.AddListener(UpdateGUIScale);
            Fullscreen.onClick.AddListener(UpdateFullscreen);
            ViewBobbing.onClick.AddListener(UpdateViewBobbing);
            AttackIndicator.onClick.AddListener(UpdateAttackIndicator);
            Clouds.onClick.AddListener(UpdateClouds);
            Particles.onClick.AddListener(UpdateParticles);
            EntityShadows.onClick.AddListener(UpdateEntityShadows);
            Done.onClick.AddListener(Submit);
            Debug.Log(">>");
            Resolution.onValueChanged.AddListener(UpdateResolution);
            BiomeBlend.onValueChanged.AddListener(UpdateBiomeBlend);
            RenderDistance.onValueChanged.AddListener(UpdateRenderDistance);
            MaxFramerate.onValueChanged.AddListener(UpdateMaxFramerate);
            Brightness.onValueChanged.AddListener(UpdateBrightness);
            MipmapLevels.onValueChanged.AddListener(UpdateMipmapLevels);
            Debug.Log(">>>");
        }

        private void Submit()
        {
            action.Invoke();
        }

        private void UpdateMipmapLevels(float arg0)
        { 
            var value = Converter.FromIdToString<MipmapLevels>((int)arg0);
            MipmapLevels.GetComponentInChildren<TextMeshProUGUI>().text = $"Mipmap Levels: {value}";
        }

        private void UpdateBrightness(float arg0)
        {
            var value = Converter.FromIdToString<Brightness>((int)arg0);
            Brightness.GetComponentInChildren<TextMeshProUGUI>().text = $"Brightness: {value}";
        }

        private void UpdateMaxFramerate(float arg0)
        {
            MaxFramerate.GetComponentInChildren<TextMeshProUGUI>().text = $"Max Framerate: {arg0} frames";
        }

        private void UpdateRenderDistance(float arg0)
        {
            RenderDistance.GetComponentInChildren<TextMeshProUGUI>().text = $"Render Distance: {arg0} chunks";
        }

        private void UpdateBiomeBlend(float arg0)
        {
            var value = Converter.FromIdToString<BiomeBlend>((int)arg0);
            BiomeBlend.GetComponentInChildren<TextMeshProUGUI>().text = $"Biome Blend: {value}";
        }

        private void UpdateResolution(float arg0)
        {
            Resolution.GetComponentInChildren<TextMeshProUGUI>().text = $"{arg0}";
        }

        private void UpdateEntityShadows()
        {
            throw new System.NotImplementedException();
        }

        private void UpdateParticles()
        {
            throw new System.NotImplementedException();
        }

        private void UpdateClouds()
        {
            throw new System.NotImplementedException();
        }

        private void UpdateAttackIndicator()
        {
            throw new System.NotImplementedException();
        }

        private void UpdateViewBobbing()
        {
            throw new System.NotImplementedException();
        }

        private void UpdateFullscreen()
        {
            throw new System.NotImplementedException();
        }

        void UpdateGraphics()
        {

        }

        void UpdateSmoothLighting()
        {

        }

        void UpdateUseVSync()
        {

        }

        void UpdateGUIScale()
        {

        }

        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}