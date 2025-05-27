using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; //最大体力
    private int currentHelth; //現在の体力

    public int damageReceivedFromPlayerAttack = 10; //プレイヤーの攻撃から受けるダメージ量

    // Start is called before the first frame update
    void Start()
    {
        currentHelth = maxHealth;
        Debug.Log(gameObject.name + "の体力" + currentHelth);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHelth -= damageAmount; //体力を減らす
        Debug.Log(gameObject.name + "が" + damageAmount + "ダメージを受けました。現在の体力" + currentHelth);

        if(currentHelth <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Debug.Log(gameObject.name + "は倒されました！");
        Destroy(gameObject);
    }
}
