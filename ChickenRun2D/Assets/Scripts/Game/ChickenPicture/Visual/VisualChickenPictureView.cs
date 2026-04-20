using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualChickenPictureView : View
{
    [SerializeField] private ChickenPictureButtons chickenPictureButtons;

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

    #region Output

    public event Action<ChickenType> OnChooseType;

    private void ChooseType(ChickenType type)
    {
        OnChooseType?.Invoke(type);
    }

    #endregion
}

#region Visual

public class VisualChickenPicture // сама картина
{
    [SerializeField] private List<VisualChickenPicturePiece> picturePieces = new();
}

public class VisualChickenPicturePiece
{
    [SerializeField] private Image imagePiece;
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
