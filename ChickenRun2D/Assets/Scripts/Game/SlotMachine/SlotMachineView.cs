using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineView : View
{
    public event Action OnClickSpin;

    public event Action OnStartSpinSlot;
    public event Action<float> OnWheelSpeed;
    public event Action<int> OnStopSpinSlot;

    [SerializeField] private Button spinButton;
    [SerializeField] private Slot slot;

    public void Initialize()
    {
        slot.OnStopSpin += EndSpinSlot;
        slot.OnStartSpin += StartSpinSlot;
        slot.OnWheelSpeed += WheelSpeed;

        spinButton.onClick.AddListener(HandlerSpinClick);

    }

    public void OnDestroy()
    {
        slot.OnStopSpin -= EndSpinSlot;
        slot.OnStartSpin -= StartSpinSlot;
        slot.OnWheelSpeed -= WheelSpeed;

        spinButton.onClick.RemoveListener(HandlerSpinClick);
    }

    public void ActivateMachine()
    {
        slot.StartSpin();
    }


    public void StartSpinSlot()
    {
        OnStartSpinSlot?.Invoke();
    }

    public void EndSpinSlot(int Id)
    {
        OnStopSpinSlot?.Invoke(Id);
    }

    public void WheelSpeed(float speed)
    {
        OnWheelSpeed?.Invoke(speed);
    }

    #region Input

    private void HandlerSpinClick()
    {
        OnClickSpin?.Invoke();
    }

    #endregion

}
