using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameRoot : UIRoot
{
    [SerializeField] private ChoosePanel_Game choosePanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        choosePanel.Initialize();
    }

    public void Activate()
    {
        choosePanel.OnChoose += ClickToChoose_CHOOSE;
    }

    public void Deactivate()
    {
        if (currentPanel != null)
            CloseOtherPanel(currentPanel);

        choosePanel.OnChoose -= ClickToChoose_CHOOSE;
    }

    public void Dispose()
    {
        choosePanel.Dispose();
    }

    #region Input

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

    #endregion
}
