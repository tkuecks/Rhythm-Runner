using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private static Score instance;
    public static Score Instance {get {return instance;} }
    public Text scoreVal;
    public float currentScore = 0;
    public void setScore(int theScore){
        scoreVal.text = theScore.ToString();
    }
    public void incScore(){
        currentScore += 1;
    }

    private void SceneChanged(Scene arg0, Scene arg1)
    {
        GameObject temp = GameObject.Find("ScoreVal");
        if (temp != null)
            scoreVal = temp.GetComponent<UnityEngine.UI.Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreVal = GameObject.Find("ScoreVal").GetComponent<UnityEngine.UI.Text>();
    }

    void Awake()
    {
        if (instance == null & SceneManager.GetActiveScene().buildIndex == 3)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.activeSceneChanged += SceneChanged;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

