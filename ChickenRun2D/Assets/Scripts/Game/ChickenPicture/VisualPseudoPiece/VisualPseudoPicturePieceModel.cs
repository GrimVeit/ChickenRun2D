using System;
using UnityEngine;

public class VisualPseudoPicturePieceModel
{
    private IStoreChickenPicturePieceListener _storeChickenPicturePieceListener;

    private bool isActive = true;

    public VisualPseudoPicturePieceModel(IStoreChickenPicturePieceListener storeChickenPicturePieceListener)
    {
        _storeChickenPicturePieceListener = storeChickenPicturePieceListener;
    }

    public void Initialize()
    {
        _storeChickenPicturePieceListener.OnAddPiece += AddPiece;
        _storeChickenPicturePieceListener.OnRemovePiece += RemovePiece;
    }

    public void Dispose()
    {
        _storeChickenPicturePieceListener.OnAddPiece -= AddPiece;
        _storeChickenPicturePieceListener.OnRemovePiece -= RemovePiece;
    }

    private void AddPiece(ChickenPicturePiece piece)
    {
        OnAddPieceToVisual?.Invoke(piece);
    }

    private void RemovePiece(ChickenPicturePiece piece)
    {
        OnRemovePieceFromVisual?.Invoke(piece);
    }

    #region ACTIVATOR

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }

    #endregion

    #region Output

    public event Action<ChickenPicturePiece> OnAddPieceToVisual;
    public event Action<ChickenPicturePiece> OnRemovePieceFromVisual;

    #endregion
}
