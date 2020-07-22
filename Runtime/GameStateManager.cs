using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.StateTool
{
    public class GameStateManager : MonoBehaviour
    {
        #region GAMESTATES
        public GameState[] states;
        GameStateController gameStateController = new GameStateController();
        int crntIndex = 0;
        #endregion GAMESTATES

        #region SINGLETON
        public static GameStateManager Instance { get; private set; }
        #endregion SINGLETON

        // Start is called before the first frame update
        void Awake()
        {
            #region SINGLETON
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            #endregion SINGLETON

            #region GAMESTATES
            for (int i = 0; i < states.Length; i++)
            {
                states[i].StateInit();
            }
            #endregion GAMESTATES
        }

        void Start()
        {
            // Start with the first GameState
            GoToState(0);
        }

        // Update is called once per frame
        void Update()
        {
            // Update GameStates!
            gameStateController.StateUpdate();
        }

        #region GAMESTATES
        // TODO Add GoToState(string _stateName)
        public void GoToState(int _index)
        {
            crntIndex = _index;
            gameStateController.SetState(states[crntIndex]);
        }
        public void GoToNextState()
        {
            crntIndex = crntIndex + 1;
            if (crntIndex >= states.Length) crntIndex = 0;
            gameStateController.SetState(states[crntIndex]);
        }
        #endregion GAMESTATES
    }
}