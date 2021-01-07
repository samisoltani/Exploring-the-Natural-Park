using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    Transform boxParent;
    [SerializeField]GameObject[] initBoxes; 
    [SerializeField]GameObject[] boxes;
    void Start()
    {
        boxParent = GetComponent<Transform>();

        InstantiatingBoxes();
    }

    void InstantiatingBoxes()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            GameObject box = Instantiate(initBoxes[i]);
            boxes[i] = box;
            boxes[i].SetActive(false);
        }
    }

    public void BackToFirstTrasform()
    {
        for (int i = 0; i < initBoxes.Length; i++)
        {
            GameObject box = Instantiate(boxes[i]);
            boxes[i] = box;
            boxes[i].SetActive(false);
            Destroy(initBoxes[i]);
        }
    }
}
