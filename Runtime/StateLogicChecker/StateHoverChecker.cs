using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.StateTool
{
    public class StateHoverChecker : StateLogicChecker, IStateBehavior
    {
        public float timeToHover = 3f;
        float timer = 0f;

        Ray ray;
        RaycastHit hit;

        public Camera camera; // camera to cast ray
        public GameObject targetToHover;

        public bool CanStopUpdate()
        {
            return canStopUpdate;
        }

        public void OnStateInit()
        {
            Collider collider = targetToHover.GetComponent<Collider>();
            Collider2D collider2D = targetToHover.GetComponent<Collider2D>();

            if (collider)
            {
                if (collider.enabled == false) collider.enabled = true;
            }

            if (collider2D)
            {
                if (collider2D.enabled == false) collider2D.enabled = true;
            }

            if (!collider && !collider2D)
            {
                Debug.LogWarning("There is no collider or collider2D on the object to hover! Please add one.");
            }
        }

        public void OnTransIn_Start()
        {

        }

        public void OnTransIn_End()
        {

        }

        public void StateUpdate()
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);

            // If we hit something
            if (Physics.Raycast(ray, out hit))
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
            }

            Debug.Log(timer);
            if (timer >= timeToHover)
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