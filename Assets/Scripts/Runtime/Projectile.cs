using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Runtime
{
	public class Projectile : MonoBehaviour
	{
		[Tooltip("弾速（m/s）")]
		public float speed = 1f;
		public float damage = 1f;

		public Action onTrrigerCallback { get; set; }

		private Vector3 _velocity = Vector3.forward;
		private GameObject _owner;

		private void Update()
		{
			//弾はプレイヤーの方向に移動します。
			transform.position += _velocity * Time.deltaTime;
		}

		/// <summary>
		/// 弾の初期化を行います。
		/// </summary>
		/// <param name="direction">弾が移動する方向を表すベクトルです。</param>
		/// <param name="owner">弾を発射したオブジェクトの参照です。</param>
		public void Init(Vector3 direction, GameObject owner)
		{
			//ベクトルを正規化して、速度を乗算することで速度を求めている
			_velocity = Vector3.Normalize(direction) * speed;
			//弾を発射したオブジェクトの参照をフィールド変数に代入しています。
			_owner = owner;
		}

		/// <summary>
		/// 弾が何らかのコライダーに衝突したときのイベントです。
		/// </summary>
		/// <param name="other">衝突したコライダーの参照です</param>
		/*
		private void OnTriggerEnter(Collider other)
		{
			Helth helth = other.GetComponent<Helth>();
			helth.TakeDamage(damage);

			if (helth)
			{
				helth.TakeDamage(damage);
			}

			//衝突したオブジェクトのタグがPlayerだったとき、弾を発射したコンポーネントから登録されているイベントをすべて実行します。
			if (other.CompareTag("Player"))
				onTrrigerCallback.Invoke();
		}
		*/
	}
}
