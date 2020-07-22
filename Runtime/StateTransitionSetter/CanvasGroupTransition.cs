using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.StateTool
{
    public class CanvasGroupTransition : StateTransitionSetter, IStateBehavior
    {

        public CanvasGroup cg;

        void Awake()
        {

        }

        public bool CanStopUpdate()
        {
            return false;
        }

        public void OnStateInit()
        {
            cg.interactable = false;
            cg.blocksRaycasts = false;
            cg.alpha = 0f;

            cg.gameObject.SetActive(false);
        }

        public void OnTransIn_Start()
        {
            cg.gameObject.SetActive(true);

            StartCoroutine(E_Fade(1f, transInDuration));
        }

        public void OnTransIn_End()
        {
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }

        public void StateUpdate()
        {

        }

        public void OnTransOut_Start()
        {
            cg.interactable = false;
            cg.blocksRaycasts = false;
            StartCoroutine(E_Fade(0f, transOutDuration));
        }

        public void OnTransOut_End()
        {
            cg.gameObject.SetActive(false);
        }

        public void OnStateReset()
        {

        }

        IEnumerator E_Fade(float _targetAlpha, float _duration)
        {
            // TODO handle interruption of coroutine
            float currentAlpha = cg.alpha;
            float timer = 0f;
            while(timer < 1f)
            {
                timer += Time.deltaTime * 1f / _duration;

                if (1f - timer <= 0.05f) timer = 1f; // To avoid timer becomes an awkward number which is very close to 0 or 1

                float alpha = Mathf.Lerp(currentAlpha, _targetAlpha, timer);
                cg.alpha = alpha; // update alpha of canvas group

                yield return null;
            }
        }
    }
}