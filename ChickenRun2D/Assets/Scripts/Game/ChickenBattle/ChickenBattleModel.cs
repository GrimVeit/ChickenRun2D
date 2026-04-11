using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Unity.VisualScripting;

public class ChickenBattleModel
{
    private readonly ISpawnerChickenListener _spawnerChickenListener;
    private List<IChickenUnit> _chickens = new();

    private readonly System.Random _random = new();

    private IEnumerator _eventsCoroutine;

    private readonly HashSet<IChickenUnit> _finished = new();

    public ChickenBattleModel(ISpawnerChickenListener spawnerChickenListener)
    {
        _spawnerChickenListener = spawnerChickenListener;
        _spawnerChickenListener.OnSpawnChickens += SetChickens;
    }

    public void Dispose()
    {
        _spawnerChickenListener.OnSpawnChickens -= SetChickens;
        Clear();
    }

    public void StartGame()
    {
        for (int i = 0; i < _chickens.Count; i++)
        {
            if (_chickens[i] == null) continue;

            _chickens[i].SetRun();
        }

        StartEventsLoop();
    }

    private void SetChickens(List<IChickenUnit> chickens)
    {
        Clear();

        _chickens = chickens;
        _finished.Clear();

        for (int i = 0; i < _chickens.Count; i++)
        {
            if (_chickens[i] == null) continue;

            _chickens[i].OnEndMove += EndMove;
        }
    }

    private void EndMove(IChickenUnit chicken)
    {
        if (chicken == null)
            return;

        // 🔥 уже финишировал — игнор
        if (_finished.Contains(chicken))
            return;

        _finished.Add(chicken);

        chicken.OnEndMove -= EndMove;
        chicken.SetIdle();
    }

    private void StartEventsLoop()
    {
        if (_eventsCoroutine != null)
            return;

        _eventsCoroutine = EventsLoop();
        Coroutines.Start(_eventsCoroutine);
    }

    private IEnumerator EventsLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(_random.Next(800, 2500) / 1000f);

            if (_chickens.Count == 0)
                continue;

            var chicken = _chickens[_random.Next(_chickens.Count)];

            // 🔥 КЛЮЧЕВОЕ ИСПРАВЛЕНИЕ
            if (chicken == null)
                continue;

            if (_finished.Contains(chicken))
                continue;

            TriggerRandomEvent(chicken);
        }
    }

    private void TriggerRandomEvent(IChickenUnit chicken)
    {
        // 🔥 двойная защита (важно)
        if (_finished.Contains(chicken))
            return;

        if (_random.Next(0, 100) < 50)
            chicken.ActivateGoodState();
        else
            chicken.ActivateBadState();
    }

    private void Clear()
    {
        if (_eventsCoroutine != null)
        {
            Coroutines.Stop(_eventsCoroutine);
            _eventsCoroutine = null;
        }

        for (int i = 0; i < _chickens.Count; i++)
        {
            if (_chickens[i] != null)
                _chickens[i].OnEndMove -= EndMove;
        }

        _chickens.Clear();
        _finished.Clear();
    }
}
