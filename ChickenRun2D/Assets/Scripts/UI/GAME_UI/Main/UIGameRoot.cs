using System;
using UnityEngine;

public class UIGameRoot : UIRoot
{
    [SerializeField] private MovePanel introVideoPanel;
    [SerializeField] private PlayVideoPanel_Game playVideoPanel;
    [SerializeField] private MovePanel winVideoPanel;
    [SerializeField] private MovePanel loseVideoPanel;

    [SerializeField] private MovePanel backgroundBrownPanel;
    [SerializeField] private MovePanel backgroundBarnPanel;

    [SerializeField] private MainPanel_Game mainPanel;

    [SerializeField] private ChoosePanel_Game choosePanel;

    [SerializeField] private LosePanel_Game losePanel;
    [SerializeField] private WinPanel_Game winPanel;

    [SerializeField] private CostBoxPanel_Game costBoxPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        introVideoPanel.Initialize();
        playVideoPanel.Initialize();
        winVideoPanel.Initialize();
        loseVideoPanel.Initialize();

        backgroundBarnPanel.Initialize();
        backgroundBrownPanel.Initialize();
        mainPanel.Initialize();
        choosePanel.Initialize();

        losePanel.Initialize();
        winPanel.Initialize();

        costBoxPanel.Initialize();
    }

    public void Activate()
    {
        playVideoPanel.OnClickPlay += ClickToPlay_PLAY;

        choosePanel.OnChoose += ClickToChoose_CHOOSE;

        losePanel.OnClickToRestart += ClickToRestart_LOSE;
        winPanel.OnClickToRestart += ClickToRestart_WIN;
        winPanel.OnClickToBuy += ClickToBuy_WIN;

        costBoxPanel.OnClickToBuy += ClickToBox_COSTBOX;
    }

    public void Deactivate()
    {
        if (currentPanel != null)
            CloseOtherPanel(currentPanel);

        playVideoPanel.OnClickPlay -= ClickToPlay_PLAY;

        choosePanel.OnChoose -= ClickToChoose_CHOOSE;

        losePanel.OnClickToRestart -= ClickToRestart_LOSE;
        winPanel.OnClickToRestart -= ClickToRestart_WIN;
        winPanel.OnClickToBuy -= ClickToBuy_WIN;

        costBoxPanel.OnClickToBuy -= ClickToBox_COSTBOX;
    }

    public void Dispose()
    {
        introVideoPanel.Dispose();
        playVideoPanel.Dispose();
        winVideoPanel.Dispose();
        loseVideoPanel.Dispose();

        backgroundBarnPanel.Dispose();
        backgroundBrownPanel.Dispose();
        mainPanel.Dispose();
        choosePanel.Dispose();

        losePanel.Dispose();
        winPanel.Dispose();

        costBoxPanel.Dispose();
    }

    #region Input

    #region VIDEO

    public void OpenIntroVideoPanel()
    {
        if(introVideoPanel.IsActive) return;

        OpenOtherPanel(introVideoPanel);
    }

    public void CloseIntroVideoPanel()
    {
        if(!introVideoPanel.IsActive) return;

        CloseOtherPanel(introVideoPanel);
    }



    public void OpenPlayVideoPanel()
    {
        if(playVideoPanel.IsActive) return;

        OpenOtherPanel(playVideoPanel);
    }

    public void ClosePlayVideoPanel()
    {
        if(!playVideoPanel.IsActive) return;

        CloseOtherPanel(playVideoPanel);
    }



    public void OpenWinVideoPanel()
    {
        if(winVideoPanel.IsActive) return;

        OpenOtherPanel(winVideoPanel);
    }

    public void CloseWinVideoPanel()
    {
        if(!winVideoPanel.IsActive) return;

        CloseOtherPanel(winVideoPanel);
    }



    public void OpenLoseVideoPanel()
    {
        if(loseVideoPanel.IsActive) return;

        OpenOtherPanel(loseVideoPanel);
    }

    public void CloseLoseVideoPanel()
    {
        if(!loseVideoPanel.IsActive) return;

        CloseOtherPanel(loseVideoPanel);
    }

    #endregion


    public void OpenMainPanel()
    {
        if(mainPanel.IsActive) return;

        OpenOtherPanel(mainPanel);
    }

    public void CLoseMainPanel()
    {
        if(!mainPanel.IsActive) return;

        CloseOtherPanel(mainPanel);
    }



    public void OpenBackgroundBrownPanel()
    {
        if(backgroundBrownPanel.IsActive) return;

        OpenOtherPanel(backgroundBrownPanel);
    }

    public void CloseBackgroundBrownPanel()
    {
        if(!backgroundBrownPanel.IsActive) return;

        CloseOtherPanel(backgroundBrownPanel);
    }


    public void OpenBackgroundBarnPanel()
    {
        if(backgroundBarnPanel.IsActive) return;

        OpenOtherPanel(backgroundBarnPanel);
    }

    public void CloseBackgroundBarnPanel()
    {
        if(!backgroundBarnPanel.IsActive) return;

        CloseOtherPanel(backgroundBarnPanel);
    }



    public void OpenChoosePanel()
    {
        if(choosePanel.IsActive) return;

        OpenOtherPanel(choosePanel);
    }

    public void CloseChoosePanel()
    {
        if(!choosePanel.IsActive) return;

        CloseOtherPanel(choosePanel);
    }




    public void OpenLosePanel()
    {
        if(losePanel.IsActive) return;

        OpenOtherPanel(losePanel);
    }

    public void CloseLosePanel()
    {
        if(!losePanel.IsActive) return;

        CloseOtherPanel(losePanel);
    }

    public void OpenWinPanel()
    {
        if(winPanel.IsActive) return;

        OpenOtherPanel(winPanel);
    }

    public void CloseWinPanel()
    {
        if(!winPanel.IsActive) return;

        CloseOtherPanel(winPanel);
    }



    public void OpenCostBoxPanel()
    {
        if(costBoxPanel.IsActive) return;

        OpenOtherPanel(costBoxPanel);
    }

    public void CloseCostBoxPanel()
    {
        if(!costBoxPanel.IsActive) return;

        CloseOtherPanel(costBoxPanel);
    }

    #endregion


    #region Output

    #region PLAY_VIDEO

    public event Action OnClickToPlay_PLAY;

    private void ClickToPlay_PLAY()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnClickToPlay_PLAY?.Invoke();
    }

    #endregion


    #region CHOOSE

    public event Action OnClickToChoose_CHOOSE;

    private void ClickToChoose_CHOOSE()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnClickToChoose_CHOOSE?.Invoke();
    }

    #endregion

    #region LOSE

    public event Action OnClickToRestart_LOSE;

    private void ClickToRestart_LOSE()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnClickToRestart_LOSE?.Invoke();
    }

    #endregion

    #region WIN

    public event Action OnClickToRestart_WIN;
    public event Action OnClickToBuy_WIN;

    private void ClickToRestart_WIN()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnClickToRestart_WIN?.Invoke();
    }

    private void ClickToBuy_WIN()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnClickToBuy_WIN?.Invoke();
    }

    #endregion


    #region COST_BOX

    public event Action OnClickToBox_COSTBOX;

    private void ClickToBox_COSTBOX()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnClickToBox_COSTBOX?.Invoke();
    }

    #endregion

    #endregion
}
