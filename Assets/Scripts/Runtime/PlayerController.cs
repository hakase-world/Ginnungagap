using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Runtime
{
	public class PlayerController : MonoBehaviour
	{
		public PlayerInformation playerInformation;
		public Transform target;
		public Transform weaponPlace;
		private CharacterController mController { get; set; }

		private Vector3 move;

		public void OnMove(InputAction.CallbackContext context)
		{
			move = context.ReadValue<Vector2>();
		}

		void Start()
		{
			playerInformation.transform = target.transform;
			mController = GetComponent<CharacterController>();
		}


		void Update()
		{
			mController.Move(move);
		}



	}
}