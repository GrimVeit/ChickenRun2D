using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenState_Run : IState
{
    private readonly ChickenUnitModel _model;

    public ChickenState_Run(ChickenUnitModel model)
    {
        _model = model;
    }

    public void EnterState()
    {
        _model.SetSpeed(30, 0.1f);
        _model.ActivateAnimation(ChickenAnimationType.Run);
    }

    public void ExitState()
    {

    }
}
