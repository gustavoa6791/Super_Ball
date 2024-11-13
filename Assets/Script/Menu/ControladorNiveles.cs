using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorNiveles : MonoBehaviour
{
    public static ControladorNiveles instancia;
    public Button[]botonesNiveles;
    public int desbloquearNiveles;
    // Start is called before the first frame update
    public void awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }
    void Start()
    {
        if (botonesNiveles.Length > 0)
        {
            for (int i = 0; i < botonesNiveles.Length; i++)
            {
                botonesNiveles[i].interactable = false;
            }
            for (int i = 0; i < PlayerPrefs.GetInt("nivelesDesbloqueados", 1); i++)
            {
                botonesNiveles[i].interactable = true;
            }
        }
    }

    public void AumentarNiveles()
    {
        if (desbloquearNiveles > PlayerPrefs.GetInt("nivelesDesbloqueados", 1))
        {
            PlayerPrefs.SetInt("nivelesDesbloqueados", desbloquearNiveles);
        }
    }
}
