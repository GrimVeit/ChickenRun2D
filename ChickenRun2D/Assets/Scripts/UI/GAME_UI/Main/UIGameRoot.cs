using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameRoot : UIRoot
{
    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {
        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }

    public void Dispose()
    {
        
    }

    #region Input

    

    #endregion


    #region Output

    #region MAIN

    public event Action OnCLickToUpgrade_MAIN;
    public event Action OnClickToHireStaff_MAIN;

    private void ClickToUpgrade_MAIN()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnCLickToUpgrade_MAIN?.Invoke();
    }

    private void ClickToHireStaff_MAIN()
    {
        _soundProvider.PlayOneShot("PanelOpen");

        OnClickToHireStaff_MAIN?.Invoke();
    }

    #endregion
    
    #endregion
}
