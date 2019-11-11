using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject food = GameObject.FindGameObjectWithTag("Food");

        // If there is food in play, move towards the food
        if (food != null)
        {
            Vector3 moveToFood = (food.transform.position - transform.position).normalized;
            enemyRb.AddForce(moveToFood * speed, ForceMode.Impulse);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the enemy collides with the food, eat the food and increase enemy count
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy got the food");
        }
    }
}
