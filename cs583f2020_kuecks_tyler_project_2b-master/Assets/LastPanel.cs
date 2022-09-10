using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LastPanel : MonoBehaviour
{
    public PlayerController player;
    public int bottomOfScreen = -6;
    public int mInc;
    public int mDec;
    public int speed = 4;
    public float xPos;
    public AudioSource hitEffect;
    public AudioSource missEffect;
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            hitEffect.Play();
            var pCont = other.GetComponent<PlayerController>();
            if(pCont.bar.currentMeter <= pCont.maxMeter - mDec)
            {
                pCont.bar.currentMeter += mInc;
            }
            else if(pCont.bar.currentMeter <= pCont.maxMeter)
            {
                pCont.bar.currentMeter = (int) pCont.maxMeter;
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        speed *= 2;
        xPos = (float) ((transform.position.x - 0.7)/2 + 0.7);
        transform.position = new Vector2(xPos,transform.position.y);
        mInc = 3;
        mDec = 10;
        bottomOfScreen = -8;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.position.y <= bottomOfScreen){
            player.bar.currentMeter -= mDec;
            missEffect.Play();
            if(player.bar.currentMeter >= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(gameObject);
        }
    }
}
