using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Examine : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private Transform player;

    Vector3 originalPos;
    Vector3 originalScale;
    bool onInspect = false;
    GameObject inspected;

    [SerializeField]
    private PlayerMovement pm;

    
    [SerializeField]
    private GameObject inspectUI;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TextMeshProUGUI itemDescription;

    private void Update()
    {
        Inspect();
    }

    IEnumerator pickItem()
    {
        pm.enabled = false;
        yield return new WaitForSeconds(0.1f);
        inspected.transform.SetParent(player);


        ShowInspectUI(inspected);
    }

    IEnumerator dropItem()
    {
        inspected.transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(0.1f);
        pm.enabled = true;

        HideInspectUI();
    }

    private void Inspect()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, forward, out hit, distance))
        {
            if (hit.transform.tag == "Reach" && !onInspect)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    inspected = hit.transform.gameObject;
                    originalPos = hit.transform.position;
                    onInspect = true;
                    StartCoroutine(pickItem());
                }
            }
        }
        if (onInspect)
        {
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, player.position, 0.2f);
            player.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 125f);
        }
        else if (inspected != null)
        {
            inspected.transform.SetParent(null);
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, originalPos, 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && onInspect)
        {
            StartCoroutine(dropItem());
            onInspect = false;
        }
    }

    private void ShowInspectUI(GameObject item)
    {
        inspectUI.SetActive(true);

        var itemDetails = item.GetComponent<ItemDetails>();
        if (itemDetails != null)
        {
            itemImage.sprite = itemDetails.itemSprite;
            itemDescription.text = itemDetails.itemDescription;
        }
    }

    private void HideInspectUI()
    {
        inspectUI.SetActive(false);
        itemImage.sprite = null;
        //itemDescription.text = "";
    }
}