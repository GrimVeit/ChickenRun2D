using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitGameRunState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly ITimerProvider _timerProvider;
    private readonly ITimerListener _timerListener;

    public WaitGameRunState_Game(IStateMachineProvider machineProvider, ITimerProvider timerProvider_Start, ITimerListener timerListener_Start)
    {
        _machineProvider = machineProvider;
        _timerProvider = timerProvider_Start;
        _timerListener = timerListener_Start;
    }

    public void EnterState()
    {
        _timerListener.OnStopTimer += ChangeStateToGameRun;

        _timerProvider.ActivateTimer(3, TimerDirection.Backward);
    }

    public void ExitState()
    {
        _timerListener.OnStopTimer -= ChangeStateToGameRun;
    }

    private void ChangeStateToGameRun()
    {
        _machineProvider.EnterState(_machineProvider.GetState<GameRunState_Game>());

        _timerProvider.DeactivateTimer();
    }
}
