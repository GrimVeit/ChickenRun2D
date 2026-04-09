using System;
using System.Collections.Generic;

public class SpawnerChickenModel
{
    private readonly IStoreChickenListener _storeChickenListener;

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

    private void SetTypes(List<ChickenType> types)
    {
        OnSpawnChicken?.Invoke(types);
    }

    #region Output

    public event Action<List<ChickenType>> OnSpawnChicken;

    #endregion
}
