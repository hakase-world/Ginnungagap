using System.Collections;
using UnityEngine;

namespace Game.Runtime
{


	public class GameSystem : MonoBehaviour
	{
		public int enemyCount = 100;
		public int radius = 10;
		public GameObject enemyPrefab;

		public Transform playerPositon { get; set; }

		public double score { get; private set; }
		public int destroyedEnemy { get; private set; }
		public void Got(double point)
		{
			score += point;
			destroyedEnemy++;
		}
		IEnumerator WaitTime(float t)
		{
			yield return new WaitForSeconds(t);
		}

		// Start is called before the first frame update
		void Start()
		{
			for (int i = 0; i < enemyCount; i++)
			{
				var r = UnityEngine.Random.onUnitSphere;
				r *= radius;
				Instantiate(enemyPrefab, r, Quaternion.identity);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}
