using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float screenPositionFollowThreshold;
    [SerializeField] private float moveSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 difference;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        PlayerTimer.OntimerOver += DisableMovement;
        GameManager.onStateChanged += GameStateChangedCallBack;
    }
    private void OnDestroy()
    {
        PlayerTimer.OntimerOver -= DisableMovement;
        GameManager.onStateChanged -= GameStateChangedCallBack;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
           ManageControl();
    }
    private void ManageControl()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Calculate the difference in ScreenPosition
            Vector3 diffrence = Input.mousePosition - clickedScreenPosition;
            Vector3 direction = diffrence.normalized;

            float maxScreenDistance = screenPositionFollowThreshold * Screen.height;
            if(diffrence.magnitude > maxScreenDistance)
            {
                clickedScreenPosition = Input.mousePosition - direction * maxScreenDistance;                
                difference = Input.mousePosition - clickedScreenPosition;
                
            }
            diffrence /= Screen.width;
           
            
            diffrence.z = diffrence.y;
            diffrence.y = 0;
            
            Vector3 playerTargetPosition = transform.position + diffrence * moveSpeed * Time.deltaTime;
            transform.position = playerTargetPosition;
        }
    }
   private void GameStateChangedCallBack(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GAME:
                EnableMovement();
                break;
        }
    }
    private void EnableMovement()
    {
        canMove = true;
    }

    private void DisableMovement()
    {
        canMove = false;
    }
}
