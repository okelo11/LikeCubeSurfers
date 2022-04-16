using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{  public float speed=5f;
    float horizontal;
    public float forwardSpeed = 10f;
    public GameObject mainCamera;
    public float cameraSpeedX=1f;
    public float cameraSpeedY = 1f;
    public float cameraSpeedZ = 1f;
    public int countOfBoxCollect = 1;
    public AudioSource collectBoxSound;
    public AudioSource removeBoxSound;
    public GameObject Player;
    public Vector3 cameraDistance;
   

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.Translate( Time.fixedDeltaTime * speed * horizontal, 0,forwardSpeed*Time.fixedDeltaTime);
        mainCamera.transform.position = new Vector3(Mathf.Lerp(mainCamera.transform.position.x, Player.transform.position.x + cameraDistance.x, Time.fixedDeltaTime * cameraSpeedX), Mathf.Lerp(mainCamera.transform.position.y, Player.transform.position.y + cameraDistance.y, Time.fixedDeltaTime * cameraSpeedY), Mathf.Lerp(mainCamera.transform.position.z, Player.transform.position.z + cameraDistance.z, Time.fixedDeltaTime * cameraSpeedZ));
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "collectable")
        {
            collectBoxSound.Play();
            other.transform.parent = this.transform;
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<CollectThisBox>().number = countOfBoxCollect; 
            other.transform.localPosition = new Vector3(0, countOfBoxCollect, 0);
            
            countOfBoxCollect += 1;
        }
        if (other.tag == "barrier")
        {
            for (int i = this.transform.childCount; i > this.transform.childCount-other.GetComponent<Barrier>().deleteBoxesNumber; i--)
            {
                removeBoxSound.Play();
                
               Destroy(this.transform.GetChild(i - 1).gameObject);
                
            }
        }
    }
   

}
