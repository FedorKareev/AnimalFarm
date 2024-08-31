using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyEffectAfterInit());
    }
    private IEnumerator DestroyEffectAfterInit()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
