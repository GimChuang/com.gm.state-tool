using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.StateTool
{
    public class StateKeyChecker : StateLogicChecker, IStateBehavior
    {
        public KeyCode key;

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
            if (Input.GetKeyDown(key))
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