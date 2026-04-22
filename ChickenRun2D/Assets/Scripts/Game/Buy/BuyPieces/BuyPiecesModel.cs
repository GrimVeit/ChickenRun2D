using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPiecesModel
{
    private readonly IStoreChickenPictureProvider _storeChickenPictureProvider;

    public BuyPiecesModel(IStoreChickenPictureProvider storeChickenPictureProvider)
    {
        _storeChickenPictureProvider = storeChickenPictureProvider;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void GeneratePieces()
    {
        var count = UnityEngine.Random.Range(3, 6);

        var list = new List<ChickenPicturePiece>();

        for (int i = 0; i < count; i++)
        {
            list.Add(_storeChickenPictureProvider.GetRandomAvailablePiece());
        }

        if(list.Count == 0)
        {
            //BRANCH
        }

        OnSetPieces?.Invoke(list);
    }

    public void OwnedPiece(ChickenPicturePiece piece)
    {
        _storeChickenPictureProvider.OwnedPiece(piece.Type, piece.IdPicture, piece.IdPiece);
    }

    #region Output

    public event Action<List<ChickenPicturePiece>> OnSetPieces;

    #endregion
}
