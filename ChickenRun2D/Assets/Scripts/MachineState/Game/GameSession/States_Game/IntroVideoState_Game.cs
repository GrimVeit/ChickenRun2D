using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroVideoState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly UIGameRoot _sceneRoot;
    private readonly IVideoProvider _videoProvider;

    private IEnumerator timer;

    public IntroVideoState_Game(IStateMachineProvider stateMachineProvider, UIGameRoot sceneRoot, IVideoProvider videoProvider)
    {
        _stateMachineProvider = stateMachineProvider;
        _sceneRoot = sceneRoot;
        _videoProvider = videoProvider;
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

        _sceneRoot.CloseIntroVideoPanel();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.3f);

        _videoProvider.Play("Intro");
        _sceneRoot.OpenIntroVideoPanel();

        yield return new WaitForSeconds(3f);

        ChangeStateToPlayVideo();
    }

    private void ChangeStateToPlayVideo()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<PlayVideoState_Game>());
    }
}
