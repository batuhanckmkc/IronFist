using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Movement : MonoBehaviour
{
    [SerializeField] Transform Player, finishLine, boxPlace;
    Vector3 distance;
    [SerializeField] GameObject[] fists;
    private float movementXSpeed = 6f, minX = 0.15f, maxX = -1.4f;
    [HideInInspector]
    private bool targetDetected = false;
    public int fistSkinValue;
    public float nextSpawnIndex;
    private int fistIndex = 0;
    public static int fistsValue;
    private Rigidbody rb;
    public GameObject point;
    public GameObject playerFist;
    public List<GameObject> movementList;
    public List<GameObject> handList;
    public static int handInt = 0;
    void Start()
    {
       
        nextSpawnIndex = 0.8f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float rightButton = Input.GetAxis("Horizontal");
        float leftButton = Input.GetAxis("Vertical");

        
        transform.Translate(rightButton * Time.deltaTime * 10f, 0, leftButton * Time.deltaTime * 10f, Space.World);

        for (int i = 0; i < movementList.Count; i++)
        {
            movementList[i].gameObject.tag = "Player";
        }
        //Debug.Log(rb.position.x);
        if (Input.touchCount > 0)
        {
            if(CollectFists.targetDetected == false)
            {
                Touch finger = Input.GetTouch(0);
                if (finger.phase == TouchPhase.Began)
                {

                }
                if (finger.deltaPosition.x > 5f && rb.position.x < minX)
                {
                    if (finger.phase == TouchPhase.Moved)
                    {
                        transform.position += Vector3.right * movementXSpeed * Time.deltaTime;
                    }
                }
                if (finger.deltaPosition.x < -5f && rb.position.x > maxX)
                {
                    if (finger.phase == TouchPhase.Moved)
                    {
                        transform.position += Vector3.left * movementXSpeed * Time.deltaTime;
                    }
                }
            }
         
        }
    }
    private void FixedUpdate()
    {
        if (CollectFists.targetDetected == true)
        {
            SpeedForce(100);
        }
        else
        {
            SpeedForce(250);
        }

    }
    void SpeedForce(float movementZSpeed)
    {
        rb.velocity = (Vector3.forward * movementZSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fists")
        {
            Destroy(other.transform.gameObject);
            fistsValue++;
            //Vector3 vec = new Vector3(0, 0, 0.6f);
            //point.transform.position += point.transform.right * playerFist.transform.localScale.z - vec + new Vector3(0, 0, 0.001f);
            //movementList.Add(Instantiate(playerFist, point.transform.position, transform.rotation * Quaternion.Euler(0,0,0), transform.GetChild(0)));
            if (handInt < 10)
            {
                handInt++;
                handList[handInt].SetActive(true);
            }
            //nextSpawnIndex = nextSpawnIndex + HeadPoinstHolder.nextSpawnIndexRemove;
        }
        if(other.gameObject.tag == "FinishLine")
        {
            //Vector3 vec = new Vector3(0, finishLine.transform.position.y + 1, 0);
            //Player.transform.position = Vector3.Lerp(Player.transform.position, finishLine.transform.position + vec, 0.3f);
            //Player.transform.parent = finishLine.transform;
        }
        if (other.gameObject.tag == "Converter")
        {

        }
    }
}
