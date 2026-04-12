using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenUnitModel
{
    public ChickenType Type => _type;

    private readonly ChickenType _type;

    public ChickenUnitModel(ChickenType type)
    {
        _type = type;
    }

    #region Output

    public event Action OnEndMove;
    public void EndMove()
    {
        OnEndMove?.Invoke();
    }

    #endregion

    #region Move

    public void SetSpeed(float speed)
    {
        OnSetSpeed?.Invoke(speed);
    }

    public void SetSpeed(float speed, float duration)
    {
        OnSetSpeed_Smooth?.Invoke(speed, duration);
    }

    public void StartMove()
    {
        OnStartMove?.Invoke();
    }

    public void StopMove()
    {
        OnStopMove?.Invoke();
    }

    #endregion

    #region ANIMATION

    public void Show()
    {
        OnShow?.Invoke();
    }

    public void Hide()
    {
        OnHide?.Invoke();
    }

    public void ActivateAnimation(ChickenAnimationType animationType)
    {
        OnActivateAnimation?.Invoke(animationType);
    }

    #endregion

    #region Output

    public event Action<float> OnSetSpeed;
    public event Action<float, float> OnSetSpeed_Smooth;
    public event Action OnStartMove;
    public event Action OnStopMove;

    public event Action OnShow;
    public event Action OnHide;
    public event Action<ChickenAnimationType> OnActivateAnimation;

    #endregion
}
