using System.Collections;
using UnityEngine;

public class StartLoseState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly IVideoProvider _videoProvider;
    private readonly UIGameRoot _sceneRoot;

    private IEnumerator timer;

    public StartLoseState_Game(IStateMachineProvider machineProvider, IVideoProvider videoProvider, UIGameRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _videoProvider = videoProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        if(timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer()
    {
        _videoProvider.Play("Lose");
        _sceneRoot.OpenLoseVideoPanel();

        yield return new WaitForSeconds(3);

        ChangeStateToLose();
    }

    private void ChangeStateToLose()
    {
        _machineProvider.EnterState(_machineProvider.GetState<LoseState_Game>());
    }
}
