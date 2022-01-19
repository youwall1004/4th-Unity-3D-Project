using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject target;
    [SerializeField] public bool parry;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
        {
            animator.SetTrigger("Damaged");
            Debug.Log("아파!(트리거)");
        }
        //if(other.name=="Player")
        //{
        //    if (target.GetComponent<CharacterAnimation>().parrying == true)
        //    {
        //        animator.SetTrigger("Parried");
        //    }
        //}
        if(other.CompareTag("Parry"))
        {
            animator.SetTrigger("Parried");
            parry = true;
        }
    }

    void ParryDelayOn()
    {
        animator.speed = 0.4f;
    }
    void ParryDelayOff()
    {
        animator.speed = 1;
        parry = false;
    }

    void WeaponTriggerOff()
    {
        weapon.GetComponent<BoxCollider>().enabled = false;
    }
    void WeaponTriggerOn()
    {
        weapon.GetComponent<BoxCollider>().enabled = true;
    }

}
