using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private PlayerSize _playersize;
    
    
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
   {
        if(other.TryGetComponent(out Collectible collectible))
        {
            _playersize.Collectibles(collectible.GetSize());
            Destroy(other.gameObject);
        }
   }
}
