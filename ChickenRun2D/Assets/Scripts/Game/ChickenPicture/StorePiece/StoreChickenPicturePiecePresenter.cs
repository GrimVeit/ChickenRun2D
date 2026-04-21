using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreChickenPicturePiecePresenter : IStoreChickenPicturePieceListener
{
    private readonly StoreChickenPicturePieceModel _model;

    public StoreChickenPicturePiecePresenter(StoreChickenPicturePieceModel model)
    {
        _model = model;
    }

    public void Initialize()
    {
        _model.Initialize();
    }

    public void Dispose()
    {
        _model.Dispose();
    }

    #region Output

    public event Action<ChickenPicturePiece> OnAddPiece
    {
        add => _model.OnAddPiece += value;
        remove => _model.OnAddPiece -= value;
    }

    public event Action<ChickenPicturePiece> OnRemovePiece
    {
        add => _model.OnRemovePiece += value;
        remove => _model.OnRemovePiece -= value;
    }

    #endregion
}

public interface IStoreChickenPicturePieceListener
{
    public event Action<ChickenPicturePiece> OnAddPiece;
    public event Action<ChickenPicturePiece> OnRemovePiece;
}
