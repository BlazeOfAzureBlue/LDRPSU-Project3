using UnityEngine;

public class MaskPickup : MonoBehaviour
{
    public GameObject player;
    public GameManager gameManager;
    public GameObject PressE;
    public int MaskNumber;
    private bool ItemClose;
    private bool ItemHovered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            ItemClose = true;

        }
        else
        {
            ItemClose = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && ItemHovered)
        {
            switch(MaskNumber)
            {
                case 1:
                    gameManager.Mask1Obtained = true;
                    PressE.SetActive(false);
                    Destroy(gameObject);
                    break;
                case 2:
                    gameManager.Mask2Obtained = true;
                    PressE.SetActive(false);
                    Destroy(gameObject);
                    break;
                case 3:
                    gameManager.Mask3Obtained = true;
                    PressE.SetActive(false);
                    Destroy(gameObject);
                    break;
            }
        }
    }

    private void OnMouseOver()
    {
        if(ItemClose)
        {
            PressE.SetActive(true);
            ItemHovered = true;
        }
    }

    private void OnMouseExit()
    {
        PressE.SetActive(false);
        ItemHovered = false;
    }
}
