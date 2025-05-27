using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; //�Ǐ]����v���C���[��Transform
    public float smoothSpeed = 0.125f; //�J�����̒Ǐ]�����炩�ɂ��鑬�x
    public Vector3 offset; //�v���C���[����̑��ΓI�ȃJ�����̃I�t�Z�b�g

    void LateUpdate()
    {
        if (player == null) return; //�v���C���[���ݒ肳��Ă��Ȃ��ꍇ�͏������Ȃ�

        Vector3 desiredPosition = player.position + offset; //�ڕW�Ƃ���J�����̈ʒu
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //���݈ʒu����ڕW�ʒu�֊��炩�Ɉړ�
        transform.position = smoothedPosition; //�J�����̈ʒu���X�V
    }
}
