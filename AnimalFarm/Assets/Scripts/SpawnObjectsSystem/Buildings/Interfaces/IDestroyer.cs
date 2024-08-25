using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyer
{
    public ItemData itemData {get; set;}
    public void DestroyBuilding();
}
