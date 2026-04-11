using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly IChickenBattleProvider _chickenBattleProvider;

    public GameRunState_Game(IStateMachineProvider stateMachineProvider, IChickenBattleProvider chickenBattleProvider)
    {
        _stateMachineProvider = stateMachineProvider;
        _chickenBattleProvider = chickenBattleProvider;
    }

    public void EnterState()
    {
        _chickenBattleProvider.StartGame();
    }

    public void ExitState()
    {

    }
}
