using UnityEngine;

namespace Assets.Scripts
{
    public class Interactable : MonoBehaviour {
        [Range(0, 3)]
        public float pickUpRadius = 1f;

        public Vector3 playerPosition;

        void Start()
        {
            playerPosition = PlayerController.instance.transform.position;
            OnCreate();
        }

        void Update() {
            if (Vector3.Distance(
                new Vector3(playerPosition.x, 0, playerPosition.z),
                new Vector3(transform.position.x, 0, transform.position.z)
                ) <= pickUpRadius) {
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

        public virtual void OnCreate() { 
            Debug.Log("Object created"); 
        }
        
    }
}