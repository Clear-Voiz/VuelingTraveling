using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDebuff : PowerUp
{
    protected override void DoAction(PlaneController plane)
    {
        plane.SpeedDebuff();
        // hay que hacer que el player pueda lanzar ese debufo
        base.DoAction(plane);
    }
}
