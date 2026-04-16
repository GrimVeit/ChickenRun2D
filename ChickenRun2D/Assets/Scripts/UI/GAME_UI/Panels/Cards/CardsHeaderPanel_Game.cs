using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsHeaderPanel_Game : MovePanel
{
    [SerializeField] private UIEffectCombination combination;
    [SerializeField] private Button buttonExit;

    public override void Initialize()
    {
        base.Initialize();

        combination.Initialize();

        buttonExit.onClick.AddListener(ClickToExit);
    }

    public override void Dispose()
    {
        base.Dispose();

        combination.Dispose();

        buttonExit.onClick.RemoveListener(ClickToExit);
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

    public event Action OnClickToExit;

    private void ClickToExit()
    {
        OnClickToExit?.Invoke();
    }

    #endregion
}
