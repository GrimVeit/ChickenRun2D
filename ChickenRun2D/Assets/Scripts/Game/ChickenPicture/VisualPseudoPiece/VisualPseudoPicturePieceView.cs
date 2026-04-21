using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisualPseudoPicturePieceView : View
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private VisualPseudoPicturePiece pseudoPiecePrefab;
    [SerializeField] private RectTransform pseudoPiecesParent;

    private List<VisualPseudoPicturePiece> _pseudoPieces = new();
    private VisualPseudoPicturePiece _currentPseudoChip;

    public void AddPiece(ChickenPicturePiece piece)
    {
        var pseudoPiece = Instantiate(pseudoPiecePrefab, pseudoPiecesParent);

        var pos = GetRandomPointInRect(pseudoPiecesParent);
        pseudoPiece.SetMainPos(pos);
        pseudoPiece.transform.localPosition = pos;

        pseudoPiece.OnGrabbing += GrabPseudoPiece;
        pseudoPiece.Initialize();

        var size = new Vector2(piece.Sprite.rect.width, piece.Sprite.rect.height) / 7.2f;

        pseudoPiece.SetSize(size);
        pseudoPiece.SetData(piece);
    }

    public void RemovePiece(ChickenPicturePiece piece)
    {
        var pseudoPiece = GetPseudoPicturePiece(piece);

        if (pseudoPiece == null) return;

        _pseudoPieces.Remove(pseudoPiece);

        pseudoPiece.OnGrabbing -= GrabPseudoPiece;
        pseudoPiece.OnStartMove -= StartMove;
        pseudoPiece.OnMove -= Move;
        pseudoPiece.OnEndMove -= EndMove;

        pseudoPiece.Dispose();

        Destroy(pseudoPiece.gameObject);
    }

    private VisualPseudoPicturePiece GetPseudoPicturePiece(ChickenPicturePiece piece)
    {
        return _pseudoPieces.FirstOrDefault(data => data.Data == piece);
    }

    #region GRAB/UNGRAB

    public void GrabPseudoPiece(VisualPseudoPicturePiece data)
    {
        UngrabPseudoPiece();

        _currentPseudoChip = data;

        _currentPseudoChip.OnStartMove += StartMove;
        _currentPseudoChip.OnMove += Move;
        _currentPseudoChip.OnEndMove += EndMove;
    }

    public void UngrabPseudoPiece()
    {
        if (_currentPseudoChip != null)
        {
            _currentPseudoChip.OnStartMove -= StartMove;
            _currentPseudoChip.OnMove -= Move;
            _currentPseudoChip.OnEndMove -= EndMove;

            _currentPseudoChip.Teleport();
        }
    }

    #endregion

    #region MOVE

    public void StartMove()
    {
        _currentPseudoChip.StartMove();
    }

    public void Move(Vector2 vector)
    {
        _currentPseudoChip.Move(vector / canvas.scaleFactor);
    }

    public void EndMove(VisualPseudoPicturePiece piece, RectTransform rectTransform)
    {
        if (IsInsideParent(pseudoPiecesParent, rectTransform))
        {
            Debug.Log("Внутри родителя (локально)");

            _currentPseudoChip.SetMainPos(rectTransform.anchoredPosition);
            _currentPseudoChip.EndMove();
        }
        else
        {
            _currentPseudoChip.EndMove();
        }
    }

    #endregion

    private Vector2 GetRandomPointInRect(RectTransform rectTransform)
    {
        Rect rect = rectTransform.rect;

        float x = UnityEngine.Random.Range(rect.xMin, rect.xMax);
        float y = UnityEngine.Random.Range(rect.yMin, rect.yMax);

        return new Vector2(x, y);
    }

    private bool IsInsideParent(RectTransform parent, RectTransform child)
    {
        Vector2 pos = child.anchoredPosition;
        Rect rect = parent.rect;

        return pos.x >= rect.xMin && pos.x <= rect.xMax &&
               pos.y >= rect.yMin && pos.y <= rect.yMax;
    }
}
