using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChickenPresenter
{
    private readonly SpawnerChickenModel _model;
    private readonly SpawnerChickenView _view;

    public SpawnerChickenPresenter(SpawnerChickenModel model, SpawnerChickenView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();

        _model.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnSpawnChicken += _view.SetTypes;
    }

    private void DeactivateEvents()
    {
        _model.OnSpawnChicken -= _view.SetTypes;
    }
}
