using UnityEngine;
using System.Collections;

public class spawnBoxDestruction : MonoBehaviour {

	void OnCollisionEnter (Collision col)
    {     
            Destroy(col.gameObject);        
    }
}
