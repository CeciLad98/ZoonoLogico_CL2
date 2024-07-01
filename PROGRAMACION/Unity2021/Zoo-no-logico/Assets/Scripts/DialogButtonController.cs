using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogButtonController : MonoBehaviour
{
    public GameObject currentGameObject; // El GameObject actual que ser� desactivado
    public GameObject targetGameObject;  // El GameObject que ser� activado
    public Button nextButton;            // El bot�n que se resaltar�
    public Color highlightColor = Color.yellow; // Color del resalte
    public float blinkDuration = 0.5f;   // Duraci�n del parpadeo

    private Color originalColor;         // Color original del bot�n
    private bool isBlinking = false;

    void Start()
    {
        if (nextButton != null)
        {
            originalColor = nextButton.GetComponent<Image>().color;
        }
    }

    public void ActivateNext()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(true); // Activa el GameObject objetivo
        }

        if (currentGameObject != null)
        {
            currentGameObject.SetActive(false); // Desactiva el GameObject actual
        }

        // Detener el parpadeo y resetear el color del bot�n
        StopBlinking();
    }

    public void HighlightButton()
    {
        if (nextButton != null && !isBlinking)
        {
            StartCoroutine(BlinkButton());
        }
    }

    private IEnumerator BlinkButton()
    {
        isBlinking = true;
        while (true)
        {
            nextButton.GetComponent<Image>().color = highlightColor;
            yield return new WaitForSeconds(blinkDuration);
            nextButton.GetComponent<Image>().color = originalColor;
            yield return new WaitForSeconds(blinkDuration);
        }
    }

    private void StopBlinking()
    {
        isBlinking = false;
        StopAllCoroutines();
        if (nextButton != null)
        {
            nextButton.GetComponent<Image>().color = originalColor;
        }
    }
}
