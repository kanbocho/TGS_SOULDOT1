using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space; //攻撃キー
    public GameObject AttackArea; //攻撃判定用のオブジェクト
    public Animator animator; //Animatorコンポーネント
    public string attackTriggerName = "AttackTrigger";
    public float attackDuration = 0.3f; //攻撃判定を有効にする時間
    public float attackCooldown = 0.5f; //攻撃のクールタイム

    private bool canAttack = true; //攻撃可能かどうかのフラグ

    // Start is called before the first frame update
    void Start()
    {
        //Insoectorで設定されていなければ、同じオブジェクトからの取得を試みる
        if(animator == null)
        {
            animator = GetComponent<Animator>();
            if(animator == null)
            {
                Debug.LogError("AnimatorコンポーネントがPlayerオブジェクトに見つかりません！");
            }
        }
        //攻撃判定エリアが設定されているか確認
        if(AttackArea == null)
        {
            Debug.LogError("attackAreaが設定されていません！Playerの子オブジェクトとして作成し、Inspectorで設定してください。");
        }
        else
        {
            AttackArea.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(attackKey)&& canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        canAttack = false;

        if(animator != null)
        {
            //アニメーション名を指定して再生
            animator.SetTrigger(attackTriggerName);
        }

        if(AttackArea != null)
        {
            AttackArea.SetActive(true);

            StartCoroutine(DisableAttackAreaAfterDelay(attackDuration));
        }

        // クールタイム処理のコルーチンを開始
        StartCoroutine(AttackCooldownCoroutine(attackCooldown));
    }

    // 指定時間後に攻撃判定を無効にするコルーチン
    IEnumerator DisableAttackAreaAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 指定された時間待機

        if (AttackArea != null)
        {
            AttackArea.SetActive(false); // 攻撃判定を無効にする
        }
    }

    // クールタイム処理のコルーチン
    IEnumerator AttackCooldownCoroutine(float cooldown)
    {
        yield return new WaitForSeconds(cooldown); // 指定されたクールタイム待機

        canAttack = true; // 攻撃可能にする
    }
}
