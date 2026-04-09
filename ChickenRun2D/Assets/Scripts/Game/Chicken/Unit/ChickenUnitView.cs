using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChickenUnitView : View
{
    [SerializeField] private ChickenUnit_Move move;
    [SerializeField] private ChickenUnit_Animations animations;

    public void Initialize()
    {
        move.OnEndMove += EndMove;
        move.Initialize();
    }

    public void Dispose()
    {
        move.OnEndMove -= EndMove;
    }

    #region MOVE

    public void SetTarget(Vector3 target)
    {
        move.SetTarget(target);
    }

    public void SetSpeed(float speed)
    {
        move.SetSpeed(speed);
    }

    public void SetSpeed(float speed, float duration)
    {
        move.SetSpeed(speed, duration);
    }

    public void StartMove()
    {
        move.StartMove();
    }

    public void StopMove()
    {
        move.StopMove();
    }

    #endregion

    #region ANIMATION

    public void Show()
    {
        animations.Show();
    }

    public void Hide()
    {
        animations.HideDestroy();
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

    #endregion

    #region Output

    public event Action OnEndMove;

    private void EndMove()
    {
        OnEndMove?.Invoke();
    }

    #endregion
}
