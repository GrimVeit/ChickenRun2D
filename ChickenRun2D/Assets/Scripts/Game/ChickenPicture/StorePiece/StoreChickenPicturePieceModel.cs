using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoreChickenPicturePieceModel
{
    private readonly IStoreChickenPictureListener _storeChickenPictureListener;

    private readonly List<ChickenPicturePiece> _ownedPieces = new();

    public StoreChickenPicturePieceModel(IStoreChickenPictureListener storeChickenPictureListener)
    {
        _storeChickenPictureListener = storeChickenPictureListener;
    }

    public void Initialize()
    {
        _storeChickenPictureListener.OnPieceOwned += AddOwnedPiece;
        _storeChickenPictureListener.OnPieceOpened += RemoveOwnedPiece;
    }

    public void Dispose()
    {
        _storeChickenPictureListener.OnPieceOwned -= AddOwnedPiece;
        _storeChickenPictureListener.OnPieceOpened -= RemoveOwnedPiece;
    }

    private void AddOwnedPiece(ChickenPicturePiece piece)
    {
        Debug.Log($"ADD PIECE INVENTORY - TYPE: {piece.Type}, ID_PICTURE: {piece.IdPicture}, ID_PIECE: {piece.IdPiece}");

        _ownedPieces.Add(piece);
    }

    private void RemoveOwnedPiece(ChickenPicturePiece piece)
    {
        if(_ownedPieces.Contains(piece))
           _ownedPieces.Remove(piece);
    }

    #region OUTPUT

    public event Action<ChickenPicturePiece> OnAddPiece;
    public event Action<ChickenPicturePiece> OnRemovePiece;

    #endregion
}
