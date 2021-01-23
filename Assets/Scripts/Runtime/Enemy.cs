using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime
{
	public class Enemy : MonoBehaviour
	{
		public PlayerInformation playerInformation;

		public GameObject projectilePrefab;
		[Tooltip("何秒間隔で弾を打ち出すか"), Min(0.0f)]
		public float fireRate = 0.5f;
		[Tooltip("１回の射撃での射出数")]
		public int projectileParShot = 1;

		float _shotTimer = -1f;

		private readonly Queue<GameObject> _objectPool = new Queue<GameObject>();
		
		void Update()
		{
			//タイマーをカウントダウンします。弾はタイマーが0になったときに発射します。
			if (_shotTimer > 0)
				_shotTimer -= Time.deltaTime;
			
			//射撃および発射
			Fire();
		}

		void Fire()
		{
			//射撃してからfireRateの時間が経過していないときは発射しないようにしています。
			if (_shotTimer>0)
				return;
			
			//タイマーをリセットしています。
			_shotTimer = fireRate;

			//オブジェクトプールの中にオブジェクトがあれば、それを使います。
			if (_objectPool.Count > 0)
			{
				GameObject projectileObject = _objectPool.Dequeue();
				projectileObject.SetActive(true);
				projectileObject.transform.position = transform.position;
				var projectile = projectileObject.GetComponent<Projectile>();
				projectile.Init(playerInformation.transform.position-transform.position,gameObject);
			}
			//オブジェクトがなければ、新しく作ります。
			else
			{
				//新しい弾の生成を行います
				GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
				//弾の初期設定を行うためにProjectileコンポーネントを取得しています。
				var projectile = projectileObject.GetComponent<Projectile>();
				//弾を初期化を行います。
				projectile.Init(playerInformation.transform.position - transform.position, gameObject);
				//弾がプレイヤーに衝突したときのコールバックを登録します。
				projectile.onTrrigerCallback += () =>
				{
					//弾をディアクティベーションします。
					projectileObject.SetActive(false);
					//弾をオブジェクトプールに追加することで、のちにリユースできるようにします。
					_objectPool.Enqueue(projectileObject);
				};
			}
		}
	}
}
