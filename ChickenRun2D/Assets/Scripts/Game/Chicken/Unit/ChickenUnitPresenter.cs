using System;

public class ChickenUnitPresenter : IChickenUnit
{
    private readonly ChickenUnitModel _model;
    private readonly ChickenUnitView _view;

    private readonly ChickenStateMachine _stateMachine;

    public ChickenUnitPresenter(ChickenUnitModel model, ChickenUnitView view)
    {
        _model = model;
        _view = view;

        _stateMachine = new ChickenStateMachine(_model);
    }

    public void Initialize()
    {
        ActivateEvents();

        _view.Initialize();
        _stateMachine.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        _view.Dispose();
        _stateMachine.Dispose();
    }

    private void ActivateEvents()
    {
        _view.OnEndMove += _model.EndMove;
        _model.OnEndMove += EndMove;

        _model.OnShow += _view.Show;
        _model.OnHide += _view.Hide;
        _model.OnActivateAnimation += _view.ActivateAnimation;

        _model.OnStartMove += _view.StartMove;
        _model.OnStopMove += _view.StopMove;
        _model.OnSetSpeed += _view.SetSpeed;
        _model.OnSetSpeed_Smooth += _view.SetSpeed;
    }

    private void DeactivateEvents()
    {
        _view.OnEndMove -= _model.EndMove;
        _model.OnEndMove -= EndMove;

        _model.OnShow -= _view.Show;
        _model.OnHide -= _view.Hide;
        _model.OnActivateAnimation -= _view.ActivateAnimation;

        _model.OnStartMove -= _view.StartMove;
        _model.OnStopMove -= _view.StopMove;
        _model.OnSetSpeed -= _view.SetSpeed;
        _model.OnSetSpeed_Smooth -= _view.SetSpeed;
    }

    #region Input

    public void ActivateGoodState() => _stateMachine.ActivateGoodState();
    public void ActivateBadState() => _stateMachine.ActivateBadState();
    public void SetRun() => _stateMachine.SetRun();
    public void SetIdle() => _stateMachine.SetIdle();

    #endregion

    #region Output

    public event Action<IChickenUnit> OnEndMove;

    private void EndMove()
    {
        OnEndMove?.Invoke(this);
    }

    #endregion
}

public interface IChickenUnit
{
    public void Initialize();
    public void Dispose();

    public void ActivateGoodState();
    public void ActivateBadState();
    public void SetRun();
    public void SetIdle();

    public event Action<IChickenUnit> OnEndMove;
}
