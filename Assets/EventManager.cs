using ItemRepository.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate Item OnItemInteract();
    public static event OnItemInteract OnInteract;


     void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
        {
           OnInteract?.Invoke();
        }
     }
}
