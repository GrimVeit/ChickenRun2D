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
        UIGameRoot sceneRoot,
        IChickenBattleProvider chickenBattleProvider,
        IChickenBattleListener chickenBattleListener,
        IChooseBuyBoxProvider chooseBuyBoxProvider,
        IVideoProvider videoProvider,
        IMaskEffectProvider maskEffectProvider,
        ISlotMachineListener slotMachineListener,
        ISlotMachineProvider slotMachineProvider
    )
    {
        states[typeof(IntroVideoState_Game)] = new IntroVideoState_Game(this, sceneRoot, videoProvider, maskEffectProvider);
        states[typeof(PlayVideoState_Game)] = new PlayVideoState_Game(this, sceneRoot, videoProvider, maskEffectProvider);
        states[typeof(ChooseLocationState_Game)] = new ChooseLocationState_Game(this, sceneRoot, maskEffectProvider, slotMachineListener, slotMachineProvider);

        states[typeof(ChickenSpawnState_Game)] = new ChickenSpawnState_Game(this, spawnerChickenProvider, chooseChickenProvider, storeChickenProvider, sceneRoot);
        states[typeof(ChooseChickenState_Game)] = new ChooseChickenState_Game(this, chooseChickenProvider, sceneRoot);
        states[typeof(GameRunState_Game)] = new GameRunState_Game(this, chickenBattleProvider, chickenBattleListener);
        states[typeof(CheckWinnerState_Game)] = new CheckWinnerState_Game(this, chickenBattleListener, chickenBattleProvider, chooseChickenProvider);

        states[typeof(LoseState_Game)] = new LoseState_Game(this, sceneRoot);
        states[typeof(WinState_Game)] = new WinState_Game(this, sceneRoot);

        states[typeof(ChooseBuyBoxState_Game)] = new ChooseBuyBoxState_Game(this, chooseBuyBoxProvider, sceneRoot);
    }

    public void Initialize()
    {
        EnterState(GetState<IntroVideoState_Game>());
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
