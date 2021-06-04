using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    int time = 20;
    int hp = 100;
    public Text timerText;
    public Text hpText;
    
    float vert;
    float horiz;
    Transform cube_tr;
    Rigidbody cube_rb;
    void Timer()
    {
        time = time - 1;
        timerText.text = "TIMER: "+time;
    }
    void Start()
    {
        InvokeRepeating("Timer",1f,1f);
        cube_tr = GetComponent<Transform>();
        cube_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxis("Vertical") * 4f;
        horiz = Input.GetAxis("Horizontal") * 0.4f;
        cube_rb.AddForce(cube_tr.forward * vert);
        cube_tr.Rotate(0,horiz,0);
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "enemy")
        {
            hp = hp - 30;
            hpText.text = "HP: "+hp;
        }
    }
}
