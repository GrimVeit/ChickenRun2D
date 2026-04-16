using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly UIGameRoot _sceneRoot;

    public CardsState_Game(IStateMachineProvider machineProvider, UIGameRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToExit_CARDSHEADER += ChangeStateToRestart;

        _sceneRoot.OpenCardsHeaderPanel();
        _sceneRoot.OpenCardsPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToExit_CARDSHEADER -= ChangeStateToRestart;

        _sceneRoot.CloseCardsPanel();
    }

    private void ChangeStateToRestart()
    {
        _machineProvider.EnterState(_machineProvider.GetState<ChickenSpawnState_Game>());

        _sceneRoot.CloseCardsHeaderPanel();
        _sceneRoot.CloseBackgroundBrownPanel();
    }

    private void ChangeStateToCardsType()
    {

    }
}
