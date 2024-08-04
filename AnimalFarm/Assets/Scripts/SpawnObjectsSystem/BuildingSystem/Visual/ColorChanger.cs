using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ColorChange(GameObject buildingObject, int numberOfColor)
    {
        if(numberOfColor == 1)
        {
            buildingObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if(numberOfColor == 2)
        {
            buildingObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (numberOfColor == 3)
        {
            buildingObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
