using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    private float _health = 30;

    public void TakeDamage(float health)
    {
        if (_health >= 0)
        {
            _health -= health;
        }
        else
        {
            DestroyTree();
        }
    }
    private void DestroyTree()
    {
        Destroy(gameObject);
    }
}
