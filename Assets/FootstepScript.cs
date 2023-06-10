using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR; 

public class FootstepScript : MonoBehaviour
{

    public GameObject footstep;


    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)!= Vector2.zero) //��ƽ �����϶�
        {
            footsteps();
        }

        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) == Vector2.zero)//��ƽ �ȿ����� ��
        {
            Stopfootsteps();
        }

    }

    void footsteps()
    {
        footstep.SetActive(true);
    }
    void Stopfootsteps()
    {
        footstep.SetActive(false);
    }
}
