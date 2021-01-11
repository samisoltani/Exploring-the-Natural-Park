using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum InteractionsType
{
    Hello,
    AnswerToNO,
    AnswerToYES
}
public class TourGuideAudioController : MonoBehaviour
{

    [Space]
    [SerializeField] Button BackToSayHelloButton;

    [Space]
    [SerializeField] Button SayHelloButton;

    [Space]
    [SerializeField] Button YesButton;

    [Space]
    [SerializeField] Button NoButton;

    [Space]
    [SerializeField] AudioClip helloClip;

    [Space]
    [SerializeField] AudioClip noAnswerDialogue;
    
    [Space]
    [SerializeField] AudioClip yesAnswerDialogue;

    [Space]
    AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        BackToSayHelloButton.onClick.AddListener(BackToSayHello);
        SayHelloButton.onClick.AddListener(SayHelloInit);
        YesButton.onClick.AddListener(YesAnswer);
        NoButton.onClick.AddListener(NoAnswer);
        BackToSayHello();
    }

     

    void BackToSayHello()
    {
        SayHelloButton.gameObject.SetActive(true);
        YesButton.gameObject.SetActive(false);
        NoButton.gameObject.SetActive(false);
        BackToSayHelloButton.gameObject.SetActive(false);
    }
    void SayHelloInit()
    {
        StartCoroutine(Interaction(InteractionType.Hello));
    }

    void YesAnswer()
    {
        StartCoroutine(Interaction(InteractionType.AnswerToYES));
    }


    void NoAnswer()
    {
        StartCoroutine(Interaction(InteractionType.AnswerToNO));

    }


    IEnumerator Interaction(InteractionType interaction)
    {
        switch (interaction)
        {
            case InteractionType.Hello:
                audioSource.PlayOneShot(helloClip);
                SayHelloButton.interactable = false;
                yield return new WaitForSeconds(helloClip.length);
                SayHelloButton.interactable = true;

                SayHelloButton.gameObject.SetActive(false);
                YesButton.gameObject.SetActive(true);
                NoButton.gameObject.SetActive(true);
                BackToSayHelloButton.gameObject.SetActive(true);
                break;

            case InteractionType.AnswerToNO:

                audioSource.PlayOneShot(noAnswerDialogue);
                NoButton.interactable = false;
                yield return new WaitForSeconds(noAnswerDialogue.length);
                NoButton.interactable = true;

                BackToSayHello();
                break;

            case InteractionType.AnswerToYES:
                //for answering Yes.
                audioSource.PlayOneShot(yesAnswerDialogue);
                YesButton.interactable = false;
                yield return new WaitForSeconds(yesAnswerDialogue.length);
                YesButton.interactable = true;

                SayHelloButton.gameObject.SetActive(false);
                YesButton.gameObject.SetActive(false);
                NoButton.gameObject.SetActive(false);
                BackToSayHelloButton.gameObject.SetActive(true);
                break;
        }
    }



}//EndClasss
