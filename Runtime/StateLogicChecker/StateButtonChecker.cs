using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GM.StateTool
{
    public class StateButtonChecker : StateLogicChecker, IStateBehavior
    {
        public Button btn;

        public bool CanStopUpdate()
        {
            return canStopUpdate;
        }

        protected override void OnEnable()
        {
            btn.onClick.AddListener(delegate { canStopUpdate = true; });
        }

        protected override void OnDisable()
        {
            btn.onClick.RemoveAllListeners();
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
