using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    private float _health = 30;

    [SerializeField]
    private GameObject _treeEffect;

    public static Action OnTreeDestroy;


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
        Instantiate(_treeEffect, transform.position, _treeEffect.transform.rotation);
        OnTreeDestroy?.Invoke();
        Destroy(gameObject);
    }
}
