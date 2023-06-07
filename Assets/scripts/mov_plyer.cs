 using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mov_plyer : MonoBehaviour
{
    float mvh,mvv;
    Rigidbody rg;
    float player_f=1000f;
    private int score;
    //public Text scoretext;
    public TextMeshProUGUI scoretext;
    float force_p=500f, JumpForce=5f;
    bool groundCheck = true;
    Vector3 jumpVect;




    // Start is called before the first frame update
    void Start()
    {
        rg=GetComponent<Rigidbody>();
        score=0;
        jumpVect = new Vector3(0, JumpForce, 0);

    }

    // Update is called once per frame
    void Update()
    {
        mvh=Input.GetAxis("Horizontal");
        mvv=Input.GetAxis("Vertical");
        Vector3 mv=new Vector3 (mvh,0,mvv);
        rg.AddForce(mv*player_f*Time.deltaTime);
   
        if (Input.GetKeyDown(KeyCode.Space)&&groundCheck==true)
        {
            rg.velocity = jumpVect;
            groundCheck = false;
        }
    }


         void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("green"))
            {
                Destroy(other.gameObject);
                score=score+5;
                scoretext.text="score"+score;
            }
            if (other.gameObject.CompareTag("red"))
            {
                Destroy(other.gameObject);
                score=score-5;
                scoretext.text="score"+score;
            }
        }

        void OnCollisionEnter (Collision collision )
        {
            if (collision.gameObject.CompareTag("gound"))
            {
                groundCheck=true;
            }
        }
}