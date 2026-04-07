using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenUnitPresenter
{
    private readonly ChickenUnitModel _model;
    private readonly ChickenUnitView _view;

    public ChickenUnitPresenter(ChickenUnitModel model, ChickenUnitView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }
}
