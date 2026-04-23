using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// カメラ追従の処理を行うクラス
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("プレイヤー参照")]
    [Tooltip("プレイヤーの位置を取得し、カメラの位置を更新する")]
    [SerializeField] private Transform playerTransform;
    private float playerZOffset = -10f;

    void Update()
    {
        //常にプレイヤーの位置に合わせてカメラの位置を更新する
        transform.position = new Vector3(playerTransform.position.x, 0f, playerZOffset);
    }
}
