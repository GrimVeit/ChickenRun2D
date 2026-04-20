using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualChickenPicturePresenter
{
    private readonly VisualChickenPictureModel _model;
    private readonly VisualChickenPictureView _view;

    public VisualChickenPicturePresenter(VisualChickenPictureModel model, VisualChickenPictureView view)
    {
        _model = model;
        _view = view;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        _view.OnChooseType += _model.GetPicturesByType;
    }

    private void DeactivateEvents()
    {
        _view.OnChooseType -= _model.GetPicturesByType;
    }
}
