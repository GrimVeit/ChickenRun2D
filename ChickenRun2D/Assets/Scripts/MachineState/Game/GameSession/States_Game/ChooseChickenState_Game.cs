using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChickenState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly IChooseChickenProvider _chooseChickenProvider;
    private readonly UIGameRoot _sceneRoot;
    private readonly IVisualChickenEffectProvider _visualChickenEffectProvider;

    public ChooseChickenState_Game(IStateMachineProvider machineProvider, IChooseChickenProvider chooseChickenProvider, UIGameRoot sceneRoot, IVisualChickenEffectProvider visualChickenEffectProvider)
    {
        _machineProvider = machineProvider;
        _chooseChickenProvider = chooseChickenProvider;
        _sceneRoot = sceneRoot;
        _visualChickenEffectProvider = visualChickenEffectProvider;
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
        _visualChickenEffectProvider.DeactivateVisual();
    }

    private void ChangeStateToGame()
    {
        _machineProvider.EnterState(_machineProvider.GetState<GameRunState_Game>());
    }
}
