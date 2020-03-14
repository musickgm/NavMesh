using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for collectables
/// </summary>
public class Collectable : MonoBehaviour
{
    public enum CollectableType {Coin, Camera, Invisible, Objective};

    public CollectableType collectableType;             //What type of collectable?
    public float rotationValue;                         //How quickly the object should rotate?
    public float coinValue;                             //How much value is the coin? 
    public AudioClip _clip;                             //Audio clip associated with collecting this item
    public GameManager gameManager;                     //Reference to the gamemanager



    // Update is called once per frame
    void Update()
    {
        //Rotate the collectable every frame
        transform.Rotate(new Vector3(0, rotationValue, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the object is a robot...
        if(other.CompareTag("AI"))
        {

            //Tell the game manager the type of object collected and the sfx to play.
            gameManager.CollectItem(coinValue, _clip);

            //Then destroy this object
            Destroy(gameObject);
        }
    }
}
