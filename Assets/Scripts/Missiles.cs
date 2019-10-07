using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("deathTimer");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player>() != null && other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

}
