using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public int maxammo = 9;
    private int currentammo;

    public GameObject bullet;
    public Transform spawnPoint;
    public float firespeed = 20;
    public AudioSource source;
    public AudioClip firesound;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void FireBullet(ActivateEventArgs arg = null)
    {
        //Plays a fire sound from AudioSource
        source.PlayOneShot(firesound);

        //instantiates a bullet game object at the spawn point
        //and gives it an initial velocity based on the spawn point's forward direction and a firing speed variable
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * firespeed;

        //The bullet will be destoryed after 5seconds
        Destroy(spawnedBullet, 5);
    }
}
