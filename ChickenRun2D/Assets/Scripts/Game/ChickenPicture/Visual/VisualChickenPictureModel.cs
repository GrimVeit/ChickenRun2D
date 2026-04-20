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

        var snapshot = _store.GetPicturesDTOByType(type);

        foreach (var pic in snapshot.Pictures)
            foreach (var piece in pic.Pieces)
                OnPieceUpdate?.Invoke(piece);

        OnSelectType?.Invoke();
    }

    private void HandlePiece(ChickenPieceDTO dto)
    {
        if (dto.Type != _currentType) return;

        OnPieceUpdate?.Invoke(dto);
    }

    #region Output

    public event Action<ChickenPieceDTO> OnPieceUpdate;
    public event Action OnSelectType;

    #endregion
}
