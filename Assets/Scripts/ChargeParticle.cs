using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeParticle : StateMachineBehaviour
{
    public string attackArts;
    public string attackName;
    public string particleName;
    public float attackdelay;
    public bool isFirst = true;

    public float chargeTime;

    public void Update()
    {
        chargeTime = GameObject.Find("Archer").transform.Find("ArcherCustom").GetComponent<CharacterAnimation>().chargeTimer;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= attackdelay)
        {
            if (isFirst)
            {
                if (chargeTime >= 2)
                {
                    animator.transform.Find(attackArts).transform.Find(attackName).transform.Find("Sword Slash 6").GetComponent<ParticleSystem>().Play();
                }
                animator.transform.Find(attackArts).transform.Find(attackName).transform.Find(particleName).GetComponent<ParticleSystem>().Play();
                isFirst = false;
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        isFirst = true;
    }
}
