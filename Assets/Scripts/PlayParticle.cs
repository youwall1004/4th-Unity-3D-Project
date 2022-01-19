using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : StateMachineBehaviour
{
    public string attackArts;
    public string attackName;
    public string particleName;
    public float attackdelay;
    public bool isFirst = true;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(stateInfo.normalizedTime >= attackdelay)
       {
            //isFirst�� �־ Update������ ������ �α� ����
            if (isFirst)
            {
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
