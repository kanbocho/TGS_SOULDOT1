using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Space; //�U���L�[
    public GameObject AttackArea; //�U������p�̃I�u�W�F�N�g
    public Animator animator; //Animator�R���|�[�l���g
    public string attackTriggerName = "AttackTrigger";
    public float attackDuration = 0.3f; //�U�������L���ɂ��鎞��
    public float attackCooldown = 0.5f; //�U���̃N�[���^�C��

    private bool canAttack = true; //�U���\���ǂ����̃t���O

    // Start is called before the first frame update
    void Start()
    {
        //Insoector�Őݒ肳��Ă��Ȃ���΁A�����I�u�W�F�N�g����̎擾�����݂�
        if(animator == null)
        {
            animator = GetComponent<Animator>();
            if(animator == null)
            {
                Debug.LogError("Animator�R���|�[�l���g��Player�I�u�W�F�N�g�Ɍ�����܂���I");
            }
        }
        //�U������G���A���ݒ肳��Ă��邩�m�F
        if(AttackArea == null)
        {
            Debug.LogError("attackArea���ݒ肳��Ă��܂���IPlayer�̎q�I�u�W�F�N�g�Ƃ��č쐬���AInspector�Őݒ肵�Ă��������B");
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
            //�A�j���[�V���������w�肵�čĐ�
            animator.SetTrigger(attackTriggerName);
        }

        if(AttackArea != null)
        {
            AttackArea.SetActive(true);

            StartCoroutine(DisableAttackAreaAfterDelay(attackDuration));
        }

        // �N�[���^�C�������̃R���[�`�����J�n
        StartCoroutine(AttackCooldownCoroutine(attackCooldown));
    }

    // �w�莞�Ԍ�ɍU������𖳌��ɂ���R���[�`��
    IEnumerator DisableAttackAreaAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // �w�肳�ꂽ���ԑҋ@

        if (AttackArea != null)
        {
            AttackArea.SetActive(false); // �U������𖳌��ɂ���
        }
    }

    // �N�[���^�C�������̃R���[�`��
    IEnumerator AttackCooldownCoroutine(float cooldown)
    {
        yield return new WaitForSeconds(cooldown); // �w�肳�ꂽ�N�[���^�C���ҋ@

        canAttack = true; // �U���\�ɂ���
    }
}
