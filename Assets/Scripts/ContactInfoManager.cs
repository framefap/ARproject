using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class ContactInfoManager : MonoBehaviour
{
    
    public GameObject ContactInfo;
    public GameObject CallingPanel;
    public GameObject CallingUserPanel;

    Sprite profilepicture;
    string doctorName;
    string specialty;
    string hospital;
    string language;

    public void GetContactInfo()
    {
        profilepicture = gameObject.GetComponentInChildren<Image>().sprite;
        doctorName = gameObject.name;
        

        switch (doctorName)
        {
            case "Sommai S.":

                specialty = "Obstetrics and Gynaecology";
                hospital = "Siam Hospital";
                language = "Thai, English";
                break;

            case "Sorravit A.":

                specialty = "Psychiatry";
                hospital = "Kalaland Hospital";
                language = "Thai, English";
                break;

            case "Siri B.":

                specialty = "Neurology";
                hospital = "Sawasdee Hospital";
                language = "Thai, English";
                break;

            case "Alice W.":

                specialty = "Pediatric";
                hospital = "Sawasdee Hospital";
                language = "English";
                break;

            case "Michael J.":

                specialty = "Ophthalmology";
                hospital = "Positive Hospital";
                language = "English, French";
                break;

            case "Keith C.":

                specialty = "Cardiology";
                hospital = "Siam Hospital";
                language = "Thai, English";
                break;

            case "Paisarn L.":

                specialty = "Obstetrics and Gynaecology";
                hospital = "Krungthep Hospital";
                language = "Thai, English";
                break;

            case "Room 602":

                specialty = "-";
                hospital = "-";
                language = "-";
                break;
        }

        Debug.Log(doctorName);

        ContactInfo.transform.GetChild(0).GetComponentInChildren<Image>().sprite = profilepicture;
        ContactInfo.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = doctorName;
        ContactInfo.transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = specialty;
        ContactInfo.transform.GetChild(2).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = hospital;
        ContactInfo.transform.GetChild(3).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = language;

    }

    public void CallToContact()
    {

        CallingPanel.transform.GetChild(1).GetComponent<Image>().sprite = ContactInfo.transform.GetChild(0).GetComponentInChildren<Image>().sprite;
        CallingPanel.transform.GetChild(2).GetComponent<Image>().sprite = ContactInfo.transform.GetChild(0).GetComponentInChildren<Image>().sprite;
        CallingPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = ContactInfo.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;

        CallingUserPanel.transform.GetChild(0).GetComponent<Image>().sprite = ContactInfo.transform.GetChild(0).GetComponentInChildren<Image>().sprite;
        CallingUserPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ContactInfo.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
    }
}
