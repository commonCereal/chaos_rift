using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class ItemController : MonoBehaviour {
    private Transform player;

    // Start is called before the first frame update
    void Start() {
        player = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Make the sprite face the player
        transform.LookAt(player);
        // Make the sprite only rotate on the Y-axis.
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
