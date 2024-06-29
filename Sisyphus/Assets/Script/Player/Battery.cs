using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    private const float consumeRate = 1f;
    private const float consumeInterval = 0.1f;
    public List<ExtraBattery> batteries = new();
    public float basicBattery = 1000;
    public float TotalBattery
    {
        get
        {
            float battery = basicBattery;
            foreach (ExtraBattery b in batteries)
            {
                battery += b.batteryBonus;
            }
            return battery;
        }
    }
    public float fullBattery = 1000;

    public Image batteryBar;

    public GameObject deathPanel;

    private void Start()
    {
        StartCoroutine(TimeCountdown());
    }

    private void FixedUpdate()
    {
        if (basicBattery > 0)
        {
            BarFiller();
        }
        else
        {
            PlayerPrefs.SetInt("Dead", 1);
            deathPanel.SetActive(true);
        }
    }

    IEnumerator TimeCountdown()
    {
        while (basicBattery > 0)
        {
            if (batteries.Count > 0)
            {
                if (batteries[0].batteryBonus >= consumeRate)
                {
                    batteries[0].batteryBonus -= consumeRate;
                    yield return new WaitForSeconds(consumeInterval);
                    continue;
                }
                else
                {
                    batteries.RemoveAt(0);
                    continue;
                }
            }
            else
                basicBattery -= consumeRate;
            yield return new WaitForSeconds(consumeInterval);
        }
    }

    void BarFiller()
    {
        batteryBar.fillAmount = TotalBattery / fullBattery;
    }

    public void ChangeBattery(float value)
    {
        if (value > 0)
        {
            if (basicBattery + value > 1000)
            {
                value -= 1000 - basicBattery;
                basicBattery = 1000;
                int i = -1;
                while (batteries.Count > 0 && value > 0)
                {
                    try
                    {
                        i++;
                        if (batteries[i].batteryBonus + value > batteries[i].maxbattery)
                        {
                            value -= batteries[i].maxbattery - batteries[i].batteryBonus;
                            batteries[i].batteryBonus = batteries[i].maxbattery;
                            continue;
                        }
                        else
                        {
                            batteries[i].batteryBonus += value;
                            value = 0;
                        }
                    }
                    catch 
                    {
                        Debug.Log($"??????????????????,i = {i},batteries.Count = {batteries.Count}");
                    }
                }
            }
            else
                basicBattery += value;
        }
        else
        {
            int i = -1;
            while (batteries.Count > 0 && value < 0)
            {
                i++;
                if (batteries[i].batteryBonus + value > 0)
                {
                    value = 0;
                    batteries[i].batteryBonus -= value;
                }
                else
                {
                    value -= batteries[i].batteryBonus;
                    batteries[i].batteryBonus = 0;
                    batteries.RemoveAt(0);
                    continue;
                }
            }
            basicBattery -= value;
        }
    }

}
