using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public class WeaponManager : MonoBehaviour
	{
		public Weapon[] startingWeapons;

		List<Weapon> _weapons = new List<Weapon>();
		int _currentWeapon = -1;

		public void OnFire(InputAction.CallbackContext context)
		{
			_weapons[_currentWeapon].triggerDown = context.ReadValueAsButton();
		}

		public void Start()
		{
			foreach (var weapon in startingWeapons)
			{
				Pickup(weapon);
			}
			Change(0);
		}

		void Pickup(Weapon prefab)
		{
			var w = Instantiate(prefab, transform);
			w.name = prefab.name;
			w.gameObject.SetActive(false);
			_weapons.Add(w);
		}

		void Change(int number)
		{
			if (_currentWeapon != -1)
			{
				_weapons[_currentWeapon].gameObject.SetActive(false);
			}

			_currentWeapon = number;

			if (_currentWeapon < 0)
			{
				_currentWeapon = _weapons.Count - 1;
			}
			else
			if (_currentWeapon >= _weapons.Count)
			{
				_currentWeapon = 0;
			}

			_weapons[_currentWeapon].gameObject.SetActive(true);
		}
	}
}
