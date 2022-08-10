using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ShipAttributes shipAtt;
    public CastleAttributes castleAtt;
    public EnemyShipAttributes enemyShipAttributes;
    public EnemyBossAttributs enemyBossAttributes;
    public static GameManager instance;
    public bool finishLine;
    public bool shootTouch;

    // Update is called once per frame
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    public int GetDamage(CannonType type)
    {
        switch (type)
        {
            case CannonType.player:return shipAtt.damage;
            case CannonType.castle: return castleAtt.damage;
            case CannonType.enemyship: return enemyShipAttributes.damage;
            case CannonType.boss: return enemyBossAttributes.damage;
            default:
                return 0;
        }
    }

}
