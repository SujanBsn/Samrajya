using UnityEngine;

public class EnemySoldierPositionController : SoldierPositionController
{
    protected override void GetSoldierData()
    {
        base.GetSoldierData();
        KingPos = GameObject.FindWithTag("Enemy_Boss").transform;
    }
}
