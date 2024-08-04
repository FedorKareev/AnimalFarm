using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ITEM_TEST : MonoBehaviour
{
    [SerializeField]
    private int amount;
    // ВНИМАНИЕ это поле это просто тест, потом удалишь
    [SerializeField]
    private ItemData itemTest;
    private void OnTriggerEnter(Collider other)
    {
        
        Saller player = other.GetComponent<Saller>();
        if (player != null)
        {
            itemTest.Amount += amount;
            Destroy(gameObject);
        }
    }
}
