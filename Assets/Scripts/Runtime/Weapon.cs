using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public class Weapon : MonoBehaviour
	{
		public Transform endPoint;
		public GameObject projectile;
		public bool triggerDown { get; set; }
		public void OnFire(InputAction.CallbackContext context)
		{
			triggerDown = context.ReadValueAsButton();
		}

		void Update()
		{
			if (triggerDown)
			{
				Instantiate(projectile, transform.position, Quaternion.identity);

				Ray ray = new Ray
				{
					origin = endPoint.position,
					direction = endPoint.forward
				};
				RaycastHit hit;
				bool isHit = Physics.Raycast(ray, out hit, 1000);
				Debug.DrawRay(ray.origin, ray.direction * 100000, Color.red, 1);
			}
		}
	}
}
