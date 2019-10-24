using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{

    public GameObject normalHennamon;
    public GameObject specialHennamon;

    // Start is called before the first frame update
    void Start()
    {
        normalHennamon = GameObject.Find("Hennamon");
        specialHennamon = GameObject.Find("SpecialHennamon");

        int num = Random.Range(1, 11);

        if (num == 1)
        {
            specialHennamon.SetActive(true);
            normalHennamon.SetActive(false);

        }
        else
        {
            specialHennamon.SetActive(false);
            normalHennamon.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

}
