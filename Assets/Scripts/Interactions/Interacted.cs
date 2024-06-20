using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interacted : MonoBehaviour
{
   // public UnityEvent OnInteract;
    public int Id;
    public Sprite IconInteract;
    void Start()
    {
        Id = Random.Range(0, 999999);
    }
}
