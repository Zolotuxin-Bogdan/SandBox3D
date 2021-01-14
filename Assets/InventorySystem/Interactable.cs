using Assets.Scripts;
using UnityEngine;

namespace Assets.InventorySystem
{
    public class Interactable : MonoBehaviour {
        [Range(0, 3)]
        public float pickUpRadius = 1f;

        Transform player;

        void Start() {
            player = PlayerController.instance.transform;
        }

        void Update() {
            if (Vector3.Distance(player.position, transform.position) <= pickUpRadius) {
                Interact();
            }
        }

        void OnDrawGizmosSelected() {
            Gizmos.color = new Color(1, 0, 1, 0.2f);
            Gizmos.DrawCube(transform.position, new Vector3(pickUpRadius, pickUpRadius, pickUpRadius));
        }

        public virtual void Interact() {
            Debug.Log("Interacting with " + transform.name);
        }

        
    }
}