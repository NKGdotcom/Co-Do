using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform playerTr; // �v���C���[��Transform��Inspector��������

    private void Update()
    {
        // �J�������v���C���[�̏ꏊ��
        transform.position = new Vector3(playerTr.position.x,0, -10f);
    }
}
