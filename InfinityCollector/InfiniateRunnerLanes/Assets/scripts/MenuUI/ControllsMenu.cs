using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllsMenu : MonoBehaviour {


    public CanvasGroup Options;
    public CanvasGroup Controlls;

    public Sprite Keys;
    public Sprite controller;

    public Image cImage;

    public Button kButton;
    public Button cButton;
    void Start()
    {

        cButton.interactable = true;
        cButton.gameObject.SetActive(true);
        kButton.interactable = false;
        kButton.gameObject.SetActive(false);


    }
    public void ShowControlls()
    {
        Options.GetComponent<CanvasGroup>().alpha = 0;
        Options.GetComponent<CanvasGroup>().interactable = false;
        Options.GetComponent<CanvasGroup>().blocksRaycasts = false;
        Controlls.GetComponent<CanvasGroup>().alpha = 1;
        Controlls.GetComponent<CanvasGroup>().interactable = true;
        Controlls.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HideControlls()
    {
        Options.GetComponent<CanvasGroup>().alpha = 1;
        Options.GetComponent<CanvasGroup>().interactable = true;
        Options.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Controlls.GetComponent<CanvasGroup>().alpha = 0;
        Controlls.GetComponent<CanvasGroup>().interactable = false;
        Controlls.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void ShowController()
    {
        cImage.transform.GetComponent<Image>().sprite = controller;
        kButton.interactable = true;
        kButton.gameObject.SetActive(true);
        cButton.interactable = false;
        cButton.gameObject.SetActive(false);


    }
    public void ShowKeyboard()
    {
        cImage.transform.GetComponent<Image>().sprite = Keys;
        cButton.interactable = true;
        cButton.gameObject.SetActive(true);
        kButton.interactable = false;
        kButton.gameObject.SetActive(false);
    }





}
