using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPiecesView : View
{
    [SerializeField] private VisualBuyPiece piecePrefab;
    [SerializeField] private Transform transformSpawn;
    [SerializeField] private RectTransform transformShowPos;

    [SerializeField] private List<VisualBuyPiece> pieceList;

    private IEnumerator showCoro;

    public void SetPieces(List<ChickenPicturePiece> pieces)
    {
        for (int i = 0; i < pieceList.Count; i++)
        {
            Destroy(pieceList[i].gameObject);
        }

        pieceList.Clear();

        for (int i = 0; i < pieces.Count; i++)
        {
            var piece = Instantiate(piecePrefab, transformSpawn);
            piece.transform.localPosition = new Vector3(0, -500, 0);
            piece.SetData(pieces[i].Sprite);
            piece.SetSize(pieces[i].Sprite.rect.size / 4);

            pieceList.Add(piece);
        }
    }

    public void Show()
    {
        if(showCoro != null) Coroutines.Stop(showCoro);

        showCoro = ShowCoro();
        Coroutines.Start(showCoro);
    }

    private IEnumerator ShowCoro()
    {
        for (int i = 0; i < pieceList.Count; i++)
        {
            float timeAwait = Random.Range(0.4f, 1);

            pieceList[i].MoveTo(GetRandomPointInRect(transformShowPos), timeAwait);

            yield return new WaitForSeconds(timeAwait);
        }
    }

    private Vector2 GetRandomPointInRect(RectTransform rectTransform)
    {
        Rect rect = rectTransform.rect;

        float x = Random.Range(rect.xMin, rect.xMax);
        float y = Random.Range(rect.yMin, rect.yMax);

        return new Vector2(x, y);
    }
}
