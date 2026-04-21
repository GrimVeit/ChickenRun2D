using System;

public class VisualChickenPictureModel
{
    private readonly IStoreChickenPictureProvider _store;
    private readonly IStoreChickenPictureListener _listener;

    private ChickenType _currentType;

    public VisualChickenPictureModel(
        IStoreChickenPictureProvider store,
        IStoreChickenPictureListener listener)
    {
        _store = store;
        _listener = listener;
    }

    public void Initialize()
    {
        _listener.OnPieceOpened += HandlePiece;
    }

    public void Dispose()
    {
        _listener.OnPieceOpened -= HandlePiece;
    }

    public void GetPicturesByType(ChickenType type)
    {
        _currentType = type;

        var snapshot = _store.GetPicturesByType(type);

        OnClear?.Invoke();

        OnSetType?.Invoke(type);

        foreach (var pic in snapshot.Pictures)
            foreach (var piece in pic.Pieces)
            {
                if(piece.IsOpen)
                    OnPieceUpdate?.Invoke(piece);
            }

        OnSelectType?.Invoke();
    }

    private void HandlePiece(ChickenPicturePiece dto)
    {
        if (dto.Type != _currentType) return;

        OnPieceUpdate?.Invoke(dto);
    }

    #region Output

    public event Action<ChickenType> OnSetType;
    public event Action OnClear;
    public event Action<ChickenPicturePiece> OnPieceUpdate;
    public event Action OnSelectType;

    #endregion
}
