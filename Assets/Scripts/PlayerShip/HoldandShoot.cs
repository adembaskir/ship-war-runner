using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldandShoot : MonoBehaviour
{
    public Canon cannonScript;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject powerBarGO;
    public Image PowerBarMask;
    public float barChangeSpeed = 1;
    float maxPowerBarValue = 100;
    float currentPowerBarValue;
    bool powerIsIncreasing;
    bool PowerBarON; 
    private void Start()
    {
        cannonScript.GetComponent<Canon>();
        currentPowerBarValue = 0;
        powerIsIncreasing = true;
        PowerBarON = true;
        StartCoroutine(UpdatePowerBar());
    }
    IEnumerator UpdatePowerBar()
    {
        while (PowerBarON)
        {
            if (!powerIsIncreasing)
            {
                currentPowerBarValue -= barChangeSpeed;
                if (currentPowerBarValue <= 0)
                {
                    powerIsIncreasing = true;
                }
            }
            if (powerIsIncreasing)
            {
                currentPowerBarValue += barChangeSpeed;
                if (currentPowerBarValue >= maxPowerBarValue)
                {
                    powerIsIncreasing = false;
                }
            }

            float fill = currentPowerBarValue / maxPowerBarValue;
            PowerBarMask.fillAmount = fill;
            yield return new WaitForSeconds(0.02f);

            if (Input.touchCount > 0)
            {
                PowerBarON = false;               
                yield return new WaitForSeconds(0.5f);
                PowerBarON = true;
            }
        }
        yield return null;
    }

}
