using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Rigidbody rb;
    public  FixedJoystick joybutton1, joybutton2;
    public GameObject food , bomb,lose,win;
    public float cameraangle;
    int score;
    public Text scoretext;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
    }
    void Start()
    {
      
        InvokeRepeating(nameof(spawnfood), 1,5);
        InvokeRepeating(nameof(spawnbomb), 1, 7);

    }

   
    void Update()
    {
        rb.velocity = new Vector3(joybutton1.Horizontal * 10f, rb.velocity.y, joybutton1.Vertical * 10f);
        transform.Rotate ( joybutton2.Vertical * 5f, rb.velocity.y, joybutton2.Horizontal * 5f);
        
        scoretext.text = "Score : " + score;
        if(score == 10)
        {
            win.SetActive(true);
        }

    }

    void spawnfood()
    {
        Vector3 pos1 = new Vector3(Random.Range(-4f, 2f), Random.Range(1.4f, 1.5f), Random.Range(0.2f, -7f));



        Instantiate(food, pos1, Quaternion.identity);

    }
    void spawnbomb()
    {
        Vector3 pos1 = new Vector3(Random.Range(-4f, 1f), Random.Range(1.4f, 1.5f), Random.Range(0.1f, -5f));



        Instantiate(bomb, pos1, Quaternion.identity);

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("food"))
        {
            Destroy(col.gameObject);
            score++;
           
        }
        if (col.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            lose.SetActive(true);

        }

    }


}
