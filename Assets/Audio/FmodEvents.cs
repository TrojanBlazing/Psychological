using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FmodEvents : MonoBehaviour
{


    [field: Header("Footsteps")]
    [field: SerializeField] public EventReference Footsteps { get; private set; }

    [field: Header("Ambience")]
    [field: SerializeField] public EventReference Ambience { get; private set; }

    [field: Header("Rain")]
    [field: SerializeField] public EventReference Rain { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference Music { get; private set; }

    [field: Header("ObjectiveSFX")]
    [field: SerializeField] public EventReference ObjectiveSFX { get; private set; }


    [field: Header("Dialogue")]
    [field: SerializeField] public EventReference Dialogue { get; private set; }

    [field: Header("Random SFX")]
    [field: SerializeField] public EventReference RandomSFX { get; private set; }
    public static FmodEvents instance {  get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
           
        }
        else
        {
            
            Destroy(instance);
        }
    }
}
