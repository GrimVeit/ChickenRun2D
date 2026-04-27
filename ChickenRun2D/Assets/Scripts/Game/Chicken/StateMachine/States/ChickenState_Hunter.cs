using System.Collections;
using UnityEngine;

public class ChickenState_Hunter : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly ChickenUnitModel _model;

    private IEnumerator timer;

    public ChickenState_Hunter(IStateMachineProvider stateMachineProvider, ChickenUnitModel model)
    {
        _machineProvider = stateMachineProvider;
        _model = model;
    }

    public void EnterState()
    {
        Debug.Log("HUNTER");

        if (timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    private IEnumerator Timer()
    {
        _model.EventGame_Hunter_Activate();

        yield return new WaitForSeconds(0.1f);

        _model.SetSpeed(0, 0.2f);
        _model.ActivateAnimation(ChickenAnimationType.Fright);

        yield return new WaitForSeconds(2);

        ChangeStateToRun();
    }

    public void ExitState()
    {
        _model.EventGame_Hunter_Clear();

        if (timer != null) Coroutines.Stop(timer);
    }

    private void ChangeStateToRun()
    {
        _machineProvider.EnterState(_machineProvider.GetState<ChickenState_Run>());
    }
}
