using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getKey : MonoBehaviour
{
    public Canvas selecaoPersonagem;
    public Canvas telaInicial;

    private void Start()
    {
        selecaoPersonagem.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            selecaoPersonagem.enabled = true;
        }
    }
}
