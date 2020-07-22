using UnityEngine;

namespace GM.StateTool
{
    public abstract class StateTransitionSetter : MonoBehaviour
    {
        /* This class is responsible for setting duration of GameStates' transition. */

        public float delayDuration;
        public float transInDuration;
        public float transOutDuration;
    }
}