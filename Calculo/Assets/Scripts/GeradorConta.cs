using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using TMPro;

public class GeradorConta : MonoBehaviour {

    [Serializable]
    public class GenerateEvent : UnityEvent<int> {}
    public BolinhaSpawner spawner;
    public TextMeshProUGUI firstNumber;
    public TextMeshProUGUI secondNumber;
    public GenerateEvent OnGenerateFirst, OnGenerateSecond;
    public UnityEvent OnRespostaCorreta;
    private string resultado;

    private void Start() {
        GenerateNumbers();
    }

    public void GenerateNumbers() {
        int primeiroValor = UnityEngine.Random.Range(1, 10);
        int segundoValor = UnityEngine.Random.Range(1, 10);

        firstNumber.text = primeiroValor.ToString();
        secondNumber.text = segundoValor.ToString();
        resultado = (primeiroValor + segundoValor).ToString();

        spawner.Spawn(primeiroValor + segundoValor);
        OnGenerateFirst?.Invoke(primeiroValor);
        OnGenerateSecond?.Invoke(segundoValor);
    }

    public void ChecarResultado(string _resultado) {
        if (_resultado.Equals(resultado)) {
            OnRespostaCorreta?.Invoke();
            Debug.Log("Acertou!");
        } else {
            Debug.Log("Errou!");
        }
    }
}

