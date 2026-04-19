using System;

public class StoreChickenPicturePresenter : IStoreChickenPictureListener, IStoreChickenPictureProvider
{
    private readonly StoreChickenPictureModel _model;

    public StoreChickenPicturePresenter(StoreChickenPictureModel model)
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

    public event Action<ChickenPieceDTO> OnPieceOpened
    {
        add => _model.OnPieceOpened += value;
        remove => _model.OnPieceOpened -= value;
    }

    public event Action OnAllOpened
    {
        add => _model.OnAllOpened += value;
        remove => _model.OnAllOpened -= value;
    }

    #endregion

    #region Input

    public ChickenPicturesDTO GetPicturesDTOByType(ChickenType type) => _model.GetPicturesDTOByType(type);
    public ChickenPieceDTO GetRandomAvailablePiece() => _model.GetRandomAvailablePiece();
    public void OpenPiece(ChickenType type, string pictureId, int pieceId) => _model.OpenPiece(type, pictureId, pieceId);

    #endregion
}

public interface IStoreChickenPictureListener
{
    public event Action<ChickenPieceDTO> OnPieceOpened;

    public event Action OnAllOpened;
}

public interface IStoreChickenPictureProvider
{
    public ChickenPicturesDTO GetPicturesDTOByType(ChickenType type);
    public ChickenPieceDTO GetRandomAvailablePiece();
    public void OpenPiece(ChickenType type, string pictureId, int pieceId);
}
