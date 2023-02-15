using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class villeger : MonoBehaviour
{
    

    [SerializeField]
    GameObject player;
    // Start is called before the first frame update

    Vector3 posplayer;
    // Update is called once per frame
    void Update()
    {
        posplayer = player.transform.position;
        //transform.rotation = Quaternion.FromToRotation(transform.right, player.transform.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position), 8f * Time.deltaTime);;


        transform.rotation = Quaternion.Euler(0, Mathf.Atan2(posplayer.x - transform.position.x, posplayer.z - transform.position.z) * Mathf.Rad2Deg - 180,0);
    }

}
