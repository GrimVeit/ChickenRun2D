using System;

public class TimerPresenter : ITimerProvider, ITimerListener
{
    private readonly TimerModel timerModel;
    private readonly ITimerView timerView;

    public TimerPresenter(TimerModel timerModel, ITimerView timerView)
    {
        this.timerModel = timerModel;
        this.timerView = timerView;
    }

    public void Initialize()
    {
        ActivateEvents();
    }

    public void Dispose()
    {
        DeactivateEvents();
    }

    private void ActivateEvents()
    {
        timerModel.OnActivateTimer += timerView.ActivateTimer;
        timerModel.OnDeactivateTimer += timerView.DeactivateTimer;

        timerModel.OnTimeChanged += timerView.ChangeTime;
    }

    private void DeactivateEvents()
    {
        timerModel.OnActivateTimer -= timerView.ActivateTimer;
        timerModel.OnDeactivateTimer -= timerView.DeactivateTimer;

        timerModel.OnTimeChanged -= timerView.ChangeTime;
    }

    public void ActivateTimer(int seconds, TimerDirection direction)
    {
        timerModel.ActivateTimer(seconds, direction);
    }

    public void DeactivateTimer()
    {
        timerModel.DeactivateTimer();
    }

    public void ResetTimer()
    {
        timerModel.ResetTimer();
    }

    public event Action OnStopTimer
    {
        add { timerModel.OnStopTimer += value; }
        remove { timerModel.OnStopTimer -= value; }
    }
}

public interface ITimerView
{
    void ChangeTime(int sec);
    void ActivateTimer();
    void DeactivateTimer();
}

public interface ITimerProvider
{
    void ActivateTimer(int seconds, TimerDirection direction);
    void DeactivateTimer();
    void ResetTimer();
}

public interface ITimerListener
{
    public event Action OnStopTimer;
}
