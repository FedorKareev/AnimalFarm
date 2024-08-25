using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;

public class WoodcutterScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask treeLayerNumber;
    [SerializeField]
    private float timeBeforeDestroy;
    [SerializeField]
    private ToolSystem ToolSystem;
    private bool isCuttingTree = false;
    private TreeHealth _treeHealth;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 2);
        if (ToolSystem.IsAxeUse())
        {
            CheckIsTreeHere();
        }
    }

    public void HitTheTree()
    {
        _treeHealth.TakeDamage(Random.Range(5, 10));
    }

    public bool IsCuttingTree()
    {
        return isCuttingTree;
    }

    private void CheckIsTreeHere()
    {
        TreeHealth treeHealth;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, treeLayerNumber))
        {
            if (hit.transform.TryGetComponent(out treeHealth))
            {
                _treeHealth = treeHealth;
                isCuttingTree = true;
            }
            else
            {
                _treeHealth = null;
                isCuttingTree = false;
            }
        }
        else
        {
            _treeHealth = null;
            isCuttingTree = false;
        }
    }
}

