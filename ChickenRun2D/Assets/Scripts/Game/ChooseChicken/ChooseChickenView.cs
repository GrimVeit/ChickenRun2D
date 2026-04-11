using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class ChooseChickenView : View
{
    [SerializeField] private List<ChooseChicken> chooseChickens = new(); //5 CHICKENS
    [SerializeField] private ChooseChickenDatas chickenDatas;

    public void Initialize()
    {
        chooseChickens.ForEach(data =>
        {
            data.OnChooseChicken += ChooseChicken;
            data.Initialize();
        });
    }

    public void Dispose()
    {
        chooseChickens.ForEach(data =>
        {
            data.OnChooseChicken -= ChooseChicken;
            data.Dispose();
        });
    }

    public void ActivateAll()
    {
        chooseChickens.ForEach(cc => cc.Activate());
    }

    public void DeactivateAll()
    {
        chooseChickens.ForEach(cc => cc.Deactivate());
    }

    public void Choose(ChickenType type)
    {
        var chicken = chooseChickens.FirstOrDefault(ch => ch.Type == type);

        if(chicken == null)
        {
            Debug.LogWarning("Not found ChooseChicken with ChickenType - " + type);
            return;
        }

        chicken.Choose();
    }

    public void Unchoose(ChickenType type)
    {
        var chicken = chooseChickens.FirstOrDefault(ch => ch.Type == type);

        if (chicken == null)
        {
            Debug.LogWarning("Not found ChooseChicken with ChickenType - " + type);
            return;
        }

        chicken.Unchoose();
    }

    public void ChooseAll()
    {
        chooseChickens.ForEach(cc => cc.Choose());
    }

    public void SetTypes(List<ChickenType> chickenTypes)
    {
        if(chooseChickens.Count != chickenTypes.Count)
        {
            Debug.LogError("ERROR COUNT");
            return;
        }

        for (int i = 0; i < chooseChickens.Count; i++)
        {
            var data = chickenDatas.GetChooseChickenData(chickenTypes[i]);

            if(data == null)
            {
                Debug.LogWarning("Not found ChickenData with ChickenType - " + chickenTypes[i]);
                return;
            }

            chooseChickens[i].SetData(data);
        }
    }

    #region Output

    public event Action<ChickenType> OnChooseChicken;

    private void ChooseChicken(ChickenType type)
    {
        OnChooseChicken?.Invoke(type);
    }

    #endregion
}

[Serializable]
public class ChooseChicken
{
    public ChickenType Type => _data.ChickenType;

    [SerializeField] private Image imageChicken;
    [SerializeField] private Button buttonChicken;
    [SerializeField] private SkeletonGraphic skeleton;

    private ChooseChickenData _data;
    private bool isActive = true;

    public void Initialize()
    {
        buttonChicken.onClick.AddListener(ChooseChick);
    }

    public void Dispose()
    {
        buttonChicken.onClick.RemoveListener(ChooseChick);
    }

    public void SetData(ChooseChickenData data)
    {
        _data = data;
    }

    public void Show()
    {
        imageChicken.transform.localScale = Vector3.zero;

        imageChicken.transform.DOScale(Vector3.one, 0.2f)
        .SetEase(Ease.OutBack);

        skeleton.AnimationState.SetAnimation(0, "Avatar", false);
    }

    public void Hide()
    {
        imageChicken.transform.DOScale(Vector3.zero, 0.2f)
        .SetEase(Ease.InBack);
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }


    public void Choose()
    {
        imageChicken.sprite = _data.SpriteActivate;
    }

    public void Unchoose()
    {
        imageChicken.sprite = _data.SpriteDeactivate;
    }

    #region Output

    public event Action<ChickenType> OnChooseChicken;
    private void ChooseChick()
    {
        if(!isActive) return;

        OnChooseChicken?.Invoke(_data.ChickenType);
    }

    #endregion
}

[Serializable]
public class ChooseChickenDatas
{
    [SerializeField] private List<ChooseChickenData> chickenDatas;

    public ChooseChickenData GetChooseChickenData(ChickenType type)
    {
        return chickenDatas.FirstOrDefault(data => data.ChickenType == type);
    }
}

[Serializable]
public class ChooseChickenData
{
    public ChickenType ChickenType => chickenType;
    public Sprite SpriteActivate => spriteActivate;
    public Sprite SpriteDeactivate => spriteDeactivate;

    [SerializeField] private ChickenType chickenType;
    [SerializeField] private Sprite spriteActivate;
    [SerializeField] private Sprite spriteDeactivate;
}
