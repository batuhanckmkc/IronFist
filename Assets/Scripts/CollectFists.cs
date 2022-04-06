using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CollectFists : MonoBehaviour
{
    [SerializeField] TextMeshPro pointsText;
    private static string pointValue;
    private static string whoIsHand;
    private int pointValueInt;
    [SerializeField] GameObject spawnnPlace, miniFists, Player;
    [SerializeField] Transform playerFists, finishLine, boxPlace, collactableObject;
    //public GameObject fists;
    public GameObject[] fistSkins;
    [SerializeField] Movement movement;
    public GameObject[] fistssss;
    Vector3 distance;
    public static bool targetDetected;
    public int fistSkinValue;
    public MeshFilter yourMesh;
    public Animator anim;
    public GameObject animBoxBall;
    Animator animBoxB;


    List<GameObject> fists;

    Rigidbody rbFists;
    // Start is called before the first frame update
    void Start()
    {
        pointValueInt = 0;
        targetDetected = false;
        rbFists = GetComponent<Rigidbody>();
        yourMesh = GetComponent<MeshFilter>();
        animBoxB = animBoxBall.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pointValueInt);
        pointValue = pointsText.text;
        int.TryParse(pointValue, out pointValueInt);
        //Debug.Log(movement.nextSpawnIndex);
        if (targetDetected == true) //&& ThrowBall.isPickUp == false)
        {
            TargetDetected();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            //Vector3 PosY = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.1f, Player.transform.position.z + movement.nextSpawnIndex);
            //fists.Add(Instantiate(miniFists, PosY, transform.rotation * Quaternion.Euler(-90, -90, 0), transform.GetChild(0)));
            //fistsValue++;
            //fists.transform.parent = Player.transform;
            //fists.tag = "Player";
            //fists.transform.localScale = new Vector3(1f, 1f, 1f);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BoxBag")
        {
            animBoxB.SetBool("shakeBall", true);
            if (gameObject.layer == 7)
            {
                animBoxB.SetBool("shakeBall", false);
            }
        }
        
            

        if (other.gameObject.tag == "Converter")
        {
            fistSkins[fistSkinValue].SetActive(false);
            fistSkinValue = fistSkinValue + 1;
            fistSkins[fistSkinValue].SetActive(true);
        }
        if (other.gameObject.tag == "Head")
        {
            fistSkins[fistSkinValue].SetActive(false);
            fistSkinValue = 0;
            fistSkins[fistSkinValue].SetActive(true);
        }
        if (other.gameObject.tag == "FinishLine")
        {
            //Vector3 vec = new Vector3(0, finishLine.transform.position.y + 1, 0);
            //miniFists.transform.position = Vector3.Lerp(miniFists.transform.position, finishLine.transform.position + vec, 0.6f);
            //miniFists.transform.parent = collactableObject.transform;
            //Vector3 vec = new Vector3(finishLine.transform.position.x , finishLine.transform.position.y + 3.2f, finishLine.transform.position.z - 4f);
            Vector3 vec2 = new Vector3(boxPlace.transform.position.x, boxPlace.transform.position.y - 0.8f, Player.transform.position.z);

            //Spordan gelince aradaki mesafeyi ölç o mesafeyi kullanarak yolla yumruklarý.
            //Player.transform.position = Vector3.Lerp(Player.transform.position,  vec, 0.3f);
            //miniFists.transform.parent = finishLine.transform;
            Player.transform.DOMove(vec2, 0.5f);
            //anim.SetBool("isBoxOpen", true);
            targetDetected = true;
            animBoxB.SetBool("boxBall", true);

            
        }
        if (other.gameObject.tag == "BoxBag" && this.gameObject.transform.GetChild(0).tag == "NormalHand")
        {
            whoIsHand = "NormalHand";
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BoxBag" && this.gameObject.transform.GetChild(2).tag == "BoxingGloves")
        {
            whoIsHand = "BoxingGloves";
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BoxBag" && this.gameObject.transform.GetChild(1).tag == "Hulk")
        {
            whoIsHand = "Hulk";
            Destroy(gameObject);
        }
        switch (whoIsHand)
        {
            case "NormalHand":
                pointValueInt = pointValueInt + 5;
                pointsText.text = pointValueInt.ToString();
                break;
            case "BoxingGloves":
                pointValueInt = pointValueInt + 25;
                pointsText.text = pointValueInt.ToString();
                break;
            case "Hulk":
                pointValueInt = pointValueInt + 50;
                pointsText.text = pointValueInt.ToString();
                break;
        }
    }
    void TargetDetected()
    {
        //Vector3 pos = Vector3.MoveTowards(transform.position, boxPlace.position, 5f * Time.fixedDeltaTime);
        //rbFists.MovePosition(pos);


        //distance = boxPlace.transform.position - Player.transform.position;
        //distance = distance.normalized; // The normalized direction in LOCAL space
        //transform.Translate(distance.z * Time.deltaTime * 5f, 0, 5f);
        //miniFists.transform.position = Vector3.Lerp(miniFists.transform.position, boxPlace.transform.position,  0.009f );
        //distance = boxPlace.position - playerFists.position;
        //distance = distance.normalized; // The normalized direction in LOCAL space
        //transform.Translate(distance.z * Time.deltaTime * 10f, 0, 0);
        //transform.LookAt(ball.position);
    }
}
