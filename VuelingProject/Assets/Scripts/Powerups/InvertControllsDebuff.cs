using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertControllsDebuff : PowerUp
{
    protected override void DoAction(PlaneController plane)
    {
        plane.InvertControllsDebuff();
        base.DoAction(plane);
    }
}
