using TMPro;
using UnityEngine;

public class TimerView_Numeric : View, ITimerView, IIdentify
{
    [SerializeField] private string id;
    [SerializeField] private TextMeshProUGUI textCount;

    public string GetID() => id;

    public void ChangeTime(int sec)
    {
        textCount.text = sec.ToString();
    }

    public void ActivateTimer()
    {
        textCount.gameObject.SetActive(true);
    }

    public void DeactivateTimer()
    {
        textCount.gameObject.SetActive(false);
    }
}
