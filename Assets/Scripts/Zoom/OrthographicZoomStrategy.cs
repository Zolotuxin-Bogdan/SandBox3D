using UnityEngine;

namespace Assets.Scripts.Zoom
{
    public class OrthographicZoomStrategy : IZoomStrategy
    {
        public OrthographicZoomStrategy(Camera cam, float startingZoom)
        {
            cam.orthographicSize = startingZoom;
        }
        public void ZoomIn(Camera cam, float delta, float minZoomLimit)
        {
            if (cam.orthographicSize.Equals(minZoomLimit)) return;
            cam.orthographicSize = Mathf.Max(cam.orthographicSize - delta, minZoomLimit);
        }

        public void ZoomOut(Camera cam, float delta, float maxZoomLimit)
        {
            if (cam.orthographicSize.Equals(maxZoomLimit)) return;
            cam.orthographicSize = Mathf.Min(cam.orthographicSize + delta, maxZoomLimit);
        }
    }
}