using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charging : StateMachineBehaviour
{
    public string attackArts;
    public string attackName;
    public string particleName;
    public bool isFirst = true;

    public float chargeTime;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        chargeTime = GameObject.Find("Player").GetComponent<CharacterAnimation>().chargeTimer;

        if(chargeTime == 0)
        {
            animator.transform.Find(attackArts).transform.Find(attackName).transform.Find(particleName).GetComponent<ParticleSystem>().Stop();
        }
        if (chargeTime > 1)
        {
            if(isFirst)
            {
                animator.transform.Find(attackArts).transform.Find(attackName).transform.Find(particleName).GetComponent<ParticleSystem>().Play();
            }
            isFirst = false;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        isFirst = true;
    }
}
