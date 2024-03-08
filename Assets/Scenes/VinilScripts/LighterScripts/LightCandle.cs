using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour
{
    [SerializeField]
    private GameObject LighterOb;

    [SerializeField]
    private GameObject CandleFlame;

    [SerializeField]
    private GameObject text;

    private bool UnLit;
    private bool inReach;

    public float distance = 4.1f;

    private void Start()
    {
        UnLit = true;
        CandleFlame.SetActive(false);   
        text.SetActive(false);  
    }

    private void Update()
    {
        CandleOn();
    }

    private void CandleOn()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);  
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,distance))
        {
            if(hit.collider.CompareTag("Candle"))
            {
                inReach = true;
                text.SetActive(true);

                if(LighterOb.activeInHierarchy&&UnLit&&Input.GetKeyDown(KeyCode.E))
                {
                    CandleFlame.SetActive(true);
                    text.SetActive(false);
                    UnLit = false;  

                }
            }
            else
            {
                inReach = false;    
                text.SetActive(false);
                            
            }
        }
        else
        {
            inReach = false;
            text.SetActive(false);
        }
    }


}
