using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    [SerializeField]
    public GameObject player;
    public float _yOffset = 10.0f;
    public float _zOffset = 5.5f;
    public float _xOfset = 0.0f;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float newXPosition = player.transform.position.x - offset.x;
        //float newZPosition = player.transform.position.z - offset.z;
        this.transform.position = new Vector3(
            player.transform.position.x, 
            player.transform.position.y + _yOffset, 
            player.transform.position.z - _zOffset
            );
    }
}
