using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.StateTool
{
    public class StateTimeChecker : StateLogicChecker, IStateBehavior
    {
        public float stateDuration = 3f;
        float timer = 0f;

        public bool CanStopUpdate()
        {
            return canStopUpdate;
        }

        public void OnStateInit()
        {

        }

        public void OnTransIn_Start()
        {

        }

        public void OnTransIn_End()
        {

        }

        public void StateUpdate()
        {
            timer += Time.deltaTime;
            if (timer >= stateDuration)
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
            timer = 0f;
        }
    }
}