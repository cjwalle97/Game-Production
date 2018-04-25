﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parts/Arm")]
public class Arm : Part
{
    public bool isLeft; //  Check fir if arm belongs on left side of character
    public bool isRight;    //  Check for if arm belongs on right side of character
    public bool isMelee;    //  Check for if arm has melee styled attacks
    public bool isRanged;   //  Check for if arm has ranged styled attacks
    public float damageNum; //  Base Damage of the arm
    public float meleeAttackSpeed;  //  Melee Attack Speed Modifier
    public float projectileSpeed;   //  Projectile Speed Modifier
    public bool isExplosive;
    public IShootable Projectile;

    public enum AttackType
    {
        BULLET = 0,
        GRENADE = 1
    }
    public AttackType attackType;
    
}
