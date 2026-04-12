using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel_Game : MovePanel
{
    [SerializeField] private UIEffectCombination combination;
    [SerializeField] private Button buttonRestart;

    public override void Initialize()
    {
        base.Initialize();

        combination.Initialize();

        buttonRestart.onClick.AddListener(ClickRestart);
    }

    public override void Dispose()
    {
        base.Dispose();

        combination.Dispose();

        buttonRestart.onClick.RemoveListener(ClickRestart);
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        combination.ActivateEffect();
    }

    public override void DeactivatePanel()
    {
        base.DeactivatePanel();

        combination.DeactivateEffect();
    }

    #region Output

    public event Action OnClickToRestart;

    private void ClickRestart()
    {
        OnClickToRestart?.Invoke();
    }

    #endregion
}
