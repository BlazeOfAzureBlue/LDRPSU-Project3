using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class AngelActivate : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject angel;
    public GameObject player;
    public PlayerController playerController;
    public GameObject BENOTAFRAID;
    public TMP_Text BETERRIFIED;
    public AudioSource angelicchoir;
    private Vector3 position = new Vector3(352.75f, 66.9900055f, 493.449982f);

    private bool AngelActivated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(gameManager.Mask1Placed && gameManager.Mask2Placed && gameManager.Mask3Placed && AngelActivated == false)
        {
            AngelActivated = true;
            angel.SetActive(true);
            BENOTAFRAID.SetActive(true);
            playerController.MoveSpeed = 0f;
            player.transform.position = position;
            angelicchoir.enabled = true;
            StartCoroutine(BeTerrified());
            player.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
    }

    IEnumerator BeTerrified()
    {
        BETERRIFIED.text = "BE NOT AFRAID.";
        yield return new WaitForSeconds(5);
        BETERRIFIED.text = "BE TERRIFIED.";
        yield return new WaitForSeconds(2);
        UnityEngine.Diagnostics.Utils.ForceCrash(ForcedCrashCategory.FatalError);
    }
}
