using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CannonType
{
    player,
    castle,
    enemyship,
    boss
}

public class CannonBall : MonoBehaviour
{
    public CannonType cannonType;
    public Transform target;
    public float speed;

    public int damage;

    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    private void Start()
    {
        damage = GameManager.instance.GetDamage(cannonType);
    }
    protected void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    // ReSharper disable Unity.PerformanceAnalysis
    protected void HitTarget()
    {
        GameObject effectIns =(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Damage(target);
        DamageToCastle(target);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
    protected void Damage(Transform enemy)
    {
        ShipMovement e = enemy.GetComponent<ShipMovement>();
        if (e !=null)
        {
            e.TakeDamage(damage);
        }
        
    }
    protected void DamageToCastle(Transform enemy)
    {
        CastleHealth c = enemy.GetComponentInChildren<CastleHealth>();
        if (c !=null)
        {
            c.TakeDamage(damage);
           
        }
        
    }
}
