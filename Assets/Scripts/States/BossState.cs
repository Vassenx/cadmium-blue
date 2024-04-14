using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState  : BasePlayerState
{
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Vector3 bossLocation;
    
    public override void Enter()
    {
        base.Enter();
        Instantiate(bossPrefab, bossLocation, Quaternion.identity);
    }
}
