using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 1.5f; //�G�̈ړ����x
    public Transform playerTransform; //�ǐՂ���v���C���[��Transform

    private Rigidbody2D rb;
    private SpriteRenderer sr; //SpriteRenderer�ւ̎Q�Ƃ�ǉ�
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); //SpriteRenderer�̎Q�Ƃ��擾

        if(rb == null) //Rigidbody2D�̃G���[�`�F�b�N
        {
            Debug.LogError("Rigidbody2D�R���|�[�l���g��Enemy�I�u�W�F�N�g�Ɍ�����܂���I");
        }

        if(sr == null) //SpriteRenderer�̃G���[�`�F�b�N
        {
            Debug.LogError("SpriteRenderer�R���|�[�l���g��Enemy�I�u�W�F�N�g�Ɍ�����܂���I");
        }

        //Player�I�u�W�F�N�g����������Transform���擾
        if(playerTransform == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if(playerObject != null)
            {
                playerTransform = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player�I�u�W�F�N�g��������܂���BPlayer�^�O��ݒ肵�Ă��������B");
            }
        }
    }

    void FixedUpdate() //�������Z�������ꍇ��FixedUpdate
    {
        if (playerTransform == null || rb == null ||sr == null) return; //�v���C���[�����Ȃ��ꍇ�͏������Ȃ�

        //�v���C���[�ւ̕������v�Z
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
