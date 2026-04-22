using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class VisualBuyPiece : MonoBehaviour
{
    [SerializeField] private Image imagePiece;

    public void SetData(Sprite sprite)
    {
        imagePiece.sprite = sprite;
    }

    public void Destroy()
    {
        OnDestroy?.Invoke();
    }

    public void SetSize(Vector2 size)
    {
        imagePiece.rectTransform.sizeDelta = size;
    }

    public void MoveTo(Vector2 pos, float duration)
    {
        transform.DOLocalMove(pos, duration);
    }

    #region Output

    public event Action OnDestroy;

    #endregion
}
