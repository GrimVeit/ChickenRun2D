using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHintPicturePiecePresenter
{
    private readonly VisualHintPicturePieceModel _model;
    private readonly VisualHintPicturePieceView _view;

    public VisualHintPicturePiecePresenter(VisualHintPicturePieceModel model, VisualHintPicturePieceView view)
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
