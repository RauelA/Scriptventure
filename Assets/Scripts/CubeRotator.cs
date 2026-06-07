using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    public float RotationMaxValue;

    private Vector3 _rotationBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        _rotationBehaviour = new Vector3(RotationMaxValue, RotationMaxValue, 0);

        //transform.Rotate(new Vector3(Random.value * 360f, Random.value * 360f, Random.value * 360f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotationBehaviour);
    }
}
