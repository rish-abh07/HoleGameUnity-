using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float size ;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0;
    }
    public float GetSize()
    {
        return size;
    }
}
