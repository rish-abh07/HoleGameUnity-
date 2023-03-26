using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class CameraManager : MonoBehaviour
{
    [Header(" Element ")]
    [SerializeField] private CinemachineVirtualCamera cam;

    [Header("Settings")]
    [SerializeField] private float minDis;
    

  
    [SerializeField]private float distanceMutliplier;

    // Start is called before the first frame update
    void Start() 
    { 
        PlayerSize.onIncrease += PlayerSizeIncreased;
    }
    private void OnDestroy()
    {
        PlayerSize.onIncrease -= PlayerSizeIncreased;
    }
    private void PlayerSizeIncreased(float playerSize)
    {
        float distance = minDis + (playerSize - 1) * distanceMutliplier;
        Vector3 targetCameraoffset = new Vector3(0, distance * 1.5f, -distance);
       LeanTween.value(gameObject, getFollowOffset(),targetCameraoffset, .5f *Time.deltaTime * 60).setOnUpdate((Vector3 offset) => cam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = offset);
         
    }
    private Vector3 getFollowOffset()
    {
        return cam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }
}