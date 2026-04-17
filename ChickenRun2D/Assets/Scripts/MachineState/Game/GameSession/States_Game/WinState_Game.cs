using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly UIGameRoot _sceneRoot;

    public WinState_Game(IStateMachineProvider stateMachineProvider, UIGameRoot sceneRoot)
    {
        _stateMachineProvider = stateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToBuy_WIN += ChangeStateToChooseBuyBox;
        _sceneRoot.OnClickToRestart_WIN += ChangeStateToRestart;

        _sceneRoot.OpenWinPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToBuy_WIN -= ChangeStateToChooseBuyBox;
        _sceneRoot.OnClickToRestart_WIN -= ChangeStateToRestart;

        _sceneRoot.CloseWinPanel();
        _sceneRoot.CloseWinVideoPanel();
    }

    private void ChangeStateToRestart()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<ChooseLocationState_Game>());
    }

    private void ChangeStateToChooseBuyBox()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<ChooseBuyBoxState_Game>());
    }
}
