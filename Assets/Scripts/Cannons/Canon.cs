using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField]private Transform target;
    
   
    [Header("Öznitellikler")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Ayarlama Bölgesi")]
    public string playerTag = "Player";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
        
    }

    void UpdateTarget()
    {
        GameObject[] playerShip = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null; 
        foreach(GameObject player in playerShip)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestPlayer = player;
            }
        }
        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
        else
        {
            target = null;
        }
    }
    void Update()
    {
        if (target == null)
            return;
        if (!GameManager.instance.finishLine || GameManager.instance.shootTouch)
        { 
        //Hedefe Kilitlenme
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
        }
    }
    // public IEnumerator FinishShoot()
    // {
    //
    //     //Hedefe Kilitlenme
    //     
    //         Vector3 dir = target.position - transform.position;
    //         Quaternion lookRotation = Quaternion.LookRotation(dir);
    //         Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
    //         partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    //         if (fireCountDown <= 0f)
    //         {
    //             Shoot();
    //             fireCountDown = 1f / fireRate;
    //         }
    //         fireCountDown -= Time.deltaTime;
    //     yield return new WaitForSeconds(0.1f);
    //     
    // }
    public void Shoot()
    {
        GameObject cannonGo =(GameObject)Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        CannonBall cannon = cannonGo.GetComponent<CannonBall>();
       
        if(cannon != null)
        {
            cannon.Seek(target);
        }
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
