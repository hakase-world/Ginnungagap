using UnityEngine;

namespace Game.Runtime
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerInformation playerInformation;
        public Transform target;
		public Transform weaponPlace;
        private CharacterController mController { get; set; }


		void Awake(){
			
		}

        void Start()
        {
            playerInformation.transform = target.transform;
            mController = GetComponent<CharacterController>();
        }


        void Update()
        {
            
        }
    }
}