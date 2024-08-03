using UnityEngine;
public class PlayerSoldierPositionController : SoldierPositionController
{
    protected override void GetSoldierData()
    {
        base.GetSoldierData();
        KingPos = GameObject.FindWithTag("King").transform;
    }
}
