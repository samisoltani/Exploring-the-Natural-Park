using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum InteractionType
{
    Hello,
    AnswerToNO,
    AnswerToYES
}

public class TourGuidController : MonoBehaviour
{
    const string MaleSpeaker = "Microsoft David Desktop";
    const string FemaleSpeaker = "Microsoft Zira Desktop";



    [Space]
    [SerializeField] Button BackToSayHelloButton;

    [Space]
    [SerializeField] Button SayHelloButton;

    [Space]
    [SerializeField] Button YesButton ;

    [Space]
    [SerializeField] Button NoButton;

    [Space]
    [TextArea(5, 30)]
    [SerializeField] string helloDialogue;
    //[SerializeField] AudioClip helloClip;
    [Space]
    [SerializeField] float helloDelay = 2f;

    [Space]
    [TextArea(5, 30)]
    [SerializeField] string noAnswerDialogue;
    [Space]
    [SerializeField] float noDelay = 2f;

    [Space]
    [TextArea(5, 30)]
    [SerializeField] string yesAnswerDialogue;
    [Space]
    [SerializeField] float yesDelay = 2f;

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
                //audioSource.PlayOneShot(helloClip);
                SpeakUp.Speak(helloDialogue, audioSource, MaleSpeaker);
                SayHelloButton.interactable = false;
                //yield return new WaitForSeconds(helloClip.Length);
                yield return new WaitForSeconds(helloDelay);
                SayHelloButton.interactable = true;

                SayHelloButton.gameObject.SetActive(false);
                YesButton.gameObject.SetActive(true);
                NoButton.gameObject.SetActive(true);
                BackToSayHelloButton.gameObject.SetActive(true);
                break;

            case InteractionType.AnswerToNO:

                SpeakUp.Speak(noAnswerDialogue, audioSource, MaleSpeaker);
                NoButton.interactable = false;
                yield return new WaitForSeconds(noDelay);
                NoButton.interactable = true;

                BackToSayHello();
                break;

            case InteractionType.AnswerToYES:
                //for answering Yes.
                SpeakUp.Speak(yesAnswerDialogue, audioSource, MaleSpeaker);
                YesButton.interactable = false;
                yield return new WaitForSeconds(yesDelay);
                YesButton.interactable = true;

                SayHelloButton.gameObject.SetActive(false);
                YesButton.gameObject.SetActive(false);
                NoButton.gameObject.SetActive(false);
                BackToSayHelloButton.gameObject.SetActive(true);
                break;
        }
    }



}//EndClasss
