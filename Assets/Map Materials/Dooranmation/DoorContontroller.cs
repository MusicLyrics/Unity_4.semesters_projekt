using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorContontroller : MonoBehaviour
{
    Animator _doorAnimation;

    private void OnTriggerEnter(Collider other)
    {
        _doorAnimation.SetBool("IsOpen", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        _doorAnimation = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
