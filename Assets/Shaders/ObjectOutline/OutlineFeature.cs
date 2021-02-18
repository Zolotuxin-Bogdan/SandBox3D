using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Shaders.ObjectOutline
{
    public class OutlineFeature : ScriptableRendererFeature
    {
        [SerializeField] private string _renderTextureName;
        [SerializeField] private RenderSettings _renderSettings;

        private RenderTargetHandle _renderTexture;
        private CustomRenderObjectPass _renderPass;

        [Serializable]
        public class RenderSettings
        {
            public Material OverrideMaterial = null;
            public LayerMask LayerMask = 0;
        }

        [SerializeField] private string _bluredTextureName;
        [SerializeField] private BlurSettings _blurSettings;
        private RenderTargetHandle _bluredTexture;
        private BlurRenderPass _blurPass;

        [Serializable]
        public class BlurSettings
        {
            public Material BlurMaterial;
            public int DownSample = 1;
            public int PassesCount = 1;
        }

        [SerializeField] private Material _outlineMaterial;
        private OutlineRenderPass _outlinePass;

        [SerializeField] private RenderPassEvent _renderPassEvent;


        public override void Create()
        {
            _renderTexture.Init(_renderTextureName);

            _renderPass = new CustomRenderObjectPass(_renderTexture, _renderSettings.LayerMask, _renderSettings.OverrideMaterial);

            _bluredTexture.Init(_bluredTextureName);

            _blurPass = new BlurRenderPass(_blurSettings.BlurMaterial, _blurSettings.DownSample, _blurSettings.PassesCount);

            _outlinePass = new OutlineRenderPass(_outlineMaterial);

            _renderPass.renderPassEvent = _renderPassEvent;
            _blurPass.renderPassEvent = _renderPassEvent;
            _outlinePass.renderPassEvent = _renderPassEvent;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(_renderPass);
            renderer.EnqueuePass(_blurPass);
            renderer.EnqueuePass(_outlinePass);
        }
    }
}
