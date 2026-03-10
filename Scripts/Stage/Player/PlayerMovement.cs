using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //---プレイヤーの移動について---
    [SerializeField] private PlayerPhysicsMover playerPhysicsMover;
    private float playerMoveSpeed;

    /// <param name="_data"></param>
    public void SetUp(PlayerData _data)
    {
        playerMoveSpeed = _data.playerMoveSpeed;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    public void PlayerMoveMovement(float _horizontalInput)
    {
        float _xMoveDirection = _horizontalInput * playerMoveSpeed;
        playerPhysicsMover.PhysicsMovement(_xMoveDirection);
    }
}
