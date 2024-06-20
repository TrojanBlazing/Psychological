using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairInteractor : MonoBehaviour
{
    [SerializeField]
    private Sprite defaultIcon;
    [SerializeField]
    private Sprite defaultInteractIcon;

    private Interacted interactable;
    [SerializeField]
    private LayerMask interact;
    [SerializeField]
    private Image imgInter;

    [SerializeField]
    private Vector2 defaultIconSize;
    [SerializeField] 
    private Vector2 defaultInteractIconSize;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 4, interact))
        {
            if (hit.collider.GetComponent<Interacted>() != false)
            {
                if (interactable == null || interactable.Id != hit.collider.GetComponent<Interacted>().Id)
                {
                    interactable = hit.collider.GetComponent<Interacted>();

                }
                if (interactable.IconInteract != null)
                {
                    imgInter.sprite = interactable.IconInteract;
                }
                else
                {
                    imgInter.sprite = defaultInteractIcon;
                }

            }
        }
        else
        {
            if (imgInter.sprite != defaultIcon)
            {
                imgInter.sprite = defaultIcon;

            }
        }
    }
}


