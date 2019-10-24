using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour
{

    public GameObject Button;
    //最小サイズ
    private float minimum = 0.8f;
    //拡大縮小スピード
    private float magSpeed = 5.0f;
    //拡大率
    private float magnification = 0.3f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Button.gameObject.transform.localScale = new Vector2(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);

      

    }

 
            


        }
    

