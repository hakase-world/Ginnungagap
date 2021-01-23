using UnityEngine;

namespace Game.Runtime
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerInformation playerInformation;
        public Transform target;

        private CharacterController mController { get; set; }

        private void Awake()
        {
        }

        void Start()
        {
            playerInformation.transform = target.transform;
            mController = GetComponent<CharacterController>();
            print(mController.isTrigger);
        }


        void Update()
        {
            
        }
    }
}