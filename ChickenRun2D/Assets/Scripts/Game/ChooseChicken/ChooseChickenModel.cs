using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChickenModel
{
    private List<ChickenType> chickenTypes = new();

    private ChickenType _currentType = ChickenType.None;

    private readonly IStoreChickenListener _storeChickenListener;

    public ChooseChickenModel(IStoreChickenListener storeChickenListener)
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

    public void Choose(ChickenType chickenType)
    {
        if(_currentType == chickenType) return;

        OnDeactivate?.Invoke(_currentType);

        _currentType = chickenType;

        for (int i = 0; i < chickenTypes.Count; i++)
        {
            if(_currentType != chickenTypes[i])
            {
                OnDeactivate?.Invoke(chickenTypes[i]);
            }
            else
            {
                OnActivate?.Invoke(chickenTypes[i]);
            }
        }
    }

    private void SetTypes(List<ChickenType> types)
    {
        _currentType = ChickenType.None;

        chickenTypes = new List<ChickenType>(types);

        OnSetTypes?.Invoke(chickenTypes);

        chickenTypes.ForEach(data => OnActivate?.Invoke(data));
    }

    #region Output

    public event Action<List<ChickenType>> OnSetTypes;

    public event Action<ChickenType> OnActivate;
    public event Action<ChickenType> OnDeactivate;

    #endregion
}
