using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly IChickenBattleProvider _chickenBattleProvider;
    private readonly IChickenBattleListener _chickenBattleListener;
    private readonly UIGameRoot _sceneRoot;

    private readonly ITimerProvider _timerProvider;
    private readonly IChickenRaceLeaderProvider _chickenRaceLeaderProvider;
    private readonly ICameraFollowProvider _cameraFollowProvider;
    private readonly IChooseChickenProvider _chooseChickenProvider;

    private IEnumerator timer;

    public GameRunState_Game(IStateMachineProvider stateMachineProvider, IChickenBattleProvider chickenBattleProvider, IChickenBattleListener chickenBattleListener, UIGameRoot sceneRoot, ITimerProvider timerProvider, IChickenRaceLeaderProvider chickenRaceLeaderProvider, ICameraFollowProvider cameraFollowProvider, IChooseChickenProvider chooseChickenProvider)
    {
        _stateMachineProvider = stateMachineProvider;
        _chickenBattleProvider = chickenBattleProvider;
        _chickenBattleListener = chickenBattleListener;
        _sceneRoot = sceneRoot;
        _timerProvider = timerProvider;
        _chickenRaceLeaderProvider = chickenRaceLeaderProvider;
        _cameraFollowProvider = cameraFollowProvider;
        _chooseChickenProvider = chooseChickenProvider;
    }

    public void EnterState()
    {
        if(timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);

        _chickenBattleListener.OnEndGame += ChangeStateToCheckWinnerState;
        _sceneRoot.OnClickToMenu_MAINHEADER += ChangeStateToMenu;

        _chickenBattleProvider.StartGame();
        _sceneRoot.OpenMainHeaderPanel();
        _timerProvider.ActivateTimer(3600, TimerDirection.Forward);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);

        _chickenBattleListener.OnEndGame -= ChangeStateToCheckWinnerState;
        _sceneRoot.OnClickToMenu_MAINHEADER -= ChangeStateToMenu;

        _sceneRoot.CloseMainHeaderPanel();
        _timerProvider.DeactivateTimer();
        _chickenRaceLeaderProvider.Deactivate();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);

        _chickenRaceLeaderProvider.Activate();
    }

    private void ChangeStateToCheckWinnerState()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<CheckWinnerState_Game>());
    }

    private void ChangeStateToMenu()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<PlayVideoState_Game>());

        _cameraFollowProvider.Clear();
        _chickenBattleProvider.StopBattle();
        _chooseChickenProvider.HideAll();
        _sceneRoot.CLoseMainPanel();
    }
}
