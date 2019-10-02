using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    [SerializeField]
    private float MaxY;

    [SerializeField]
    private float MinY;

    [SerializeField]
    private float BobSpeed;

    private GameObject[] destinations;

    private void Start()
    {
        destinations = GameObject.FindGameObjectsWithTag("TeleporterDestination");
    }

    private void Update()
    {
        if (transform.position.y >= MaxY || transform.position.y <= MinY)
        {
            BobSpeed *= -1.0f;
        }

        transform.position += new Vector3(0.0f, BobSpeed * Time.deltaTime, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
      
        destinations = destinations.OrderBy(p => Vector3.Distance(transform.position, p.transform.position)).ToArray();

        other.gameObject.GetComponent<CharacterController>().enabled = false;
        other.gameObject.transform.position = destinations[0].transform.position;
        other.gameObject.GetComponent<CharacterController>().enabled = true;
    }
}
