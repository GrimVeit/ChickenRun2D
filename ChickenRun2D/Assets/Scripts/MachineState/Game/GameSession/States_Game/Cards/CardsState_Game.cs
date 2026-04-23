using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly UIGameRoot _sceneRoot;
    private readonly IVisualChickenPictureListener _visualChickenPictureListener;

    public CardsState_Game(IStateMachineProvider machineProvider, UIGameRoot sceneRoot, IVisualChickenPictureListener visualChickenPictureListener)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
        _visualChickenPictureListener = visualChickenPictureListener;
    }

    public void EnterState()
    {
        _visualChickenPictureListener.OnSelectType += ChangeStateToCardsType;
        _sceneRoot.OnClickToExit_CARDSHEADER += ChangeStateToChooseBuyBox;

        _sceneRoot.OpenPiecesPanel();
        _sceneRoot.OpenCardsHeaderPanel();
        _sceneRoot.OpenCardsPanel();
    }

    public void ExitState()
    {
        _visualChickenPictureListener.OnSelectType -= ChangeStateToCardsType;
        _sceneRoot.OnClickToExit_CARDSHEADER -= ChangeStateToChooseBuyBox;

        _sceneRoot.ClosePiecesPanel();
        _sceneRoot.CloseCardsPanel();
    }

    private void ChangeStateToChooseBuyBox()
    {
        _machineProvider.EnterState(_machineProvider.GetState<ChooseBuyBoxState_Game>());

        _sceneRoot.CloseCardsHeaderPanel();
    }

    private void ChangeStateToCardsType()
    {
        _machineProvider.EnterState(_machineProvider.GetState<CardsTypeState_Game>());
    }
}
