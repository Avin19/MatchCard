using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CardView : MonoBehaviour
{
    [SerializeField] private Image frontImage;

    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;

    [SerializeField] private Button button;
    public float flipDuration = 0.25f;

    private bool isFrontVisible = false;
    public void SetCardVisual(CardData data)
    {
        frontImage.sprite = data.frontSprite;
    }

    public void SetFlipped(bool flipped)
    {
        if (flipped != isFrontVisible)
            StartCoroutine(AnimateFlip(flipped));
        AudioManager.Instance.Play("Flip");
    }
    private IEnumerator AnimateFlip(bool showFront)
    {
        float timer = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 scaleToZero = new Vector3(0, 1, 1);
        Vector3 scaleToFull = new Vector3(1, 1, 1);

        // Step 1: Shrink to zero width
        while (timer < flipDuration)
        {
            float t = timer / flipDuration;
            transform.localScale = Vector3.Lerp(startScale, scaleToZero, t);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = scaleToZero;

        // Swap faces
        front.SetActive(showFront);
        back.SetActive(!showFront);
        isFrontVisible = showFront;

        // Step 2: Expand back to full width
        timer = 0f;
        while (timer < flipDuration)
        {
            float t = timer / flipDuration;
            transform.localScale = Vector3.Lerp(scaleToZero, scaleToFull, t);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = scaleToFull;
    }

    public void SetInteractable(bool interactable)
    {
        button.interactable = interactable;
    }

    public Button CardButton()
    {
        return button;
    }
}
