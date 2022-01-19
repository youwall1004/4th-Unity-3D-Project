using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    GameObject weapon;

    private void Start()
    {
        weapon = GameObject.Find("HitBox");    
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
