using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Paddle : MonoBehaviour

    
{
    //Config Params
    [SerializeField] float screenWidthInUnits =16f;
    [SerializeField] float xMin = 1.28f;
    [SerializeField] float xMax = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        float mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
   
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, xMin, xMax);
        transform.position = paddlePos;
    }
}
