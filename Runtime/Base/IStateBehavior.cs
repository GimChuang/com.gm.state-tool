namespace GM.StateTool
{
    public interface IStateBehavior
    {
        void OnStateInit();
        void OnTransIn_Start();
        void OnTransIn_End();
        void StateUpdate();
        void OnTransOut_Start();
        void OnTransOut_End();
        void OnStateReset();

        bool CanStopUpdate(); // can stop updating and trans out
    }
}
