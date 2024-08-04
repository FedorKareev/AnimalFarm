using System.Collections;
using UnityEngine;

public class WoodcutterScript : MonoBehaviour
{
    [SerializeField]
    private int treeLayerNumber;
    [SerializeField]
    private float timeBeforeDestroy;
    [SerializeField]
    private ToolSystem ToolSystem;
    private bool isCuttingTree = false;
    private Collider treeCollider;

    private void OnTriggerEnter(Collider tree)
    {
        treeCollider = tree;
        if (tree.gameObject.layer == treeLayerNumber && ToolSystem.IsAxeUse() == true)
        {
            StartCoroutine(WaitToDestroyTree());
        }
    }
    private IEnumerator WaitToDestroyTree()
    {
        while (true)
        {
            isCuttingTree = true;
            yield return new WaitForSeconds(timeBeforeDestroy);
            DestroyTree();
        }
    }
    private void DestroyTree()
    {
        isCuttingTree = false;
        Destroy(treeCollider.gameObject);
    }

    public bool IsCuttingTree()
    {
        return isCuttingTree;
    }
}

