using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.StateTool
{
    public class GameStateController
    {
        public GameState State { get { return state; } }
        private GameState state;

        public void SetState(GameState _newState)
        {
            Debug.Log("SetState: " + _newState.ToString());

            // Ask the last gameState to end
            if (state != null)
            {
                state.StateTransOut();
                Debug.Log(state.ToString() + " State Trans Out");
            }

            state = _newState;
        }

        public void StateUpdate()
        {

            // Ask the new gameState to begin
            if (state != null && !state.hasTransInOrDelayStart)
            {
                state.StateTransIn();
                Debug.Log(state.ToString() + " State Trans In");
            }

            if (state != null && state.canUpdate)
            {
                state.StateUpdate();
            }
        }
    }
}
