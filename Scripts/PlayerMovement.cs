using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("�v���C���[�̈ړ��X�s�[�h")]
    [SerializeField] private float playerMoveSpeed;
    private float xMoveDirection;
    private float rightDirection = 1;
    private float leftDirection = -1;
    private Rigidbody2D playerRB;
    private Vector3 rightDirRot = new Vector3(0f, 0f, 0f);
    private Vector3 leftDirRot = new Vector3(0f, 180f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        PlayerSplineState.Instance.SetStandImage();
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xMoveDirection = 0;

        if (!GameState.Instance.IsGameScene()) return;

        if (Input.GetKey(KeyCode.LeftArrow)) xMoveDirection = leftDirection;
        else if (Input.GetKey(KeyCode.RightArrow)) xMoveDirection = rightDirection;

        PlayerMove(xMoveDirection);
    }
    /// <summary>
    /// �v���C���[�̈ړ�
    /// </summary>
    /// /// <param name="_xmoveDirection">1:�E�ɐi�ށA-1:���ɐi��</param>
    private void PlayerMove(float _xMoveDirection)
    {
        playerRB.velocity = new Vector2(_xMoveDirection * playerMoveSpeed, playerRB.velocity.y);

        if(_xMoveDirection > 0)
        {
            PlayerSplineState.Instance.SetWalkImage();
            transform.eulerAngles = rightDirRot;
        }
        else if(_xMoveDirection < 0)
        {
            PlayerSplineState.Instance.SetWalkImage();
            transform.eulerAngles = leftDirRot;
        }
        else if(_xMoveDirection == 0)
        {
            if (GameState.Instance.IsGameScene()) PlayerSplineState.Instance.SetStandImage();
        }
    }
}
