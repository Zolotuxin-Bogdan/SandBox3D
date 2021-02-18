using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Assets.Shaders.ObjectOutline
{
    public class OutlineRenderPass : ScriptableRenderPass
    {
        private string _profilerTag = "Outline";
        private Material _material;

        public OutlineRenderPass(Material material)
        {
            _material = material;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cmd = CommandBufferPool.Get(_profilerTag);

            using (new ProfilingSample(cmd, _profilerTag))
            {
                var mesh = RenderingUtils.fullscreenMesh;
                cmd.DrawMesh(mesh, Matrix4x4.identity, _material, 0, 0);
            }

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}
