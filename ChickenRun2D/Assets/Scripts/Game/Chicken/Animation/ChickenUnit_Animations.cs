using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;

public class ChickenUnit_Animations : MonoBehaviour
{
    [SerializeField] private ChickenAnimations animations;

    public void Show()
    {
        transform.localScale = Vector3.zero;

        transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.25f)
            .SetEase(Ease.OutBack);
    }

    public void HideDestroy()
    {
        transform.DOScale(Vector3.zero, 0.25f)
        .SetEase(Ease.InBack)
        .OnComplete(() => Destroy(gameObject));
    }

    public void SetOrder(int order)
    {
        animations.SetOrder(order);
    }

    public void SetSkin(string name)
    {
        animations.SetSkin(name);
    }

    public void ActivateAnimation(ChickenAnimationType animationType)
    {
        animations.ActivateAnimation(animationType);
    }

    #region Output

    public event Action OnClick;

    private void ClickItem()
    {
        OnClick?.Invoke();
    }

    #endregion
}

[Serializable]
public class ChickenAnimations
{
    [SerializeField] private List<ChickenAnimation> bartenderAnimations = new();

    public void ActivateAnimation(ChickenAnimationType animationEnum)
    {
        bartenderAnimations.ForEach(data => data.ActivateAnimation(animationEnum));
    }

    public void SetOrder(int order)
    {
        bartenderAnimations.ForEach(data => data.SetOrder(order));
    }

    public void SetSkin(string name)
    {
        bartenderAnimations.ForEach(data => data.SetSkin(name));
    }
}

[Serializable]
public class ChickenAnimation
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private List<ChickAnimationType> skeletonAnimationTypes = new List<ChickAnimationType>();

    public void SetOrder(int order)
    {
        skeletonAnimation.GetComponent<MeshRenderer>().sortingOrder = order;
    }

    public void SetSkin(string name)
    {
        skeletonAnimation.Skeleton.SetSkin(name);
    }

    public void Activate()
    {
        skeletonAnimation.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        skeletonAnimation.gameObject.SetActive(false);
    }

    public void ActivateAnimation(ChickenAnimationType animationEnum)
    {
        var skeletonAnimationType = GetSkeletonAnimationType(animationEnum);
        if (skeletonAnimationType == null) return;

        skeletonAnimation.AnimationState.SetAnimation(0, skeletonAnimationType.Key, skeletonAnimationType.IsLoop);
    }

    private ChickAnimationType GetSkeletonAnimationType(ChickenAnimationType animationEnum)
    {
        return skeletonAnimationTypes.Find(data => data.AnimationEnum == animationEnum);
    }
}

[Serializable]
public class ChickAnimationType
{
    [SerializeField] private string key;
    [SerializeField] private ChickenAnimationType animationEnum;
    [SerializeField] private bool isLoop;

    public string Key => key;
    public ChickenAnimationType AnimationEnum => animationEnum;
    public bool IsLoop => isLoop;
}
