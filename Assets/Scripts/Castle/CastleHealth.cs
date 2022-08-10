using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour,IHealthable
{
    [Header("Unity Stuff")]
    public Image healtBar;
    public int healt = 100;

    public GameObject deathEffect;
   


    public void TakeDamage(int amount)
    {
        healt -= amount;
        healtBar.fillAmount = healt / 100f;
        if (healt <= 0)
        {
            
            Die();
        }
    }
    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        this.gameObject.tag = "Untagged";
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

}
[System.Serializable]
public struct Health
{
    [SerializeField]private int maxValue;
    public int currentValue { get; private set; }

    public void Start()
    {
        currentValue = maxValue;
    }
    

    public Health TakeDamage(int value) 
    {
        currentValue = Mathf.Clamp(currentValue-value,0,maxValue);

        return this;
    }
    public bool isFinished
    {
        get
        {
            return currentValue <= 0;
        }
    }
}
