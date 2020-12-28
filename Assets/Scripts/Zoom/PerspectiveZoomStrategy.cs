using UnityEngine;

namespace Assets.Scripts.Zoom
{
    public class PerspectiveZoomStrategy : IZoomStrategy
    {
        Vector3 normalizedCameraPosition;
        float currentZoomLevel;

        public PerspectiveZoomStrategy(Camera cam, Vector3 offset ,float startingZoom)
        {
             cam.transform.localPosition = new Vector3(0f, Mathf.Abs(offset.y), Mathf.Abs(offset.x)).normalized;
            currentZoomLevel = startingZoom * 6;
            PositionCamera(cam);
        }

        private void PositionCamera(Camera cam)
        {
            cam.fieldOfView = currentZoomLevel;
        }

        public void ZoomIn(Camera cam, float delta, float minZoomLimit)
        {
            if (currentZoomLevel <= minZoomLimit * 6) return;
            currentZoomLevel = Mathf.Max(currentZoomLevel - delta, minZoomLimit * 6);
            PositionCamera(cam);
        }

        public void ZoomOut(Camera cam, float delta, float maxZoomLimit)
        {
            if (currentZoomLevel >= maxZoomLimit * 6) return;
            currentZoomLevel = Mathf.Min(currentZoomLevel + delta, maxZoomLimit * 6);
            PositionCamera(cam);
        }
    }
}