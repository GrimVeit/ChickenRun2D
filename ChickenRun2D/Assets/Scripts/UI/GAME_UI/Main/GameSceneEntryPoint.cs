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
    private VideoPresenter videoPresenter;

    private StoreChickenPresenter storeChickenPresenter;
    private ChooseChickenPresenter chooseChickenPresenter;
    private SpawnerChickenPresenter spawnerChickenPresenter;
    private ChickenBattlePresenter chickenBattlePresenter;
    private CameraFollowPresenter cameraFollowPresenter;
    private SlotMachinePresenter slotMachinePresenter;
    private VisualChickenEffectPresenter visualChickenEffectPresenter;

    private MaskEffectPresenter maskEffectPresenter;

    private ChooseBuyBoxPresenter chooseBuyBoxPresenter;
    private RaceDesignPresenter raceDesignPresenter;

    private TimerPresenter timerPresenter_Start;
    private TimerPresenter timerPresenter_Game;

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

        videoPresenter = new VideoPresenter(new VideoModel(), viewContainer.GetView<VideoView>());

        bankPresenter = new BankPresenter(new BankModel(), viewContainer.GetView<BankView>());
        
        particleEffectPresenter = new ParticleEffectPresenter
            (new ParticleEffectModel(),
            viewContainer.GetView<ParticleEffectView>());

        storeChickenPresenter = new StoreChickenPresenter(new StoreChickenModel());
        chooseChickenPresenter = new ChooseChickenPresenter(new ChooseChickenModel(storeChickenPresenter), viewContainer.GetView<ChooseChickenView>());
        spawnerChickenPresenter = new SpawnerChickenPresenter(new SpawnerChickenModel(storeChickenPresenter), viewContainer.GetView<SpawnerChickenView>()); ;
        chickenBattlePresenter = new ChickenBattlePresenter(new ChickenBattleModel(spawnerChickenPresenter, chooseChickenPresenter));
        cameraFollowPresenter = new CameraFollowPresenter(new CameraFollowModel(spawnerChickenPresenter), viewContainer.GetView<CameraFollowView>());
        visualChickenEffectPresenter = new VisualChickenEffectPresenter(new VisualChickenEffectModel(chooseChickenPresenter, storeChickenPresenter), viewContainer.GetView<VisualChickenEffectView>());

        slotMachinePresenter = new SlotMachinePresenter(new SlotMachineModel(), viewContainer.GetView<SlotMachineView>());

        maskEffectPresenter = new MaskEffectPresenter(new MaskEffectModel(), viewContainer.GetView<MaskEffectView>());

        chooseBuyBoxPresenter = new ChooseBuyBoxPresenter(new ChooseBuyBoxModel(), viewContainer.GetView<ChooseBuyBoxView>());
        raceDesignPresenter = new RaceDesignPresenter(new RaceDesignModel(slotMachinePresenter), viewContainer.GetView<RaceDesignView>());

        timerPresenter_Start = new TimerPresenter(new TimerModel(), viewContainer.GetView<TimerView_Mapped>("Start"));
        timerPresenter_Game = new TimerPresenter(new TimerModel(), viewContainer.GetView<TimerView_Formatted>("Game"));

        stateMachine = new StateMachine_Game(
            storeChickenPresenter, 
            spawnerChickenPresenter, 
            chooseChickenPresenter, 
            sceneRoot, 
            chickenBattlePresenter, 
            chickenBattlePresenter, 
            chooseBuyBoxPresenter, 
            videoPresenter, 
            maskEffectPresenter, 
            slotMachinePresenter, 
            slotMachinePresenter,
            visualChickenEffectPresenter,
            timerPresenter_Start,
            timerPresenter_Start,
            timerPresenter_Game);

        sceneRoot.SetSoundProvider(soundPresenter);
        sceneRoot.Activate();

        ActivateEvents();

        soundPresenter.Initialize();
        videoPresenter.Initialize();
        particleEffectPresenter.Initialize();
        sceneRoot.Initialize();
        bankPresenter.Initialize();
        
        chooseChickenPresenter.Initialize();
        chickenBattlePresenter.Initialize();
        cameraFollowPresenter.Initialize();
        visualChickenEffectPresenter.Initialize();
        slotMachinePresenter.Initialize();
        maskEffectPresenter.Initialize();
        spawnerChickenPresenter.Initialize();

        chooseBuyBoxPresenter.Initialize();
        raceDesignPresenter.Initialize();

        timerPresenter_Start.Initialize();
        timerPresenter_Game.Initialize();

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

        videoPresenter?.Dispose();
        chooseChickenPresenter?.Dispose();
        chickenBattlePresenter?.Dispose();
        cameraFollowPresenter?.Dispose();
        visualChickenEffectPresenter?.Dispose();
        slotMachinePresenter?.Dispose();
        maskEffectPresenter?.Dispose();
        spawnerChickenPresenter?.Dispose();

        chooseBuyBoxPresenter?.Dispose();
        raceDesignPresenter?.Dispose();

        timerPresenter_Start?.Dispose();
        timerPresenter_Game?.Dispose();

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
