using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenState_Fall : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly ChickenUnitModel _model;

    private IEnumerator timer;

    public ChickenState_Fall(IStateMachineProvider stateMachineProvider, ChickenUnitModel model)
    {
        _machineProvider = stateMachineProvider;
        _model = model;
    }

    public void EnterState()
    {
        Debug.Log("FALL");

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    private IEnumerator Timer()
    {
        _model.SetSpeed(0, 0.2f);
        _model.ActivateAnimation(ChickenAnimationType.Fall_StandUp);

        yield return new WaitForSeconds(2.4f);

        ChangeStateToRun();
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private void ChangeStateToRun()
    {
        _machineProvider.EnterState(_machineProvider.GetState<ChickenState_Run>());
    }
}
