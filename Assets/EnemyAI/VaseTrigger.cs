using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseTrigger : MonoBehaviour
{

    [SerializeField] GameObject vase;
    [SerializeField] EnemyAI_1 enemyAI;
    [SerializeField] float impulseMagnitude;
    private void OnTriggerEnter(Collider other)
    {
        vase.GetComponent<Rigidbody>().AddForce(impulseMagnitude * -Vector3.forward, ForceMode.Impulse);
        vase.GetComponent<AudioSource>().Play();
        enemyAI.objectFell = true;
    }
}
