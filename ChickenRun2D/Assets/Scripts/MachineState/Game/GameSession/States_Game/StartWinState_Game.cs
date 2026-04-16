using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWinState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly IVideoProvider _videoProvider;
    private readonly UIGameRoot _sceneRoot;

    private IEnumerator timer;

    public StartWinState_Game(IStateMachineProvider machineProvider, IVideoProvider videoProvider, UIGameRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _videoProvider = videoProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        if (timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer()
    {
        _videoProvider.Play("Win");
        _sceneRoot.OpenWinVideoPanel();

        yield return new WaitForSeconds(2);

        ChangeStateToWin();
    }

    private void ChangeStateToWin()
    {
        _machineProvider.EnterState(_machineProvider.GetState<WinState_Game>());
    }
}
