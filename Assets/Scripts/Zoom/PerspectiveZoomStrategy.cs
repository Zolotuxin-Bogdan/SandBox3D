using UnityEngine;

namespace Assets.Scripts.Zoom
{
    public class PerspectiveZoomStrategy : IZoomStrategy
    {
        Vector3 normalizedCameraPosition;
        float currentZoomLevel;

        public PerspectiveZoomStrategy(Camera cam, Vector3 offset ,float startingZoom)
        {
            normalizedCameraPosition = new Vector3(0f, Mathf.Abs(offset.y), Mathf.Abs(offset.x)).normalized;
            currentZoomLevel = startingZoom;
            PositionCamera(cam);
        }

        private void PositionCamera(Camera cam)
        {
            cam.transform.localPosition = normalizedCameraPosition * currentZoomLevel;
        }

        public void ZoomIn(Camera cam, float delta, float minZoomLimit)
        {
            if (currentZoomLevel <= minZoomLimit) return;
            currentZoomLevel = Mathf.Max(currentZoomLevel  - delta, minZoomLimit);
            PositionCamera(cam);
        }

        public void ZoomOut(Camera cam, float delta, float maxZoomLimit)
        {
            if (currentZoomLevel <= maxZoomLimit) return;
            currentZoomLevel = Mathf.Min(currentZoomLevel  - delta, maxZoomLimit);
            PositionCamera(cam);
        }
    }
}