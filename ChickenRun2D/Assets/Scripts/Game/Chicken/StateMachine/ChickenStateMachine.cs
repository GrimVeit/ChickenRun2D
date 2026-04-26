using System;
using System.Collections.Generic;

public class ChickenStateMachine : IStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private readonly List<IState> _goodStates = new();
    private readonly List<IState> _badStates = new();
    private IState _stateIdle;
    private IState _stateRun;

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
        _stateIdle = stateIdle;

        var stateRun = new ChickenState_Run(_model);
        states[typeof(ChickenState_Run)] = stateRun;
        _stateRun = stateRun;

        var stateNitro = new ChickenState_Nitro(this, _model);
        states[typeof(ChickenState_Nitro)] = stateNitro;
        _goodStates.Add(stateNitro);

        var stateFall = new ChickenState_Fall(this, _model);
        states[typeof(ChickenState_Fall)] = stateFall;
        //_badStates.Add(stateFall);

        var stateAuto = new ChickenState_Auto(this, _model);
        states[typeof(ChickenState_Auto)] = stateAuto;
        //_badStates.Add(stateAuto);

        var stateUFO = new ChickenState_UFO(this, _model);
        states[typeof(ChickenState_UFO)] = stateUFO;
        //_badStates.Add(stateUFO);

        var statePhone = new ChickenState_Phone(this, _model);
        states[typeof(ChickenState_Phone)] = statePhone;
        //_badStates.Add(statePhone);

        var stateTornado = new ChickenState_Tornado(this, _model);
        states[typeof(ChickenState_Tornado)] = stateTornado;
        _badStates.Add(stateTornado);
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
        EnterState(_badStates[UnityEngine.Random.Range(0, _badStates.Count)]);
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
