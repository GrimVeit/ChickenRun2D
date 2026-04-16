using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly UIGameRoot _sceneRoot;

    public LoseState_Game(IStateMachineProvider stateMachineProvider, UIGameRoot sceneRoot)
    {
        _stateMachineProvider = stateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToRestart_LOSE += ChangeStateToRestart;

        _sceneRoot.OpenLosePanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToRestart_LOSE -= ChangeStateToRestart;

        _sceneRoot.CloseLosePanel();
        _sceneRoot.CloseLoseVideoPanel();
    }

    public void ChangeStateToRestart()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<ChickenSpawnState_Game>());
    }
}
