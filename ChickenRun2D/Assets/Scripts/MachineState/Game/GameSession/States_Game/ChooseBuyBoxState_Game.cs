using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBuyBoxState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly IChooseBuyBoxProvider _chooseBuyBoxProvider;
    private readonly UIGameRoot _sceneRoot;

    public ChooseBuyBoxState_Game(IStateMachineProvider machineProvider, IChooseBuyBoxProvider chooseBuyBoxProvider, UIGameRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _chooseBuyBoxProvider = chooseBuyBoxProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToBox_COSTBOX += ChangeStateToBuy;

        _sceneRoot.OpenBackgroundBrownPanel();
        _sceneRoot.OpenCostBoxPanel();
        _chooseBuyBoxProvider.ShowAll();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToBox_COSTBOX -= ChangeStateToBuy;

        _sceneRoot.CloseCostBoxPanel();
        _chooseBuyBoxProvider.HideAll();
    }

    private void ChangeStateToBuy()
    {
        _machineProvider.EnterState(_machineProvider.GetState<CardsState_Game>());
    }
}
