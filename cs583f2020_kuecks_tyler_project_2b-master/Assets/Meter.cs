using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Meter : MonoBehaviour
{
    private static Meter instance;
    public static Meter Instance {get {return instance;} }
    public Slider meterBar;
    public float currentMeter = 50;
    public void SetMeter(int myMeter){
        meterBar.value = myMeter;
        currentMeter = myMeter;
    }

    public void SetMaxMeter(int myMaxMeter){
        meterBar.maxValue = myMaxMeter;
    }
    private void SceneChanged(Scene arg0, Scene arg1)
    {
        GameObject temp = GameObject.Find("MeterBar");
        if (temp != null)
            meterBar = temp.GetComponent<UnityEngine.UI.Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        meterBar = GameObject.Find("MeterBar").GetComponent<UnityEngine.UI.Slider>();
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
