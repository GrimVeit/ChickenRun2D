using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAllPictures
{
    public readonly List<AllChickenPictures> chickenTypePictures = new();

    public ChickenAllPictures(ChickenAllPicturesSO chickenAllPicturesSO)
    {
        for (int i = 0; i < chickenAllPicturesSO.TypePictures.Count; i++) 
        { 
            var listPictures = new List<ChickenPictures>();

            for (int j = 0; j < chickenAllPicturesSO.TypePictures[i].Pictures.Count; j++)
            {
                var listPieces = new List<ChickenPicturePiece>();

                for (int k = 0; k < chickenAllPicturesSO.TypePictures[i].Pictures[j].Pieces.Count; k++)
                {
                    ChickenPicturePiece piece = new(k, chickenAllPicturesSO.TypePictures[i].Pictures[j].Pieces[k]);
                    listPieces.Add(piece);
                }

                listPictures.Add(new ChickenPictures(chickenAllPicturesSO.TypePictures[i].Pictures[j].Id, listPieces));
            }

            chickenTypePictures.Add(new AllChickenPictures(chickenAllPicturesSO.TypePictures[i].Type, listPictures));
        }
    }
}

public class AllChickenPictures
{
    private readonly ChickenType _type;
    private readonly List<ChickenPictures> _pictures;

    public AllChickenPictures(ChickenType type, List<ChickenPictures> pictures)
    {
        _type = type;
        _pictures = pictures;
    }

    public ChickenType Type => _type;
    public List<ChickenPictures> Pictures => _pictures;
}

public class ChickenPictures
{
    [SerializeField] private string _id;
    [SerializeField] private List<ChickenPicturePiece> _pieces;

    public ChickenPictures(string id, List<ChickenPicturePiece> pieces)
    {
        _id = id;
        _pieces = pieces;
    }

    public string Id => _id;
    public List<ChickenPicturePiece> Pieces => _pieces;
}

public class ChickenPicturePiece
{
    private readonly int _id;
    private readonly Sprite _piece;
    private bool isOpen = false;

    public ChickenPicturePiece(int id, Sprite piece)
    {
        _id = id;
        _piece = piece;
    }

    public void Open()
    {
        isOpen = true;
    }

    public int IdPiece => _id;
    public Sprite Sprite => _piece;
    public bool IsOpen => isOpen;
}
