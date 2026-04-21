using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPseudoPicturePiecePresenter : IPseudoPicturePieceActivatorProvider
{
    private readonly VisualPseudoPicturePieceModel _model;
    private readonly VisualPseudoPicturePieceView _view;

    public VisualPseudoPicturePiecePresenter(VisualPseudoPicturePieceModel pseudoChipModel, VisualPseudoPicturePieceView pseudoChipView)
    {
        _model = pseudoChipModel;
        _view = pseudoChipView;
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
        _view.OnOpenPiece += _model.OpenPiece;

        _model.OnAddPieceToVisual += _view.AddPiece;
        _model.OnRemovePieceFromVisual += _view.RemovePiece;
    }

    private void DeactivateEvents()
    {
        _view.OnOpenPiece -= _model.OpenPiece;

        _model.OnAddPieceToVisual -= _view.AddPiece;
        _model.OnRemovePieceFromVisual -= _view.RemovePiece;
    }

    #region Input

    public void Activate()
    {
        _model.Activate();
    }

    public void Deactivate()
    {
        _model.Deactivate();
    }

    #endregion
}

public interface IPseudoPicturePieceActivatorProvider
{
    void Activate();
    void Deactivate();
}
