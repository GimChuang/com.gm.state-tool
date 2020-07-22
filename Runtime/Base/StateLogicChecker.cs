using UnityEngine;

namespace GM.StateTool
{
    public abstract class StateLogicChecker : MonoBehaviour
    {
        /* This class is responsible for checking some condition (timer, clicking on buttons, etc.)
         * , and asking current GameState to terminate and the next GameState to start. */

        protected bool canStopUpdate = false;

        protected virtual void OnEnable()
        {

        }

        protected virtual void OnDisable()
        {

        }
    }
}
