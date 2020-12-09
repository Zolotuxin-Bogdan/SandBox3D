using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    public class ControlsController: MonoBehaviour
    {
        private UnityAction action;
        public void AddListener(UnityAction action)
        {
            this.action = action;
        }
    }
}