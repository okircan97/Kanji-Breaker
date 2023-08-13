using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour{
    
    // configuration parameters
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 0.88f;
    [SerializeField] float maxX = 15.12f;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame. 
    // A variable paddlePosition is created. It will get its X position from the GetXPos() method on 29th line. minX is the minimum, and maxX is the 
    // maximum value it could get. And lastly, the paddle will get its position according to the paddlePosition.
    void Update(){
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);    
        transform.position = paddlePosition;                      // 
    }


    // if IsAutoPlayEnabled() returns 1, the autoplay will be on, and the paddle will follow the x coordinate of the ball. (line 31)
    // if it is not enabled, then the paddle will follow the mouse. (line 34)
    private float GetXPos() {
        //if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled()) {
        //    return FindObjectOfType<Ball>().transform.position.x;  
        //}
        //else {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        //}
    }
}
