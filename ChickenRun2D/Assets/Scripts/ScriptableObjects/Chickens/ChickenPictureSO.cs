using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChickenPictureSO
{
    [SerializeField] private string id;
    [SerializeField] private List<Sprite> pieces;

    public string Id => id;
    public List<Sprite> Pieces => pieces;
}
