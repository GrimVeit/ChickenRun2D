using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreChickenPicturePiecePresenter
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
}
