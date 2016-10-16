using UnityEngine;
using System.Collections;

public class GravityController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// 重力加速度
	const float GRAVITY = 9.81f;
	// 重力の適用具合
	public float gravityScale = 1.0f;
	
	// Update is called once per frame
	void Update () {
		// 重力ベクトルの初期化
		Vector3 vector = new Vector3();

		if (Application.isEditor)
		{
			// キーの入力を検知しベクトルを設定
			vector.x = Input.GetAxis("Horizontal");
			vector.z = Input.GetAxis("Vertical");

			// 高さの方向の判定はキーのzとする
			if (Input.GetKey("z"))
			{
				vector.y = 1.0f;
			}
			else {
				vector.y = -1.0f;
			}
		}
		else {
			// 加速度センサーの入力をUnity空間の軸にマッピング
			vector.x = Input.acceleration.x;
			vector.z = Input.acceleration.y;
			vector.y = Input.acceleration.z;
		}

		// シーンの重力を入力ベクトルの方向に合わせて変化させる
		Physics.gravity = GRAVITY * vector.normalized * gravityScale;
	}
}
