using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPseudoPicturePiecePresenter
{
    private readonly VisualPseudoPicturePieceModel _model;
    private readonly VisualPseudoPicturePieceView _view;

    public VisualPseudoPicturePiecePresenter(VisualPseudoPicturePieceModel model, VisualPseudoPicturePieceView view)
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

    }

    private void DeactivateEvents()
    {

    }
}
