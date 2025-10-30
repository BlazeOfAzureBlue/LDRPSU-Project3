using UnityEngine;

public class flashlightnote : MonoBehaviour
{

    public GameObject flashlightText;


    private void OnTriggerEnter(Collider other)
    {
        flashlightText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        flashlightText.SetActive(false);
        Destroy(gameObject);
    }
}
