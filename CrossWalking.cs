using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossWalking : MonoBehaviour
{
    public float x;


    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x > -10)
        {
            x -= 0.00005f;
            Vector2 xx = new Vector2(x, 0);
            this.transform.Translate(xx);

        }
        else
        {
            this.transform.position = new Vector2(3, 2);
        }

    }
}
