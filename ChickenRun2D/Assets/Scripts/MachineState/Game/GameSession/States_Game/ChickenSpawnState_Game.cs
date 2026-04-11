using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawnState_Game : IState
{
    private readonly IStateMachineProvider _machineProvider;
    private readonly ISpawnerChickenProvider _spawnerChickenProvider;
    private readonly IChooseChickenProvider _chooseChickenProvider;
    private readonly IStoreChickenProvider _storeChickenProvider;

    private IEnumerator timer;

    public ChickenSpawnState_Game(IStateMachineProvider machineProvider, ISpawnerChickenProvider spawnerChickenProvider, IChooseChickenProvider chooseChickenProvider, IStoreChickenProvider storeChickenProvider)
    {
        _machineProvider = machineProvider;
        _spawnerChickenProvider = spawnerChickenProvider;
        _chooseChickenProvider = chooseChickenProvider;
        _storeChickenProvider = storeChickenProvider;
    }

    public void EnterState()
    {
        _storeChickenProvider.ChooseChickens();
        _spawnerChickenProvider.SpawnChickens();

        if(timer != null) Coroutines.Stop(timer);

        timer = Timer();
        Coroutines.Start(timer);
    }

    public void ExitState()
    {
        if (timer != null) Coroutines.Stop(timer);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);

        _chooseChickenProvider.ShowAll();

        yield return new WaitForSeconds(1.5f);

        ChangeStateToChooseChicken();
    }

    private void ChangeStateToChooseChicken()
    {
        _machineProvider.EnterState(_machineProvider.GetState<ChooseChickenState_Game>());
    }
}
