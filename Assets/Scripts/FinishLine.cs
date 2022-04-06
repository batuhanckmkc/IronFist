using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject confettiesParticle, confettiesParticle2;
    [SerializeField] Transform Player, finishLine, boxPlace;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fists")
        {
            confettiesParticle.SetActive(true);
            confettiesParticle2.SetActive(true);
        }
    }
}
