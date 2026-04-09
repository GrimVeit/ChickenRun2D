using System;
using System.Collections.Generic;

public class ChickenStateMachine : IStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private readonly List<IState> _goodStates = new();
    private readonly List<IState> _badStates = new();
    private readonly IState _stateIdle;
    private readonly IState _stateRun;

    private IState _currentState;

    private readonly ChickenUnitModel _model;

    public ChickenStateMachine(ChickenUnitModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        var stateIdle = new ChickenState_Idle(_model);
        states[typeof(ChickenState_Idle)] = stateIdle;

        var stateRun = new ChickenState_Run(_model);
        states[typeof(ChickenState_Run)] = stateRun;

    }

    public void Dispose()
    {
        _currentState?.ExitState();
    }

    public IState GetState<T>() where T : IState
    {
        return states[typeof(T)];
    }

    public void EnterState(IState state)
    {
        _currentState?.ExitState();

        _currentState = state;
        _currentState.EnterState();
    }

    #region Input

    public void ActivateGoodState()
    {
        EnterState(_goodStates[UnityEngine.Random.Range(0, _goodStates.Count)]);
    }

    public void ActivateBadState()
    {
        EnterState(_goodStates[UnityEngine.Random.Range(0, _badStates.Count)]);
    }

    public void SetRun()
    {
        EnterState(_stateRun);
    }

    public void SetIdle()
    {
        EnterState(_stateIdle);
    }

    #endregion
}
