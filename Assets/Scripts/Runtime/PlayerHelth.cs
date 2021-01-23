using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Runtime
{
	public class PlayerHelth : MonoBehaviour
	{
		public TextMeshProUGUI helthText;
		private Helth helth;

		void Start()
		{
			helth = FindObjectOfType<PlayerController>().GetComponent<Helth>();
		}

		// Update is called once per frame
		void Update()
		{
			helthText.text=helth._currentHelth.ToString();
		}
	}
}
