using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualChickenPictureModel
{
    private readonly IStoreChickenPictureListener _storeChickenPictureListener;

    private ChickenType _currentType = ChickenType.None;

    public VisualChickenPictureModel(IStoreChickenPictureListener storeChickenPictureListener)
    {
        _storeChickenPictureListener = storeChickenPictureListener;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {

    }

    public void GetPicturesByType(ChickenType type)
    {
        _currentType = type;
    }

    #region Output

    public event Action OnGetPictures;
    public event Action<ChickenPieceDTO> OnGetPictures_Value;

    #endregion
}
