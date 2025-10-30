using UnityEngine;

public class MaskPlacement : MonoBehaviour
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
            switch (MaskNumber)
            {
                case 1:
                    if (gameManager.Mask1Obtained)
                    {
                        ItemClose = true;
                    }
                    break;
                case 2:
                    if (gameManager.Mask2Obtained)
                    {
                        ItemClose = true;
                    }
                    break;
                case 3:
                    if (gameManager.Mask3Obtained)
                    {
                        ItemClose = true;
                    }
                    break;
            }
        }
        else
        {
            ItemClose = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && ItemHovered)
        {
            switch (MaskNumber)
            {
                case 1:
                    gameManager.Mask1Placed = true;
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    PressE.SetActive(false);
                    break;
                case 2:
                    gameManager.Mask2Placed = true;
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    PressE.SetActive(false);
                    break;
                case 3:
                    gameManager.Mask3Placed = true;
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    PressE.SetActive(false);
                    break;
            }
        }
    }

    private void OnMouseOver()
    {
        if (ItemClose)
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
