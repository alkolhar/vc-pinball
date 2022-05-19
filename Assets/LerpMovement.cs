using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{

    public Vector3 endPosition = new Vector3(5, -1, 0);
    private Vector3 startPosition;
    private float duration = 3f;
    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        float percentage = elapsed / duration;

        transform.position = Vector3.Lerp(startPosition, endPosition, percentage);
    }
}
