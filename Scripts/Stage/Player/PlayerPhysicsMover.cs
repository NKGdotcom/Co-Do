using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒvƒŒƒCƒ„[‚Ì•¨—‹““®‚ğİ’è
/// </summary>
public class PlayerPhysicsMover : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private void Awake()
    {
        TryGetComponent<Rigidbody2D>(out playerRb);
    }

    /// <summary>
    /// •¨—ˆÚ“®
    /// </summary>
    /// <param name="_xMoveDirection"></param>
    public void PhysicsMovement(float _xMoveDirection)
    {
        Vector2 _direction = new Vector2(_xMoveDirection, playerRb.velocity.y);
        playerRb.velocity = _direction;
    }
}
