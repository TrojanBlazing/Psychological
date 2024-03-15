using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCandle : MonoBehaviour
{

    bool UnLit;
    [SerializeField]
    private GameObject CandleFlame;

   
    private void Start()
    {
        UnLit = true;
        CandleFlame.SetActive(false);   
        
    }

    

    public void LightTheCandle()
    {
        Debug.Log("Here");
        if(UnLit)
        {
           
            CandleFlame.SetActive(true);
            UnLit = false;
        }
    }
   /* private void CandleOn()
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
    }*/


}
