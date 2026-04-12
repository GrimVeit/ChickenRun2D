using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly IChickenBattleProvider _chickenBattleProvider;
    private readonly IChickenBattleListener _chickenBattleListener;

    public GameRunState_Game(IStateMachineProvider stateMachineProvider, IChickenBattleProvider chickenBattleProvider, IChickenBattleListener chickenBattleListener)
    {
        _stateMachineProvider = stateMachineProvider;
        _chickenBattleProvider = chickenBattleProvider;
        _chickenBattleListener = chickenBattleListener;
    }

    public void EnterState()
    {
        _chickenBattleListener.OnEndGame += ChangeStateToCheckWinnerState;

        _chickenBattleProvider.StartGame();
    }

    public void ExitState()
    {
        _chickenBattleListener.OnEndGame -= ChangeStateToCheckWinnerState;
    }

    private void ChangeStateToCheckWinnerState()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<CheckWinnerState_Game>());
    }
}
