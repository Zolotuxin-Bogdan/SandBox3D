using UnityEngine;

namespace Assets.Scripts.Zoom
{
    public interface IZoomStrategy
    {
        void ZoomIn(Camera cam, float delta, float minZoomLimit);
        void ZoomOut(Camera cam, float delta, float maxZoomLimit);
    }
}