using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsTypeState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly UIGameRoot _sceneRoot;

    public CardsTypeState_Game(IStateMachineProvider stateMachineProvider, UIGameRoot sceneRoot)
    {
        _stateMachineProvider = stateMachineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToExit_CARDSHEADER += ChangeStateToCards;

        _sceneRoot.OpenCardsTypePanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToExit_CARDSHEADER -= ChangeStateToCards;

        _sceneRoot.CloseCardsTypePanel();
    }

    private void ChangeStateToCards()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<CardsState_Game>());
    }
}
