using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_Game : IStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private IState _currentState;

    public StateMachine_Game
    (
        IStoreChickenProvider storeChickenProvider,
        ISpawnerChickenProvider spawnerChickenProvider,
        IChooseChickenProvider chooseChickenProvider,
        UIGameRoot _sceneRoot,
        IChickenBattleProvider chickenBattleProvider,
        IChickenBattleListener chickenBattleListener,
        IChooseBuyBoxProvider chooseBuyBoxProvider
        
    )
    {
        states[typeof(ChickenSpawnState_Game)] = new ChickenSpawnState_Game(this, spawnerChickenProvider, chooseChickenProvider, storeChickenProvider);
        states[typeof(ChooseChickenState_Game)] = new ChooseChickenState_Game(this, chooseChickenProvider, _sceneRoot);
        states[typeof(GameRunState_Game)] = new GameRunState_Game(this, chickenBattleProvider, chickenBattleListener);
        states[typeof(CheckWinnerState_Game)] = new CheckWinnerState_Game(this, chickenBattleListener, chickenBattleProvider, chooseChickenProvider);

        states[typeof(LoseState_Game)] = new LoseState_Game(this, _sceneRoot);
        states[typeof(WinState_Game)] = new WinState_Game(this, _sceneRoot);

        states[typeof(ChooseBuyBoxState_Game)] = new ChooseBuyBoxState_Game(this, chooseBuyBoxProvider, _sceneRoot);
    }

    public void Initialize()
    {
        EnterState(GetState<ChickenSpawnState_Game>());
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
}
