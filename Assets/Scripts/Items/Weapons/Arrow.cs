using Assets.Scripts.Damagables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Animator animator;
    public Rigidbody myRB;

    public bool isShot;
    public float Power = 1f;
    public float BaseDamage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        myRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isShot)
        {
            Debug.Log("Adding Force");
            myRB.constraints = RigidbodyConstraints.None;
            animator.enabled = false;
            gameObject.transform.parent = null;
            myRB.AddForce(gameObject.transform.right * -1 * Power, ForceMode.Impulse);
            isShot = false;
        }
    }

    public void SetDrawAnimation()
    {
        animator.SetBool("Draw", true);
    }
    public void SetIsShot()
    {
        isShot = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        myRB.constraints = RigidbodyConstraints.FreezeAll;
        var damagableObject = collision.gameObject.GetComponentInChildren<IDamagable>();

        if(damagableObject == null)
        {
           damagableObject = collision.gameObject.GetComponentInParent<IDamagable>();
        }

        if (damagableObject != null)
        {
            damagableObject.TakeDamage(BaseDamage);
        }
    }
}
