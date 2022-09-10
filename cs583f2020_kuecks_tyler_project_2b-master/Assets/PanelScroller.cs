using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScroller : MonoBehaviour
{
    public PlayerController player;
    public int bottomOfScreen = -6;
    public int mInc;
    public int mDec;
    public int speed = 4;
    public float xPos;
    public bool first;
    public AudioSource hitEffect;
    public AudioSource missEffect;
    void OnTriggerEnter2D(Collider2D other){
        if(!first & other.CompareTag("Player")){
            hitEffect.Play();
            var pCont = other.GetComponent<PlayerController>();
            pCont.playerScore.incScore();
            if(pCont.bar.currentMeter <= pCont.maxMeter - mInc)
            {
                pCont.bar.currentMeter += mInc;
            }
            else if(pCont.bar.currentMeter <= pCont.maxMeter)
            {
                pCont.bar.currentMeter = (int)pCont.maxMeter;
            }
                Destroy(gameObject);
        }
        else if(first){
            player.track.Play();
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        speed *= 2;
        xPos = (float) ((transform.position.x - 0.7)/2 + 0.7);
        transform.position = new Vector2(xPos,transform.position.y);
        mInc = 2;
        mDec = 20;
        bottomOfScreen = -8;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.position.y <= bottomOfScreen){
            player.bar.currentMeter -= mDec;
            missEffect.Play();
            Destroy(gameObject);
        }
    }
}
