using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeatingSystem : MonoBehaviour
{
    public int MaxHeat;
    public int CurrentHeat;
    public int DecreaseRate;
    public bool NearHeatSource;
    public float TimeBetweenEvent;
    public float Timer;
    public ProgressBar HeatBar;

    private void Start()
    {
        Timer = TimeBetweenEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if(NearHeatSource)
        {
            Debug.Log("Not decrementing the counter for cold meter.");
        }
        else
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                CurrentHeat -= DecreaseRate;
                HeatBar.SetCurrentFill(CurrentHeat);
                Timer = TimeBetweenEvent;
            }
        }
    }
    public void ApplyHeat(int HeatValue)
    {
        if (CurrentHeat < MaxHeat)
        {
            if(CurrentHeat + HeatValue > MaxHeat)
            {
                CurrentHeat = MaxHeat;
            }
            else
            {
                CurrentHeat += HeatValue;
            }
        }

        HeatBar.SetCurrentFill(CurrentHeat);

    }

}
