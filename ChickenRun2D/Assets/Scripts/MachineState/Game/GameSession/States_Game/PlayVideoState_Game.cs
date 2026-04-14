using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideoState_Game : IState
{
    private readonly IStateMachineProvider _stateMachineProvider;
    private readonly UIGameRoot _sceneRoot;
    private readonly IVideoProvider _videoProvider;

    public PlayVideoState_Game(IStateMachineProvider stateMachineProvider, UIGameRoot sceneRoot, IVideoProvider videoProvider)
    {
        _stateMachineProvider = stateMachineProvider;
        _sceneRoot = sceneRoot;
        _videoProvider = videoProvider;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToPlay_PLAY += ChangeStateToSpawnChickens;

        _videoProvider.Play("Play");
        _sceneRoot.OpenPlayVideoPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToPlay_PLAY -= ChangeStateToSpawnChickens;

        _sceneRoot.ClosePlayVideoPanel();
    }

    private void ChangeStateToSpawnChickens()
    {
        _stateMachineProvider.EnterState(_stateMachineProvider.GetState<ChickenSpawnState_Game>());
    }
}
