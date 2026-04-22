using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPiecesPresenter : IBuyPiecesProvider
{
    private readonly BuyPiecesModel _model;
    private readonly BuyPiecesView _view;

    public BuyPiecesPresenter(BuyPiecesModel model, BuyPiecesView view)
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
        _model.OnSetPieces += _view.SetPieces;
    }

    private void DeactivateEvents()
    {
        _model.OnSetPieces -= _view.SetPieces;
    }

    #region Input

    public void GeneratePieces() => _model.GeneratePieces();
    public void Show() => _view.Show();
    public void Clear()
    {

    }

    #endregion
}

public interface IBuyPiecesProvider
{
    public void GeneratePieces();
    public void Show();
    public void Clear();
}
