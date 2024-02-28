using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    private Rigidbody rb;

    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveBoomerang());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(6 * direction, 0, 2 * direction);

    }

    IEnumerator MoveBoomerang()
    {
        yield return new WaitForSeconds(2f);
        direction *= -1;
    }
}
