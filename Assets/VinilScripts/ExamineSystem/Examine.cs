using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class Examine : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Transform player;
    [SerializeField] private PlayerMovement pm;
    [SerializeField] private GameObject inspectUI;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemDescription;

    private GameObject inspected;
    private Vector3 originalPos;
    private bool onInspect = false;

 

    private void Update()
    {
        Inspect();
    }

    IEnumerator PickItem()
    {
        pm.enabled = false;
        yield return new WaitForSeconds(0.1f);
        inspected.transform.SetParent(player);
        ShowInspectUI(inspected);

        
    }

    IEnumerator DropItem()
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
            if (hit.transform.CompareTag("Reach") && !onInspect)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    inspected = hit.transform.gameObject;
                    originalPos = hit.transform.position;
                    onInspect = true;
                    StartCoroutine(PickItem());
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
            StartCoroutine(DropItem());
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
