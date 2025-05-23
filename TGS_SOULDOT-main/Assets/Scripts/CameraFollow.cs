using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; //追従するプレイヤーのTransform
    public float smoothSpeed = 0.125f; //カメラの追従を滑らかにする速度
    public Vector3 offset; //プレイヤーからの相対的なカメラのオフセット

    void LateUpdate()
    {
        if (player == null) return; //プレイヤーが設定されていない場合は処理しない

        Vector3 desiredPosition = player.position + offset; //目標とするカメラの位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); //現在位置から目標位置へ滑らかに移動
        transform.position = smoothedPosition; //カメラの位置を更新
    }
}
