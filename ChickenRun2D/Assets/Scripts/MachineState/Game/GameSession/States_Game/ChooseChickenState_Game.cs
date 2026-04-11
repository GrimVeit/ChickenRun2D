using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChickenState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly IChooseChickenProvider _chooseChickenProvider;
    private readonly UIGameRoot _sceneRoot;

    public ChooseChickenState_Game(IStateMachineProvider machineProvider, IChooseChickenProvider chooseChickenProvider, UIGameRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _chooseChickenProvider = chooseChickenProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToChoose_CHOOSE += ChangeStateToGame;

        _sceneRoot.OpenChoosePanel();
        _chooseChickenProvider.ActivateAll();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToChoose_CHOOSE -= ChangeStateToGame;

        _sceneRoot.CloseChoosePanel();
        _chooseChickenProvider.DeactivateAll();
    }

    private void ChangeStateToGame()
    {
        _machineProvider.EnterState(_machineProvider.GetState<GameRunState_Game>());
    }
}
