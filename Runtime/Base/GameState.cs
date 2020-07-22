using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GM.StateTool
{
    public class GameState : MonoBehaviour
    {

        // durations
        public StateTransitionSetter stateTransitionSetter;
        float delayDuration;
        float transInDuration;
        float transOutDuration;

        public bool hasTransInOrDelayStart { get; private set; }

        public bool canUpdate { get; private set; }

        public bool hasTransOutStart { get; private set; }

        List<IStateBehavior> stateBehaviors = new List<IStateBehavior>();

        #region EVENTS
        [System.Serializable]
        public class TransitionInStartEvent : UnityEvent { }
        public TransitionInStartEvent transitionInStartEvent;
        [System.Serializable]
        public class TransitionInEndEvent : UnityEvent { }
        public TransitionInEndEvent transitionInEndEvent;
        [System.Serializable]
        public class TransitionOutStartEvent : UnityEvent { }
        public TransitionOutStartEvent transitionOutStartEvent;
        [System.Serializable]
        public class TransitionOutEndEvent : UnityEvent { }
        public TransitionOutEndEvent transitionOutEndEvent;
        #endregion EVENTS

        void Awake()
        {

        }

        void Start()
        {

        }

        #region PUBLIC_FUNCTIONS

        public void StateInit()
        {

            // Set up this GameState's durations
            if (stateTransitionSetter != null)
            {
                delayDuration = stateTransitionSetter.delayDuration;
                transInDuration = stateTransitionSetter.transInDuration;
                transOutDuration = stateTransitionSetter.transOutDuration;
            }
            else // If no StateTransitionSetter is assigned, this GameState's durations will just remain 0.
            {
                int transitionSetterCount = gameObject.GetComponents<StateTransitionSetter>().Length;

                if (transitionSetterCount == 1)
                {
                    // There's only 1 StateTransitionSetter component on this gameObject so just grab it.
                    stateTransitionSetter = GetComponent<StateTransitionSetter>();
                    delayDuration = stateTransitionSetter.delayDuration;
                    transInDuration = stateTransitionSetter.transInDuration;
                    transOutDuration = stateTransitionSetter.transOutDuration;
                }
                else if (transitionSetterCount > 1)
                {
                    Debug.LogWarning(gameObject.name + " has multiple StateTransitionSetters. Please assign 1 StateTransitionSetter for the GameState's durations.");
                }
            }

            // Get all objects which implement IStateBehavior
            gameObject.GetComponents<IStateBehavior>(stateBehaviors);
            //Debug.Log(gameObject.name + " has Behavior: " + stateBehaviors.Count);
            for (int i = 0; i < stateBehaviors.Count; i++)
            {
                stateBehaviors[i].OnStateInit();
            }

        }

        public void StateTransIn()
        {
            StartCoroutine(E_StateTransIn());
        }

        public void StateUpdate()
        {
            for (int i = 0; i < stateBehaviors.Count; i++)
            {
                stateBehaviors[i].StateUpdate();
            }

            // If any stateBehaviors' canStopUpdate becomes true, go to next state
            for (int i = 0; i < stateBehaviors.Count; i++)
            {
                if (stateBehaviors[i].CanStopUpdate())
                {
                    GameStateManager.Instance.GoToNextState();
                }
            }

        }

        public void StateTransOut()
        {
            StartCoroutine(E_StateTransOut());
        }

        #endregion PUBLIC_FUNCTIONS

        #region PRIVATE_FUNCTIONS

        // Called in OnTransOut_End()
        void StateReset()
        {
            hasTransInOrDelayStart = false;
            canUpdate = false;
            hasTransOutStart = false;

            for (int i = 0; i < stateBehaviors.Count; i++)
            {
                stateBehaviors[i].OnStateReset();
            }
        }

        IEnumerator E_StateTransIn()
        {
            hasTransInOrDelayStart = true;

            float timer_delay = 0f;
            while (timer_delay < delayDuration)
            {
                timer_delay += Time.deltaTime;
                yield return null;
            }

            OnTransIn_Start();

            float timer = 0f;
            while (timer < transInDuration)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            canUpdate = true;

            OnTransIn_End();
        }

        IEnumerator E_StateTransOut()
        {
            hasTransOutStart = true;

            OnTransOut_Start();

            float timer = 0f;
            while (timer < transOutDuration)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            OnTransOut_End();
        }

        #endregion PRIVATE_FUNCTIONS

        #region EVENTS

        void OnTransIn_Start()
        {
            for (int i = 0; i < stateBehaviors.Count; i++)
            {
                stateBehaviors[i].OnTransIn_Start();
            }

            transitionInStartEvent.Invoke();
        }

        void OnTransIn_End()
        {
            for (int i = 0; i < stateBehaviors.Count; i++)
            {
                stateBehaviors[i].OnTransIn_End();
            }

            transitionInEndEvent.Invoke();
        }

        void OnTransOut_Start()
        {
            for (int i = 0; i < stateBehaviors.Count; i++)
            {
                stateBehaviors[i].OnTransOut_Start();
            }

            transitionOutStartEvent.Invoke();
        }

        void OnTransOut_End()
        {
            for (int i = 0; i < stateBehaviors.Count; i++)
            {
                stateBehaviors[i].OnTransOut_End();
            }

            transitionOutEndEvent.Invoke();

            StateReset();
        }

        #endregion EVENTS

    }
}