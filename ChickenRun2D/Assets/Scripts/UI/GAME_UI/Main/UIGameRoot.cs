using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameRoot : UIRoot
{
    [SerializeField] private MovePanel backgroundBrownPanel;
    [SerializeField] private MovePanel backgroundBarnPanel;

    [SerializeField] private ChoosePanel_Game choosePanel;

    [SerializeField] private LosePanel_Game losePanel;
    [SerializeField] private WinPanel_Game winPanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        backgroundBarnPanel.Initialize();
        backgroundBrownPanel.Initialize();
        choosePanel.Initialize();

        losePanel.Initialize();
        winPanel.Initialize();
    }

    public void Activate()
    {
        choosePanel.OnChoose += ClickToChoose_CHOOSE;

        losePanel.OnClickToRestart += ClickToRestart_LOSE;
        winPanel.OnClickToRestart += ClickToRestart_WIN;
    }

    public void Deactivate()
    {
        if (currentPanel != null)
            CloseOtherPanel(currentPanel);

        choosePanel.OnChoose -= ClickToChoose_CHOOSE;

        losePanel.OnClickToRestart -= ClickToRestart_LOSE;
        winPanel.OnClickToRestart -= ClickToRestart_WIN;
    }

    public void Dispose()
    {
        backgroundBarnPanel.Dispose();
        backgroundBrownPanel.Dispose();
        choosePanel.Dispose();

        losePanel.Dispose();
        winPanel.Dispose();
    }

    #region Input

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

    #endregion


    #region Output

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

    private void ClickToRestart_WIN()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnClickToRestart_WIN?.Invoke();
    }

    #endregion

    #endregion
}
