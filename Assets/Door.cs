using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] bool Open = false;
    [SerializeField] Animator Animator;
    private void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
    }
    public void Interact(GameObject interactingObject)
    {
        Open = !Open;
        SetDoorStatus();
    }
    private void SetDoorStatus()
    {
        Animator.SetBool("Open", Open);
    }
}
