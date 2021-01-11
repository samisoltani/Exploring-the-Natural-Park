using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    [SerializeField] Transform boxParentTransform;
    [SerializeField] GameObject allBoxesPrefab;

    GameObject currentBoxes;
    void Start()
    {
        currentBoxes = Instantiate(allBoxesPrefab, boxParentTransform.position, boxParentTransform.rotation);
    }

    public void BackToFirstTrasform()
    {
        Destroy(currentBoxes);
        currentBoxes = Instantiate(allBoxesPrefab, boxParentTransform.position, boxParentTransform.rotation);
    }
}
