using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLocationState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly UIGameRoot _sceneRoot;

    public ChooseLocationState_Game(IStateMachineProvider machineProvider, UIGameRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OpenChooseLocationPanel();
    }

    public void ExitState()
    {
        _sceneRoot.CloseChooseLocationPanel();
    }
}
