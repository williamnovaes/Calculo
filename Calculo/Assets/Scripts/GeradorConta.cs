using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using TMPro;

public class GeradorConta : MonoBehaviour {
    private static GeradorConta s_Instance;
    public static GeradorConta Instance {
        get {
            if (s_Instance != null) {
                return s_Instance;
            }

            s_Instance = FindObjectOfType<GeradorConta>();
            return s_Instance;
        }
    }

    [Serializable]
    public class GenerateEvent : UnityEvent<int> {}
    public bool isSoma = true;
    public BolinhaSpawner spawner;
    public TextMeshProUGUI firstNumber;
    public TextMeshProUGUI secondNumber;
    public TMP_InputField inputResultado;
    public GenerateEvent OnGenerateFirst, OnGenerateSecond;
    public UnityEvent OnRespostaCorreta, OnRespostaErrada;
    private string resultado;
    private int triggersDesativados = 0;

    private void Awake() {
        if (s_Instance == null) {
            s_Instance = this;
            GenerateNumbers();
        } else {
            Destroy(gameObject);
        }
    }

    public void GenerateNumbers() {
        int primeiroValor = UnityEngine.Random.Range(1, 11);
        int segundoValor = UnityEngine.Random.Range(1, 11);
        
        if (isSoma) {
            firstNumber.text = primeiroValor.ToString();
            secondNumber.text = segundoValor.ToString();
            resultado = (primeiroValor + segundoValor).ToString();
            spawner.Spawn(primeiroValor + segundoValor, isSoma);
            OnGenerateFirst?.Invoke(primeiroValor);
            OnGenerateSecond?.Invoke(segundoValor);
        } else {
            int _maior, _menor;
            if (primeiroValor > segundoValor) {
                _maior = primeiroValor;
                _menor = segundoValor;
            } else {
                _maior = segundoValor;
                _menor = primeiroValor;
            }

            firstNumber.text = _maior.ToString();
            secondNumber.text = _menor.ToString();
            resultado = (_maior - _menor).ToString();
            spawner.Spawn(_maior, isSoma);
        }

        OnGenerateFirst?.Invoke(primeiroValor);
        OnGenerateSecond?.Invoke(segundoValor);
    }

    public void ChecarResultado(string _resultado) {
        if (resultado == null || _resultado.Equals("") || _resultado.Equals(" ")) {
            return;
        }

        if (_resultado.Equals(resultado)) {
            OnRespostaCorreta?.Invoke();
        } else {
            OnRespostaErrada?.Invoke();
        }
    }

    public void HabilitarResultado() {
        if (inputResultado != null) {
            inputResultado.interactable = true;
        }
    }

    public void DesativarTrigger() {
        triggersDesativados++;
        if (triggersDesativados == 2) {
            HabilitarResultado();
        }
    }
}