using UnityEngine;

public abstract class SpawnObjectsBase : MonoBehaviour
{
    public bool IsSpawned { get; protected set; }

    public abstract void SelectObject(int Index);
    
}
