using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachinePresenter
{
    private SlotMachineModel slotMachineModel;
    private SlotMachineView slotMachineView;

    public SlotMachinePresenter(SlotMachineModel slotMachineModel, SlotMachineView slotMachineView)
    {
        this.slotMachineModel = slotMachineModel;
        this.slotMachineView = slotMachineView;
    }

    public void Initialize()
    {
        slotMachineView.Initialize();

        ActivateInputEvents();
        slotMachineModel.OnActivateMachine += slotMachineView.ActivateMachine;
    }

    public void Dispose()
    {
        DeactivateInputEvents();
        slotMachineModel.OnActivateMachine -= slotMachineView.ActivateMachine;
    }

    private void ActivateInputEvents()
    {
        slotMachineView.OnStopSpinSlot += slotMachineModel.StopSpinSlot;
        slotMachineView.OnClickSpin += slotMachineModel.ActivateMachine;
        slotMachineView.OnWheelSpeed += slotMachineModel.WheelSpeed;
    }

    private void DeactivateInputEvents()
    {
        slotMachineView.OnStopSpinSlot -= slotMachineModel.StopSpinSlot;
        slotMachineView.OnClickSpin -= slotMachineModel.ActivateMachine;
        slotMachineView.OnWheelSpeed -= slotMachineModel.WheelSpeed;
    }

    #region PublicEvents



    #endregion
}
