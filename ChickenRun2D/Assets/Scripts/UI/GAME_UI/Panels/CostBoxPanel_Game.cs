using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostBoxPanel_Game : MovePanel
{
    [SerializeField] private UIEffectCombination combination;
    [SerializeField] private Button buttonBuy;

    public override void Initialize()
    {
        base.Initialize();

        combination.Initialize();

        buttonBuy.onClick.AddListener(ClickToBuy);
    }

    public override void Dispose()
    {
        base.Dispose();

        combination.Dispose();

        buttonBuy.onClick.RemoveListener(ClickToBuy);
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

    public event Action OnClickToBuy;

    private void ClickToBuy()
    {
        OnClickToBuy?.Invoke();
    }

    #endregion
}
