using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChickenUnitView : View
{
    public ChickenUnit_Move Move => move;
    public ChickenUnit_Animations Animation => animations;
    

    [SerializeField] private ChickenUnit_Move move;
    [SerializeField] private ChickenUnit_Animations animations;

    public void Initialize()
    {
        move.Initialize();
    }

    public void Dispose()
    {

    }
}
