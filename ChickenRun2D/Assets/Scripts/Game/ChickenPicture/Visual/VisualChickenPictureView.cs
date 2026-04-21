using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualChickenPictureView : View
{
    [SerializeField] private ChickenPictureButtons chickenPictureButtons;
    [SerializeField] private List<VisualChickenPicture> chickenPictureList;
    [SerializeField] private List<PictureDropZone> dropZones;

    public void Initialize()
    {
        chickenPictureButtons.OnChooseType += ChooseType;
        chickenPictureButtons.Initialize();
    }

    public void Dispose()
    {
        chickenPictureButtons.OnChooseType -= ChooseType;
        chickenPictureButtons.Dispose();
    }

    public void Clear()
    {
        chickenPictureList.ForEach(cp => cp.Clear());
    }

    public void SetType(ChickenType Type)
    {
        dropZones.ForEach(cp => cp.SetType(Type));
    }

    public void UpdatePiece(ChickenPicturePiece dto)
    {
        var index = dto.IdPicture;

        Debug.Log("ID Picture - " + dto.IdPicture);

        chickenPictureList[index].UpdatePiece(dto);
    }

    #region Output

    public event Action<ChickenType> OnChooseType;

    private void ChooseType(ChickenType type)
    {
        OnChooseType?.Invoke(type);
    }

    #endregion
}

#region Visual

[Serializable]
public class VisualChickenPicture
{
    [SerializeField] private string name;
    [SerializeField] private List<VisualChickenPicturePiece> picturePieces = new();
    [SerializeField] private PieceLayout pieceLayout;

    

    public void Clear()
    {
        picturePieces.ForEach(pp => pp.Clear());
    }

    public void UpdatePiece(ChickenPicturePiece dto)
    {
        var layout = pieceLayout.GetLayoutByTypeId(dto.Type, dto.IdPiece);

        if(layout == null)
        {
            Debug.LogError("Not found PieceLayout with Type - " + dto.Type);
            return;
        }

        picturePieces[dto.IdPiece].SetSprite(dto.Sprite);
        picturePieces[dto.IdPiece].SetPosSize(layout.Position, layout.Size);
    }

    [Serializable]
    private class PieceLayout
    {
        [SerializeField] List<TypeLayout> layouts = new();

        public Layout GetLayoutByTypeId(ChickenType type, int index)
        {
            return layouts.Find(l => l.Type == type).Layouts[index];
        }

        [Serializable]
        private class TypeLayout
        {
            public ChickenType Type => type;
            public List<Layout> Layouts => layouts;

            [SerializeField] private string name;
            [SerializeField] private ChickenType type;
            [SerializeField] private List<Layout> layouts;


        }

        [Serializable]
        public class Layout
        {
            [SerializeField] private Vector2 position;
            [SerializeField] private Vector2 size;

            public Vector2 Position => position;
            public Vector2 Size => size;
        }
    }
}

[Serializable]
public class VisualChickenPicturePiece
{
    [SerializeField] private Image imagePiece;

    public void Clear()
    {
        imagePiece.sprite = null;
        imagePiece.rectTransform.sizeDelta = Vector2.zero;
    }

    public void SetSprite(Sprite sprite)
    {
        imagePiece.sprite = sprite;
    }

    public void SetPosSize(Vector3 localPos, Vector3 size)
    {
        imagePiece.rectTransform.localPosition = localPos;
        imagePiece.rectTransform.sizeDelta = size;
    }
}

#endregion

#region BUTTONS

[Serializable]
public class ChickenPictureButtons
{
    [SerializeField] private List<ChickenPictureButton> chickenPictureButtons = new();

    public void Initialize()
    {
        for (int i = 0; i < chickenPictureButtons.Count; i++)
        {
            chickenPictureButtons[i].OnChooseType += ChooseType;
            chickenPictureButtons[i].Initialize();
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < chickenPictureButtons.Count; i++)
        {
            chickenPictureButtons[i].OnChooseType -= ChooseType;
            chickenPictureButtons[i].Dispose();
        }
    }

    #region Output

    public event Action<ChickenType> OnChooseType;

    private void ChooseType(ChickenType type)
    {
        OnChooseType?.Invoke(type);
    }

    #endregion
}

[Serializable]
public class ChickenPictureButton
{
    [SerializeField] private ChickenType chickenType;
    [SerializeField] private Button buttonType;

    public void Initialize()
    {
        buttonType.onClick.AddListener(ChooseType);
    }

    public void Dispose()
    {
        buttonType.onClick.RemoveListener(ChooseType);
    }

    #region Output

    public event Action<ChickenType> OnChooseType;

    private void ChooseType()
    {
        OnChooseType?.Invoke(chickenType);
    }

    #endregion
}

#endregion
