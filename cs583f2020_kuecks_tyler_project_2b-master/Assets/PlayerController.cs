using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 newPos;
    private Rigidbody2D rb;
    public Meter bar;
    public Score playerScore;
    public AudioSource track;
    public float maxMeter = 100;
    public Camera cam;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
        rb = GetComponent<Rigidbody2D>();
        bar = GameObject.Find("Meter").GetComponent<Meter>();
        playerScore = GameObject.Find("Score").GetComponent<Score>();
        bar.SetMaxMeter((int) maxMeter);
        bar.SetMeter((int) bar.currentMeter);

    }
    void FixedUpdate(){
        /*
        var rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if(rawPosition.x >= -5.5 & rawPosition.x <= 6.1)
        {
            newPos = new Vector2(rawPosition.x, transform.position.y);
            transform.position = newPos;
        }
        */
    }
    // Update is called once per frame
    void Update()
    {   
        var rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if(rawPosition.x >= -5.5 & rawPosition.x <= 6.1)
        {
            newPos = new Vector2(rawPosition.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newPos, 35f * Time.deltaTime);
        }
        bar.SetMeter((int) bar.currentMeter);
        playerScore.setScore((int) playerScore.currentScore);
        if(bar.currentMeter <= 0){
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
