using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FinishMealState  : BasePlayerState
{
    public override void Enter()
    {
        base.Enter();
        GlobalManager.Instance.curBattleIndex = -1;
    }
}
