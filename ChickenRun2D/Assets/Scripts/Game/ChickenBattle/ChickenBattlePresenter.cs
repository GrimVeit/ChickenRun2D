using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBattlePresenter : IChickenBattleProvider
{
    private readonly ChickenBattleModel _model;

    public ChickenBattlePresenter(ChickenBattleModel model)
    {
        _model = model;
    }

    public void Initialize()
    {

    }

    public void Dispose()
    {
        _model.Dispose();
    }

    #region Input

    public void StartGame() => _model.StartGame();

    #endregion
}

public interface IChickenBattleProvider
{
    void StartGame();
}
