using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour
{
    [SerializeField]
    private Transform gardenBedTransform;
    [SerializeField]
    private Transform marketTransform;

    [SerializeField]
    private AnimalWalk unit;

    private void Awake()
    {
        unit = gameObject.GetComponent<AnimalWalk>();
        unit.MoveTo(gardenBedTransform.position, () =>
        {
            unit.WaitForSeconds(3f, () =>
            {
                unit.MoveTo(marketTransform.position, null);
            });
        });
    }
}
