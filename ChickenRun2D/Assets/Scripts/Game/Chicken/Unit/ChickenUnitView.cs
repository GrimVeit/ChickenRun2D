using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChickenUnitView : MonoBehaviour
{
    [SerializeField] private ChickenMove move;

    public void Initialize()
    {
        move.Initialize();
    }

    public void Dispose()
    {

    }

    public void SetTarget(Vector3 target)
    {
        move.SetTarget(target);
    }

    public void StartMove()
    {
        move.StartMove();
    }

    public void StopMove()
    {
        move.StopMove();
    }

    public void SetSpeed(float speed)
    {
        move.SetSpeed(speed);
    }

    public void SetSpeed(float speed, float duration)
    {
        move.SetSpeed(speed, duration);
    }
}
