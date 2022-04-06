using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HeadPoinstHolder : MonoBehaviour
{
    public GameObject particleEffect;
    [SerializeField] TextMeshPro pointsText;
    private static string pointValue;
    private int pointValueInt;
    private bool inMyState;
    public static float nextSpawnIndexRemove = 0;
    Animator anim;
    Rigidbody rb;
    Rigidbody particleRb;

    public Movement movement;
    [SerializeField] UIManager ui;

    //Start is called before the first frame update
    void Start()
    {
        particleEffect.SetActive(false);
        particleRb = particleEffect.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        pointValueInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointValue = pointsText.text;
        int.TryParse(pointValue, out pointValueInt);
        //Debug.Log(pointValueInt);


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fists")
        {
            //nextSpawnIndexRemove = nextSpawnIndexRemove + 0.8f;

            Movement.fistsValue--;
            //Destroy(other.gameObject);  
            movement.handList[Movement.handInt].SetActive(false);
            Movement.handInt--;

            pointValueInt = pointValueInt - 1;
            pointsText.text = pointValueInt.ToString();
            if(pointValueInt <= 0)
            {
                rb.velocity =  new Vector3(0, 0, 8f);
                //particleRb.velocity = new Vector3(0, 0, 8f);
                GetComponent<BoxCollider>().enabled = false;
                Destroy(transform.GetChild(0).gameObject);
                anim.SetBool("fail", true);
                Destroy(gameObject, 1f);
                particleEffect.SetActive(true);

            }
            if(Movement.fistsValue < 0)
            {
                ui.GameOverPopUp.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
