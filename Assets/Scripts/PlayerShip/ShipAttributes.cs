using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipAttributes:Attributes
{
 

}
[System.Serializable]
public class CastleAttributes:Attributes
{
   
}
[System.Serializable]
public class EnemyShipAttributes : Attributes
{

}
[System.Serializable]
public class EnemyBossAttributs : Attributes
{

}

[System.Serializable]
public class Attributes
{
    public Health hp;
    public int damage;
    public int speed;
}




