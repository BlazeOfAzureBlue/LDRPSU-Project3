using UnityEngine;

public class note : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    public GameObject PressE;
    private bool ItemClose;
    private bool NoteOpen;
    private bool ItemHovered;
    public GameObject Note;

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Note.activeSelf == true)
            {
                Note.SetActive(false);
                playerController.MoveSpeed = 12f;
            }
            else if(ItemHovered == true)
            {
                Note.SetActive(true);
                playerController.MoveSpeed = 0f;
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
