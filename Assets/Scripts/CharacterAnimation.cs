using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class CharacterAnimation : MonoBehaviour
{
    Animator animator;

    GameObject enemy;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject parry;

    public bool isGrounded;
    public bool finishAttack;

    bool charge;
    bool attack;

    public float chargeTimer=0;

    public GameObject chargeEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GameObject.Find("Enemy");
    }

    void Update()
    {
        //리플렉션 타입
        //isGrounded = (bool)(GetComponent("ThirdPersonCharacter").GetType()).GetField("m_IsGrounded").GetValue(GetComponent("ThirdPersonCharacter"));
        Attack();
        isGround();
        Parry();
        Sheathe();
        //Charge();
    }

    void isGround()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.down * 0.3f, Color.red);
        if (Physics.Raycast(transform.position-(Vector3.down*0.1f), Vector3.down, out hit, 0.3f))
        {
            if (hit.transform.tag == "Stage")
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Slash3"))
        {
            if (enemy.GetComponent<EnemyHit>().parry == true)
            {
                //enemy.transform.position = gameObject.transform.localPosition + Vector3.forward;
                enemy.transform.LookAt(transform.position);
                transform.LookAt(enemy.transform.position);
                animator.SetTrigger("Finish");
                enemy.GetComponent<EnemyHit>().animator.SetTrigger("FinishHit");
                finishAttack = true;

                
            }
            else 
                animator.SetTrigger("Attack");
        }

        //if(chargeTimer>=2)
        //{
        //    if(Input.GetMouseButtonUp(0))
        //        animator.SetTrigger("ChargeAttack");
        //}
    }

    void Sheathe()
    {
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetBool("Sheathe", true);
        }
        else
            animator.SetBool("Sheathe", false);
    }

    void Charge()
    {
        if (Input.GetMouseButton(0))
        {
            charge = true;
            chargeTimer += Time.deltaTime;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            charge = false;
            chargeTimer = 0;
        }
    }

    void Parry()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("Parry");
        }
    }

    void WeaponTriggerOff()
    {
        weapon.GetComponent<BoxCollider>().enabled = false;
    }
    void WeaponTriggerOn()
    {
        weapon.GetComponent<BoxCollider>().enabled = true;
    }

    void ParryOn()
    {
        parry.SetActive(true);
    }
    void ParryOff()
    {
        parry.SetActive(false);
    }

    void FinishAttack()
    {
        finishAttack = false;
    }
}
