using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour {
    private int contador = 0;
    private int limite;

    private void OnTriggerEnter2D(Collider2D other) {
        DragDrop dd = other.GetComponent<DragDrop>();
        if (dd != null) {
            dd.prontoContar = true;
            dd.ResetGravityScale();
            contador++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (contador >= limite) {
            GetComponent<BoxCollider2D>().isTrigger = false;
            GeradorConta.Instance.DesativarTrigger();
        }
    }

    public void SetQuantidade(int quantidade) {
        limite = quantidade;
    }
}
