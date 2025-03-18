using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    Vector3 dir;

    private void Update()
    {
        dir.z = player.eulerAngles.y;
        transform.localEulerAngles = dir;
    }

}
