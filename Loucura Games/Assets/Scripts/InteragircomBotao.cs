using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteragircomBotao : MonoBehaviour
{
    [SerializeField]
    private JogadorInterage _jogadorInterage;

    [SerializeField]
    private UnityEvent _botaoApertado;

    private bool _podeExecutar;


    // Update is called once per frame
    void Update()
    {
        if (_podeExecutar)
        {
            if(_jogadorInterage.EstaInteragindo == true)
            {
                _botaoApertado.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _podeExecutar = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _podeExecutar = false;

    }
}
