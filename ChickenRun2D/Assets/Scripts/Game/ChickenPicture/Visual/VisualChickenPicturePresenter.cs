using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualChickenPicturePresenter : IVisualChickenPictureListener
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

        _model.Initialize();
        _view.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _model.Dispose();
        _view.Dispose();
    }

    private void ActivateEvents()
    {
        _model.OnSetType += _view.SetType;
        _model.OnPieceUpdate += _view.UpdatePiece;
        _model.OnClear += _view.Clear;

        _view.OnChooseType += _model.GetPicturesByType;
    }

    private void DeactivateEvents()
    {
        _model.OnSetType -= _view.SetType;
        _model.OnPieceUpdate -= _view.UpdatePiece;
        _model.OnClear -= _view.Clear;

        _view.OnChooseType -= _model.GetPicturesByType;
    }

    #region Output

    public event Action OnSelectType
    {
        add => _model.OnSelectType += value;
        remove => _model.OnSelectType -= value;
    }

    #endregion
}

public interface IVisualChickenPictureListener
{
    public event Action OnSelectType;
}
