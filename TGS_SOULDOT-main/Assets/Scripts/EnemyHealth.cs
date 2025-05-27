using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; //�ő�̗�
    private int currentHelth; //���݂̗̑�

    public int damageReceivedFromPlayerAttack = 10; //�v���C���[�̍U������󂯂�_���[�W��

    // Start is called before the first frame update
    void Start()
    {
        currentHelth = maxHealth;
        Debug.Log(gameObject.name + "�̗̑�" + currentHelth);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHelth -= damageAmount; //�̗͂����炷
        Debug.Log(gameObject.name + "��" + damageAmount + "�_���[�W���󂯂܂����B���݂̗̑�" + currentHelth);

        if(currentHelth <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Debug.Log(gameObject.name + "�͓|����܂����I");
        Destroy(gameObject);
    }
}
