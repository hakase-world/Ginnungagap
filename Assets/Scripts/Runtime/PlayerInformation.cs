using UnityEngine;

namespace Game.Runtime
{	
	[CreateAssetMenu]
	public class PlayerInformation : ScriptableObject
	{
		public Transform transform { set; get; }
	}
}