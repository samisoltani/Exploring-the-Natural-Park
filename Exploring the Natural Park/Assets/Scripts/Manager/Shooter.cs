using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Vector3 speed;
    [SerializeField] float timeAfterShoot;
    [SerializeField] Transform ballPos;
    [SerializeField] GameObject ball;
    [SerializeField] Button shootButton;
    [SerializeField] BoxManager boxManager;
    Rigidbody rb;
    [SerializeField] Animator animator;
    bool isShooting = false;

    private void Start()
    {
        shootButton.onClick.AddListener(ShootButton);
        rb = ball.GetComponent<Rigidbody>();
    }


    void ShootButton()
    {
        animator.SetBool("shoot", true);
        shootButton.interactable = false;
    }


    void Shoot()
    {
        rb.isKinematic = false;
        isShooting = true;
        //rb.AddForce(new Vector3(0, yspeed, zspeed));
        animator.SetBool("shoot", false);
        Invoke("BackToShooter", timeAfterShoot);
    }


    void BackToShooter()
    {
        animator.SetBool("back", true);
    }

    void SetBackToFalse()
    {
        isShooting = false;
        rb.isKinematic = true;
        animator.SetBool("back", false);
        ball.transform.position = ballPos.position;
        ball.transform.rotation = ballPos.rotation;
        shootButton.interactable = true;

        boxManager.BackToFirstTrasform();
    }



    private void Update()
    {
        if (isShooting)
        {
            ball.transform.Translate(speed * Time.deltaTime);
        }
    }
}
