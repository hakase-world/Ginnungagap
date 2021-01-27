using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Runtime
{
	public class PlayerController : MonoBehaviour
	{
		public PlayerInformation playerInformation;
		public Transform target;
		public Transform weaponPlace;

		[Header("移動の速度 m/s")]
		public float speed = 1f;
		[Header("重力")]
		public float gravity = -9.81f;

		[Header("ジャンプの高さ")]
		public float jumpHeight = 2;

		private CharacterController controller { get; set; }
		Vector3 velocity; // 移動量

		Vector2 _move;                // 移動方向の入力
		private bool _jumpPressed;    // ジャンプの入力の有無
		private Vector2 _screenPoint; // 射撃の位置

		public void OnMove(InputAction.CallbackContext context)
		{
			// 入力の読み取り
			_move = context.ReadValue<Vector2>();
		}

		public void OnJump(InputAction.CallbackContext context)
		{
			_jumpPressed = context.ReadValueAsButton();
		}

		public void OnAim(InputAction.CallbackContext context)
		{
			_screenPoint = context.ReadValue<Vector2>();
		}

		void Start()
		{
			playerInformation.transform = target.transform;
			controller = GetComponent<CharacterController>();
		}

		void Update()
		{

			Vector3 move = Move(_move, Camera.main);        /* 移動方向の計算 */
			controller.Move(move * speed * Time.deltaTime); /* 移動の処理     */

			if (_jumpPressed) // ジャンプボタンを押したか判定
			{
				velocity.y = Parabora(jumpHeight, gravity); // ジャンプ力の計算
			}

			//自由落下運動
			velocity.y += gravity * Time.deltaTime;
			controller.Move(velocity * Time.deltaTime);

			// マウスカーソルなどのポインターデバイスのカメラのスクリーン座標の中の位置からレイを作成しています。
			Ray pointer = Camera.main.ScreenPointToRay(_screenPoint);
			// 狙いを定める位置を可能な限り遠くにしたいのでint型の最大値を乗算しています。
			Vector3 target = pointer.direction * 9223372036854775807;
			// 武器を所持する親オブジェクトの向きを狙っている位置に向きを変えています。
			weaponPlace.LookAt(target);
			// どこを狙っているか分かるようにレイを可視化しています。
			Debug.DrawRay(pointer.origin, target);

			//transform.localPosition.x = Mathf.Clamp(transform.localPosition.x, 0, 10)
		}

		Vector3 Move(Vector2 direction, Camera camera)
		{
			var h = direction.x;          // 横方向
			var v = direction.y;          // 縦方向
			var camT = camera.transform;  // カメラの位置情報
			var hv = h * camT.right;      // カメラから見て横方向
			var vv = v * camT.up;         // カメラから見て縦方向
			var m = hv + vv;              // 移動方向の計算
			return m;
		}

		float Parabora(float height, float gravity)
		{
			var h = height;
			var g = gravity;
			var v = 0.0f;
			v = Mathf.Sqrt(h * -2 * g);
			return v;
		}

		float FreeFall(float gravity, float deltaTime)
		{
			var g = gravity;   // 重力
			var t = deltaTime; // 時間
			var v = 0.0f;      // 速度
			v = g * t;         // 自由落下の計算
			return v;
		}
	}
}