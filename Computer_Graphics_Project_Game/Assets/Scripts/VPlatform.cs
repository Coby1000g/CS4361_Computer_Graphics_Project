using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VPlatform : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;

    public float Speed = 5f;
    public float moveDist = 10f;
    public bool towaredsEnd = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = transform.position + new Vector3(0, moveDist, 0);

        StartCoroutine(Platform());

    }


    IEnumerator Platform()
    {
        while (true)
            if (towaredsEnd)
            {
                while (transform.position != endPos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPos, Speed * Time.deltaTime);
                    yield return null;
                }
                yield return new WaitForSeconds(2);
                towaredsEnd = false;
            }
            else
            {
                while (transform.position != startPos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, startPos, Speed * Time.deltaTime);
                    yield return null;
                }
                yield return new WaitForSeconds(2);
                towaredsEnd = true;

            }



    }
}
