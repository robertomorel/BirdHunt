using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextMultiIdioma : MonoBehaviour
{
    string language;
    string newText;
    public string constante = "";

    private void OnEnable()
    {
        try
        {
            language = MultiIdiomaManager.instance.languageAtual;

            MultiIdiomaManager.instance.texts.TryGetValue(language + constante, out newText);

            TextMeshProUGUI tmpro = gameObject.GetComponent<TextMeshProUGUI>();
            Text t = gameObject.GetComponent<Text>();

            if (tmpro != null && !tmpro.text.Equals(newText))
            {
                tmpro.text = newText;
            }
            else
            {
                if (t != null && !t.text.Equals(newText))
                {
                    t.text = newText;
                }
            }
        }
        catch (System.Exception)
        {
            Debug.Log("ERROR = " + language);
        }
        
    }

}
