using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    Animator anim;

    public double pos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        pos = FindObjectOfType<playerBehavior>().ReturnPos();

        if (pos >= -5)
        {
            Debug.Log("triggered at  " + pos);

            anim.SetTrigger("MakeRed");
        }

    }
}
