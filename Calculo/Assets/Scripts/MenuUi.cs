using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using  UnityEditor;
#endif

public class MenuUi : MonoBehaviour {
    public void IniciarAdicao() {
        SceneManager.LoadScene("Adicao");
    }

    public void IniciarSubtracao() {
        SceneManager.LoadScene("Subtracao");
    }

    public void Reiniciar() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Voltar() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Sair() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }
}
