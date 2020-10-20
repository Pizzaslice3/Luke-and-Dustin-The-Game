using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WagieBehavior : MonoBehaviour
{
    public GameObject doomer;
    public SpriteRenderer doomer_SR;

    public GameObject wagie_E;

    public LevelLoader LL;

    public InsideBuildingPlayerMovement IBPM;

    public SpawnPlayerOverWorld SPOW;



    // Start is called before the first frame update
    void Start()
    {
        SPOW = GameObject.Find("OverWorld Manager").GetComponent<SpawnPlayerOverWorld>();
        doomer = GameObject.Find("Doomer_Character");
        doomer_SR = doomer.GetComponent<SpriteRenderer>();
        IBPM = doomer.GetComponent<InsideBuildingPlayerMovement>();
        wagie_E = GameObject.Find("Wagie_E");
        LL = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        SetInteractable();
    }


    public void SetInteractable()
    {
        //checks to see if doomer is facing Wagie and if he is small enough (close enough) to Wagie to trigger Interactable
        if (doomer_SR.flipX != true && doomer.transform.localScale.x < .5f)
        {

            wagie_E.SetActive(true);
        }

        else if(doomer_SR.flipX && doomer.transform.localScale.x > 1f)
        {
            SPOW.SpawnPlayerPosition(new Vector3(125, -5.9f, -10f), true);
            IBPM.canMove = false;
            LL.LoadNextLevel(0);

        }    

        else
        {
            wagie_E.SetActive(false);
        }
    }
}
