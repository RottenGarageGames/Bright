using Assets.Scripts.Damagables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable, IDamagable
{
    public GameObject LogPrefab;
    public int SpawnCount;

    [SerializeField] float StartingHealth;
    public float Health { get; set; }

    private void Start()
    {
        Health = StartingHealth;
    }

    public void Interact(GameObject interactor)
    {
        gameObject.GetComponent<Animator>().SetBool("Destroy", true);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if(Health <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Destroy", true);
        }
    }
    public void SpawnLogs()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            Instantiate(LogPrefab, gameObject.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
