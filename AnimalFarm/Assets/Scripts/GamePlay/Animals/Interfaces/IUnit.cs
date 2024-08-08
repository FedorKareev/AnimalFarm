using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface IUnit
{
    void MoveTo(Vector3 position, Action onArrivedAtPosition);
    void WaitForSeconds(float delayTime, Action onArrivedAtPosition);
}
