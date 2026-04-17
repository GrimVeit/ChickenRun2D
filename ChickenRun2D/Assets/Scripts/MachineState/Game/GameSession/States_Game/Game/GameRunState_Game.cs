using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly IChickenBattleProvider _chickenBattleProvider;
    private readonly IChickenBattleListener _chickenBattleListener;
    private readonly UIGameRoot _sceneRoot;

    private readonly ITimerProvider _timerProvider;

    public GameRunState_Game(IStateMachineProvider stateMachineProvider, IChickenBattleProvider chickenBattleProvider, IChickenBattleListener chickenBattleListener, UIGameRoot sceneRoot, ITimerProvider timerProvider)
    {
        _stateMachineProvider = stateMachineProvider;
        _chickenBattleProvider = chickenBattleProvider;
        _chickenBattleListener = chickenBattleListener;
        _sceneRoot = sceneRoot;
        _timerProvider = timerProvider;
    }

    public void EnterState()
    {
        _chickenBattleListener.OnEndGame += ChangeStateToCheckWinnerState;

        _chickenBattleProvider.StartGame();
        _sceneRoot.OpenMainHeaderPanel();
        _timerProvider.ActivateTimer(3600, TimerDirection.Forward);
    }

    public void ExitState()
    {
        _chickenBattleListener.OnEndGame -= ChangeStateToCheckWinnerState;

        _sceneRoot.CloseMainHeaderPanel();
        _timerProvider.DeactivateTimer();
    }

    private void ChangeStateToCheckWinnerState()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<CheckWinnerState_Game>());
    }
}
