﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum Stations
{
    EntryStation, RiverStation, GameStation, CloudStation, JungleStation
}

public class TeleportStation : MonoBehaviour
{
    [Space]//eNUM for Chosing between Stations.
    [Header("Station")]
    [SerializeField] Stations stations;

    [Space]
    [Header("Show Menu Button ")]
    [SerializeField] Button showMenuBTN;

    [Space]
    [Header("Station Buttons")]
    [SerializeField] Button[] stationButtons;

    [Space]
    [Header("Menu")]
    [SerializeField] GameObject showMenu, vrMenu;

    [Space]
    [Header("FadeInFadeOut")]
    [SerializeField] GameObject FadeInFadeOutPanel;

    [Space]
    [Header("Menu Transform Position")]
    [SerializeField] Transform menuTransform, currentStationButton, otherStationsButton;

    [Space]
    [Header("Station Trasform")]
    [SerializeField] Transform EntryStation, RiverStation, GameStation, CloudStation, JungleStation;

    [Space]
    [Header("AudioForTeleport")]
    [SerializeField] AudioSource audioSource;

    [Space]
    [SerializeField] AudioClip entrySound;


    //Non-Serialize Variables


    //instance of player for teleport
    GameObject player;

    //Number Of Station
    int stationNumber;

    //for menu Distance
    const float zDirection = 5f;


    void Start()
    {
        AssignButtons();
        stationNumber = GetCurrentStation();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    int GetCurrentStation()
    {
        int stationNumber = 0;
        switch (stations)
        {
            case Stations.EntryStation:
                menuTransform.position =
                     new Vector3(EntryStation.position.x,
                     EntryStation.position.y + zDirection / 2,
                     EntryStation.position.z - zDirection);

                stationNumber = 0;
                break;
            case Stations.RiverStation:

                menuTransform.position =
                        new Vector3(RiverStation.position.x,
                        RiverStation.position.y + zDirection / 2,
                        RiverStation.position.z - zDirection);

                stationNumber = 1;
                break;
            case Stations.GameStation:

                menuTransform.position =
                         new Vector3(GameStation.position.x,
                         GameStation.position.y + zDirection / 2,
                         GameStation.position.z - zDirection);

                stationNumber = 2;
                break;
            case Stations.CloudStation:

                menuTransform.position =
                        new Vector3(CloudStation.position.x,
                        CloudStation.position.y + zDirection / 2,
                        CloudStation.position.z - zDirection);

                stationNumber = 3;
                break;
            case Stations.JungleStation:

                menuTransform.position =
                             new Vector3(JungleStation.position.x,
                             JungleStation.position.y + zDirection / 2,
                             JungleStation.position.z - zDirection);

                stationNumber = 4;
                break;
        }
        return stationNumber;
    }

    #region Teleport Actions -------------------------------

    //For add listener to Buttons.
    void AssignButtons()
    {

        // to teleport from current station to other stations.
        stationButtons[0].onClick.AddListener(GoToEntryStation);
        stationButtons[1].onClick.AddListener(GoToRiverStation);
        stationButtons[2].onClick.AddListener(GoToGameStation);
        stationButtons[3].onClick.AddListener(GoToCloudStation);
        stationButtons[4].onClick.AddListener(GoToJungleStation);
    }

    void GoToEntryStation()
    {
        StartCoroutine(Teleport(EntryStation));
    }
    void GoToRiverStation()
    {
        StartCoroutine(Teleport(RiverStation));
    }
    void GoToGameStation()
    {
        StartCoroutine(Teleport(GameStation));
    }
    void GoToCloudStation()
    {
        StartCoroutine(Teleport(CloudStation)); 
    }
    void GoToJungleStation()
    {
        StartCoroutine(Teleport(JungleStation));
    }

    IEnumerator Teleport(Transform transform)
    {
        FadeInFadeOutPanel.SetActive(true);
        yield return new WaitForSeconds(4f);
        player.transform.position = transform.position;
        yield return new WaitForSeconds(4f);
        FadeInFadeOutPanel.SetActive(false);
    }



    #endregion






    void ShowMenu()
    {
        Debug.Log("Menu");
        showMenu.SetActive(false);
        SetNShowButtonsTransform();
    }
    void HideMenu()
    {
        showMenu.SetActive(false);
        vrMenu.SetActive(false);
    }
    void SetNShowButtonsTransform()
    {
        for (int i = 0; i < stationButtons.Length; i++)
        {
            if (i == stationNumber)
            {
                stationButtons[i].transform.GetComponent<Button>().enabled = false;
                stationButtons[i].transform.SetParent(currentStationButton);
                stationButtons[i].transform.GetComponent<Image>().color = Color.green;
            }
            else
            {
                stationButtons[i].transform.GetComponent<Button>().enabled = true;
                stationButtons[i].transform.SetParent(otherStationsButton);
                stationButtons[i].transform.GetComponent<Image>().color = Color.white;
            }
        }
        vrMenu.transform.SetParent(menuTransform);
        vrMenu.transform.localPosition = Vector3.zero;
        vrMenu.transform.localScale = Vector3.one;
        vrMenu.SetActive(true);
    }

    void ShowMenuPanel()
    {
        audioSource.PlayOneShot(entrySound);
        showMenuBTN.onClick.RemoveAllListeners();
        showMenuBTN.onClick.AddListener(ShowMenu);
        showMenu.transform.SetParent(menuTransform);
        showMenu.transform.localPosition = Vector3.zero;
        showMenu.transform.localScale = Vector3.one;
        showMenu.SetActive(true);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in the Station");
            ShowMenuPanel();
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Out Of the Station");
            HideMenu();
        }
    }

}//EndClasss
