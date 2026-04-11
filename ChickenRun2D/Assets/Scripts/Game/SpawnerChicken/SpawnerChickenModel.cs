using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChickenModel
{
    private readonly IStoreChickenListener _storeChickenListener;

    private  List<ChickenType> _chickenTypes = new();

    public SpawnerChickenModel(IStoreChickenListener storeChickenListener)
    {
        _storeChickenListener = storeChickenListener;
    }

    public void Initialize()
    {
        _storeChickenListener.OnChooseChickens += SetTypes;
    }

    public void Dispose()
    {
        _storeChickenListener.OnChooseChickens -= SetTypes;
    }

    public void SpawnChickens()
    {
        OnSpawnChicken?.Invoke(_chickenTypes);
    }

    private void SetTypes(List<ChickenType> types)
    {
        _chickenTypes = types;
    }

    #region Output

    public event Action<List<ChickenType>> OnSpawnChicken;

    #endregion
}
