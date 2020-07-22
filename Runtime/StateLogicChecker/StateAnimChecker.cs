using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.StateTool
{
    public class StateAnimChecker : StateLogicChecker, IStateBehavior
    {
        public Animator animator;
        public string stateName;
        int hash;

        public bool CanStopUpdate()
        {
            return canStopUpdate;
        }

        public void OnStateInit()
        {
            hash = Animator.StringToHash(stateName);
        }

        public void OnTransIn_Start()
        {

        }

        public void OnTransIn_End()
        {
            animator.Play(hash);
        }

        public void StateUpdate()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            {
                canStopUpdate = true;
            }
        }

        public void OnTransOut_Start()
        {

        }

        public void OnTransOut_End()
        {

        }

        public void OnStateReset()
        {
            canStopUpdate = false;
        }
    }
}