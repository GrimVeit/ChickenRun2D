using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChickenRaceTest : MonoBehaviour
{
    public RectTransform racePanel;
    public List<RectTransform> chickens = new List<RectTransform>();
    public RectTransform pointFinish;
    public float screenCenterX = 500f;
    public float followSpped = 5f;

    public float mimSpeed = 50;
    public float maxSpeed = 150;

    private Dictionary<RectTransform, float> chickenSpeed = new Dictionary<RectTransform, float>();

    private void Start()
    {
        foreach(var c in chickens)
        {
            chickenSpeed[c] = Random.Range(mimSpeed, maxSpeed);
        }
    }

    private void Update()
    {
        if(chickens.Count == 0) return;

        foreach (var c in chickens)
        {
            float speed = chickenSpeed[c];

            c.localPosition += speed * Time.deltaTime * Vector3.right;
        }

        var leader = chickens.OrderByDescending(c => c.localPosition.x).First();

        Vector3 leaderLocalPos = leader.localPosition;
        Vector3 desiredOffset = new Vector3(screenCenterX - leaderLocalPos.x, 0, 0);
        racePanel.localPosition = Vector3.Lerp(racePanel.localPosition, desiredOffset, Time.deltaTime * followSpped);

        foreach (var c in chickens)
        {
            if(c.localPosition.x >= pointFinish.localPosition.x)
            {
                Debug.Log("!!! FINISH !!!");
                chickenSpeed[c] = 0;
            }
        }
    }
}
