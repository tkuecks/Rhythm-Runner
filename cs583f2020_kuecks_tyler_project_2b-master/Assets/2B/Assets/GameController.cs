using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public InputField myJson;
    // Start is called before the first frame update
    void Start()
    {
        myJson.text = PlayerManager.Instance.json;
        PlayerManager.Instance.json = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
