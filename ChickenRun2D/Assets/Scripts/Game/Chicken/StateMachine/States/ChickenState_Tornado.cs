using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenState_Tornado : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly ChickenUnitModel _model;

    private IEnumerator timer;

    public ChickenState_Tornado(IStateMachineProvider stateMachineProvider, ChickenUnitModel model)
    {
        _machineProvider = stateMachineProvider;
        _model = model;
    }

    public void EnterState()
    {
        Debug.Log("TORNADO");

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    private IEnumerator Timer()
    {
        _model.EventGame_Tornado_Activate();

        _model.SetSpeed(0, 0.2f);
        _model.ActivateAnimation(ChickenAnimationType.Tornado);

        yield return new WaitForSeconds(1.5f);

        ChangeStateToRun();
    }

    public void ExitState()
    {
        _model.EventGame_Tornado_Clear();

        if (timer != null) Coroutines.Stop(timer);
    }

    private void ChangeStateToRun()
    {
        _machineProvider.EnterState(_machineProvider.GetState<ChickenState_Run>());
    }
}
