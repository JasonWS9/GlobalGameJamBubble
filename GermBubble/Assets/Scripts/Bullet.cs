using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        //Check to see if hitting enemy/destroy enemy
    }



}
