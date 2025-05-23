using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //�ړ����x

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; //SpriteRenderer�R���|�[�l���g�ւ̎Q��

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); //SpriteRenderer���擾
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //���͏���
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //���E
        float verticalInput = Input.GetAxisRaw("Vertical");
        //�㉺

        //�ړ������̌v�Z
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        //�ړ�����
        rb.velocity = moveDirection * moveSpeed;
        Debug.Log("Setting Velocity: " + rb.velocity + " at Time: " + Time.time);

        //�����ύX����
        if (horizontalInput > 0) //�E�Ɉړ����Ă���ꍇ
        {
            spriteRenderer.flipX = false; //���]���Ȃ��i�E�����j
        }
        else if(horizontalInput < 0) //���Ɉړ����Ă���ꍇ
        {
            spriteRenderer.flipX = true;�@//X�����]�i�������j
        }
    }
}
