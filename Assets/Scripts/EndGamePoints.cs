using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class EndGamePoints : MonoBehaviour
{
    [SerializeField] TextMeshPro pointsText;
    private static string pointValue;
    private static string whoIsHand;
    public static bool isGameFinish = false;
    private int pointValueInt;
    public GameObject animBox;
    public bool isShake = false;

    public float shakePower, shakeTime;
    Animator anim;

    public Movement movement;
    // Start is called before the first frame update
    void Start()
    {

        pointValueInt = 0;
        anim = animBox.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pointValueInt);
        pointValue = pointsText.text;
        int.TryParse(pointValue, out pointValueInt);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fists")
        {
            //anim.SetBool("IsBox", true);
            Camera.main.DOShakeRotation(shakeTime, shakePower, fadeOut: true);
            Camera.main.DOShakePosition(shakeTime, shakePower, fadeOut: true);
        }
        else if(other.gameObject.layer == 6)
        {
            //anim.SetBool("IsBox", false);
            isGameFinish = true;
        }
    }
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.transform.GetChild(0).tag == "NormalHand")
    //    {
    //        whoIsHand = "NormalHand";
    //    }
    //    if (other.gameObject.transform.GetChild(2).tag == "BoxingGloves")
    //    {
    //        whoIsHand = "BoxingGloves";
    //    }
    //    if (other.gameObject.transform.GetChild(1).tag == "Hulk")
    //    {
    //        whoIsHand = "Hulk";
    //    }

    //    switch (whoIsHand)
    //    {
    //        case "NormalHand":
    //            pointValueInt = pointValueInt + 5;
    //            pointsText.text = pointValueInt.ToString();
    //            break;
    //        case "BoxingGloves":
    //            pointValueInt = pointValueInt + 25;
    //            pointsText.text = pointValueInt.ToString();
    //            break;
    //        case "Hulk":
    //            pointValueInt = pointValueInt + 50;
    //            pointsText.text = pointValueInt.ToString();
    //            break;
    //    }
    //}



}
