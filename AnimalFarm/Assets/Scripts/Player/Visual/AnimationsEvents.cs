using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    public void OnChopTree()
    {
        WoodcutterScript woodCutter = GetComponentInParent<WoodcutterScript>();
        woodCutter.HitTheTree();
    }

    public void FootStepActivator()
    {
        FootSteps footSteps = GetComponentInParent<FootSteps>();
        footSteps.FootStepsOn();
    }
}
