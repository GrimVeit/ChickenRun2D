using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChickenView : View
{
    [SerializeField] private ChickenUnitView chickenUnitView_Prefab;
    [SerializeField] private Transform transformSpawnParent;
    [SerializeField] private List<Transform> transformsSpawn = new();

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

    private readonly List<ChickenUnitView> chickenUnitViews = new();

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

        if (chickenUnitViews != null)
        {
            foreach (var chicken in chickenUnitViews)
            {
                if (chicken != null)
                    Destroy(chicken.gameObject);
            }
            chickenUnitViews.Clear();
        }

        for (int i = 0; i < Mathf.Min(types.Count, transformsSpawn.Count); i++)
        {
            var spawnPoint = transformsSpawn[i];
            var type = types[i];

            Debug.Log("Types: " + string.Join(", ", types));

            var newChicken = Instantiate(chickenUnitView_Prefab, transformSpawnParent);
            newChicken.transform.localPosition = spawnPoint.localPosition;
            newChicken.Animation.SetSkin(GetSkinName(type));

            chickenUnitViews.Add(newChicken);
        }
    }
}
