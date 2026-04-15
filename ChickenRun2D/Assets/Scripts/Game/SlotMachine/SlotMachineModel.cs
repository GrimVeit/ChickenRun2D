using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlotMachineModel
{
    public bool IsActiveMachine { get; private set; }

    public event Action OnActivateMachine;
    public event Action<int> OnStopSpinnedSlot;
    public event Action OnDeactivateMachine;

    //private IMoneyProvider moneyProvider;
    //private IParticleEffectProvider particleEffectProvider;
    //private ISoundProvider soundProvider;
    //private ISound[] slotWheelsSound;

    public SlotMachineModel()
    {
        //this.moneyProvider = moneyProvider;
        //this.soundProvider = soundProvider;
        //this.particleEffectProvider = particleEffectProvider;

        //slotWheelsSound = new ISound[columnSlot];

        //GetSounds();
    }

    #region Sounds

    private void GetSounds()
    {
        //for (int i = 0; i < slotWheelsSound.Length; i++)
        //{
        //    slotWheelsSound[i] = soundProvider.GetSound("Wheel_" + i);
        //}
    }

    private void PlayWheelSounds()
    {
        //for (int i = 0; i < slotWheelsSound.Length; i++)
        //{
        //    slotWheelsSound[i].SetVolume(0.1f);
        //    slotWheelsSound[i].SetPitch(1);
        //    slotWheelsSound[i].Play();
        //}
    }

    private void StopWheelSounds()
    {
        //for (int i = 0; i < slotWheelsSound.Length; i++)
        //{
        //    slotWheelsSound[i].Stop();
        //}
    }

    public void WheelSpeed(float speed)
    {
        //if (speed > 0.1f)
        //{
        //    return;
        //}

        //slotWheelsSound[index].SetVolume(speed/2);

        //float pitch = Mathf.Lerp(1, 0.88f, 1 - speed);
        //slotWheelsSound[index].SetPitch(pitch * 1f);


    }

    #endregion

    public void ActivateMachine()
    {
        if (IsActiveMachine)
        {
            //soundProvider.PlayOneShot("Error");
            return;
        }

        IsActiveMachine = true;
        PlayWheelSounds();
        OnActivateMachine?.Invoke();
    }

    public void StopSpinSlot(int Id)
    {
        OnStopSpinnedSlot?.Invoke(Id);
        
        DeactivateMachine();
    }

    public void DeactivateMachine()
    {
        OnDeactivateMachine?.Invoke();
        IsActiveMachine = false;

        StopWheelSounds();

    }
}
