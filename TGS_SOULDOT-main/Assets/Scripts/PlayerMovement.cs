using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //移動速度

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; //SpriteRendererコンポーネントへの参照

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); //SpriteRendererを取得
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //入力処理
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //左右
        float verticalInput = Input.GetAxisRaw("Vertical");
        //上下

        //移動方向の計算
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        //移動処理
        rb.velocity = moveDirection * moveSpeed;
        Debug.Log("Setting Velocity: " + rb.velocity + " at Time: " + Time.time);

        //向き変更処理
        if (horizontalInput > 0) //右に移動している場合
        {
            spriteRenderer.flipX = false; //反転しない（右向き）
        }
        else if(horizontalInput < 0) //左に移動している場合
        {
            spriteRenderer.flipX = true;　//X軸反転（左向き）
        }
    }
}
