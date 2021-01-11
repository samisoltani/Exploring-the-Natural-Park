using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourGuidMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;

    void Start()
    {
        menu.transform.position = new Vector3(transform.position.x, transform.position.y + 2f , transform.position.z);
    }


}
