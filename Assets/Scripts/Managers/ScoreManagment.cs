using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManagment : MonoBehaviour
{
    public static ScoreManagment instance;
    public int score;
    public int currentValue;
    public Text scoreText;
    public Image levelImage;
    public int maxLevelExp = 100;
    public GameObject currentShip;
    public GameObject parentObject;
    public GameObject myPrefab;
    public GameObject smokePrefab;
    public bool Lvlup;
    [Header("Toplanýlan Objelerin Score Deðeri")]
    public int barrelValue;
    public int crewValue;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    void Update()
    {
        scoreText.text = "" + score;
        currentValue = Mathf.Clamp(currentValue, score, maxLevelExp);
        levelImage.fillAmount = currentValue / 100f;
        if (levelImage.fillAmount == 1)
        {
            levelImage.fillAmount = 0;
            Lvlup = true;
            if (Lvlup == true)
            {
                score = 0;
                currentValue = 0;
                GameObject ship = Instantiate(myPrefab, new Vector3(currentShip.transform.position.x, -0.48f, currentShip.transform.position.z), currentShip.transform.rotation);
                GameObject smokeVFX = Instantiate(smokePrefab, new Vector3(currentShip.transform.position.x, 3f, currentShip.transform.position.z), currentShip.transform.rotation);
                Destroy(smokeVFX, 3f);
                ship.transform.parent = parentObject.transform;
                currentShip.SetActive(false);
                Lvlup = false;
                
            }

        }
    }
}
