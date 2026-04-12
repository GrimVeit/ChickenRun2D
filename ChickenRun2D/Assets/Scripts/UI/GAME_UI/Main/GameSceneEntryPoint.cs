using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private Sounds sounds;
    [SerializeField] private UIGameRoot menuRootPrefab;

    private UIGameRoot sceneRoot;
    private ViewContainer viewContainer;

    private BankPresenter bankPresenter;

    private ParticleEffectPresenter particleEffectPresenter;
    private SoundPresenter soundPresenter;

    private StoreChickenPresenter storeChickenPresenter;
    private ChooseChickenPresenter chooseChickenPresenter;
    private SpawnerChickenPresenter spawnerChickenPresenter;
    private ChickenBattlePresenter chickenBattlePresenter;
    private CameraFollowPresenter cameraFollowPresenter;

    private StateMachine_Game stateMachine;

    public void Run(UIRootView uIRootView)
    {
        sceneRoot = menuRootPrefab;

        uIRootView.AttachSceneUI(sceneRoot.gameObject, Camera.main);

        viewContainer = sceneRoot.GetComponent<ViewContainer>();
        viewContainer.Initialize();

        soundPresenter = new SoundPresenter
                    (new SoundModel(sounds.sounds, PlayerPrefsKeys.IS_MUTE_SOUNDS, PlayerPrefsKeys.KEY_VOLUME_SOUND, PlayerPrefsKeys.KEY_VOLUME_MUSIC),
                    viewContainer.GetView<SoundView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        
        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        storeChickenPresenter = new StoreChickenPresenter(new StoreChickenModel());
        chooseChickenPresenter = new ChooseChickenPresenter(new ChooseChickenModel(storeChickenPresenter), viewContainer.GetView<ChooseChickenView>());
        spawnerChickenPresenter = new SpawnerChickenPresenter(new SpawnerChickenModel(storeChickenPresenter), viewContainer.GetView<SpawnerChickenView>()); ;
        chickenBattlePresenter = new ChickenBattlePresenter(new ChickenBattleModel(spawnerChickenPresenter, chooseChickenPresenter));
        cameraFollowPresenter = new CameraFollowPresenter(new CameraFollowModel(spawnerChickenPresenter), viewContainer.GetView<CameraFollowView>());

        stateMachine = new StateMachine_Game(storeChickenPresenter, spawnerChickenPresenter, chooseChickenPresenter, sceneRoot, chickenBattlePresenter, chickenBattlePresenter);

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        soundPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();
        
        chooseChickenPresenter.Initialize();
        chickenBattlePresenter.Initialize();
        cameraFollowPresenter.Initialize();
        spawnerChickenPresenter.Initialize();

        stateMachine.Initialize();
    }

    private void ActivateEvents()
    {
        ActivateTransitions();
    }

    private void DeactivateEvents()
    {
        DeactivateTransitions();
    }

    private void ActivateTransitions()
    {

    }

    private void DeactivateTransitions()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            storeChickenPresenter.ChooseChickens();
            chooseChickenPresenter.ShowAll();
        }
    }

    private void Deactivate()
    {
        sceneRoot.Deactivate();
        soundPresenter?.Dispose();
    }

    private void Dispose()
    {
        DeactivateEvents();

        chooseChickenPresenter?.Dispose();
        chickenBattlePresenter?.Dispose();
        cameraFollowPresenter?.Dispose();
        spawnerChickenPresenter?.Dispose();

        stateMachine?.Dispose();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    private void OnApplicationQuit()
    {
        Dispose();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            
        }
    }

    void OnApplicationFocus(bool focusStatus)
    {
        if (!focusStatus)
        {
            
        }
    }

    #region Output


    public event Action OnClickToMenu;
    public event Action OnClickToGame;

    private void HandleClickToMenu()
    {
        Deactivate();

        OnClickToMenu?.Invoke();
    }

    private void HandleClickToGame()
    {
        Deactivate();

        OnClickToGame?.Invoke();
    }

    #endregion
}
