using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour,IHealthable
{
    public ShipAttributes shipAtt { get; private set; }
    public Health hp;
    public GameObject pivotObject;
    public float moveSpeed;
    public float swipeSpeed;
    public int healt = 100;
    [Header("Unity Stuff")]
    public Image healtBar;
    public bool bossArea;
    public GameObject indicatur;
    

    float touchPosX;
    public void TakeDamage(int amount)
    {
        //healt -= amount;
        
        //if(healt <= 0)
        //{
        //    Die();
        //}
        Debug.Log(amount);
        if (hp.TakeDamage(amount).isFinished)
        {
            Die();
        }
        healtBar.fillAmount = hp.currentValue / 100f;
    }
    void Die()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
   
    }
    private void Start()
    {
      
        shipAtt = GameManager.instance.shipAtt;
        hp.Start();

    }
    void Update()
    {
        LevelBoundaries();
        if (bossArea == false)
        {
            transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
            if (TouchController.Instance.canMove)
            {
                touchPosX = TouchController.Instance.touch.deltaPosition.x * Time.deltaTime * swipeSpeed;
                transform.position += Vector3.right * touchPosX;
            }
        }
       
    }
    private void FixedUpdate()
    {
        if (bossArea == true)
        {
            var position = pivotObject.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);
            transform.LookAt(position);
            StartCoroutine(WaitForSeconds());
        }
    }
    public void LevelBoundaries()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x,-20f,20f);
        transform.position = pos;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrel"))
        {
            ScoreManagment.instance.score += ScoreManagment.instance.barrelValue;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Crew"))
        {
            ScoreManagment.instance.score += ScoreManagment.instance.crewValue;
            other.gameObject.SetActive(false);
        }
        if(other.CompareTag("BossArea"))
        {
            bossArea = true;
            GameManager.instance.finishLine = true;
            StartCoroutine(WaitForSeconds());
        }
    }
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3f);
        indicatur.SetActive(true);
    }
}
