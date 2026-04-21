using System;
using UnityEngine;

public class VisualPseudoPicturePieceModel
{
    private IStoreChickenPicturePieceListener _storeChickenPicturePieceListener;
    private IStoreChickenPicturePieceProvider _storeChickenPicturePieceProvider;

    private bool isActive = true;

    public VisualPseudoPicturePieceModel(IStoreChickenPicturePieceListener storeChickenPicturePieceListener, IStoreChickenPicturePieceProvider storeChickenPicturePieceProvider)
    {
        _storeChickenPicturePieceListener = storeChickenPicturePieceListener;
        _storeChickenPicturePieceProvider = storeChickenPicturePieceProvider;
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

    public void OpenPiece(ChickenPicturePiece piece)
    {
        _storeChickenPicturePieceProvider.OpenPiece(piece);
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
