using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerChickenView : View
{
    [SerializeField] private ChickenUnitView chickenUnitView_Prefab;
    [SerializeField] private Transform transformSpawnParent;
    [SerializeField] private List<Transform> transformsSpawn = new();
    [SerializeField] private Transform transformTarget;

    private Dictionary<ChickenType, string> chickenSkins = new Dictionary<ChickenType, string>()
    {
        { ChickenType.Alien, "chicken_ alien" },
        { ChickenType.Yellow, "chicken_ yellow" },
        { ChickenType.Blue, "chicken_blue" },
        { ChickenType.Business, "chicken_business" },
        { ChickenType.Cowboy, "chicken_cowboy" },
        { ChickenType.Gold, "chicken_gold" },
        { ChickenType.Red, "chicken_red" },
        { ChickenType.Samurai, "chicken_samurai" },
        { ChickenType.White, "chicken_white" },
        { ChickenType.Zombie, "chicken_zombie" }
    };

    private readonly Dictionary<IChickenUnit, ChickenUnitView> _chickenUnits = new();

    public void Initialize()
    {

    }

    public void Dispose()
    {
        Clear();
    }

    private string GetSkinName(ChickenType type)
    {
        if (chickenSkins.TryGetValue(type, out string skinName))
        {
            return skinName;
        }

        return "chicken_samurai";
    }

    public void SetTypes(List<ChickenType> types)
    {
        Debug.Log("Types: " + string.Join(", ", types));

        Clear();

        for (int i = 0; i < Mathf.Min(types.Count, transformsSpawn.Count); i++)
        {
            var spawnPoint = transformsSpawn[i];
            var type = types[i];

            var newChicken = Instantiate(chickenUnitView_Prefab, transformSpawnParent);
            newChicken.transform.localPosition = spawnPoint.localPosition;
            newChicken.SetSkin(GetSkinName(type));
            newChicken.SetTarget(transformTarget.localPosition);

            var presenter = new ChickenUnitPresenter(new ChickenUnitModel(), newChicken);
            presenter.Initialize();

            _chickenUnits.Add(presenter, newChicken);
        }

        OnSpawnChickens?.Invoke(new List<IChickenUnit>(_chickenUnits.Keys.ToList()));
    }

    private void Clear()
    {
        if (_chickenUnits.Count != 0)
        {
            foreach (var chicken in _chickenUnits)
            {
                chicken.Key.Dispose();
                Destroy(chicken.Value.gameObject);
            }
            _chickenUnits.Clear();
        }
    }

    #region Output

    public event Action<List<IChickenUnit>> OnSpawnChickens;

    #endregion
}
