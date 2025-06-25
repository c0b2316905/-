using System.Collections;
using UnityEngine;
using TMPro;

public class ParryEffect : MonoBehaviour
{
    public TextMeshProUGUI popupText;

    public void ShowParryPopup()
    {
        StartCoroutine(ShowPopup());
    }

    IEnumerator ShowPopup()
    {
        popupText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f); 
        popupText.gameObject.SetActive(false);
    }
}