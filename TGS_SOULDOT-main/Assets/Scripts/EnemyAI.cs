using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 1.5f; //敵の移動速度
    public Transform playerTransform; //追跡するプレイヤーのTransform

    private Rigidbody2D rb;
    private SpriteRenderer sr; //SpriteRendererへの参照を追加
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); //SpriteRendererの参照を取得

        if(rb == null) //Rigidbody2Dのエラーチェック
        {
            Debug.LogError("Rigidbody2DコンポーネントがEnemyオブジェクトに見つかりません！");
        }

        if(sr == null) //SpriteRendererのエラーチェック
        {
            Debug.LogError("SpriteRendererコンポーネントがEnemyオブジェクトに見つかりません！");
        }

        //Playerオブジェクトを検索してTransformを取得
        if(playerTransform == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if(playerObject != null)
            {
                playerTransform = playerObject.transform;
            }
            else
            {
                Debug.LogError("Playerオブジェクトが見つかりません。Playerタグを設定してください。");
            }
        }
    }

    void FixedUpdate() //物理演算を扱う場合はFixedUpdate
    {
        if (playerTransform == null || rb == null ||sr == null) return; //プレイヤーがいない場合は処理しない

        //プレイヤーへの方向を計算
        Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;

        rb.velocity = directionToPlayer * moveSpeed;

        if(playerTransform.position.x < transform.position.x)
        {
            sr.flipX = false;
        }
        else if(playerTransform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
    }
}
