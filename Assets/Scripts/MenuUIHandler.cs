using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;  //  CONTROLA O FLUZO DE CENAS 
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;  // diz por jogo ei  a cor do main m e essa aqui o 
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);  // pega a cor  que esta no  main magner caso  ja tenha uma salva 
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        MainManager.Instance.SaveColor(); //quando sair do aap sava a cor escolhida 
#if UNITY_EDITOR // INSTRUÇAO PARA COLILADOR SAO DESSE JEITO 
        EditorApplication.ExitPlaymode();  // MEIO  OBIVIO O QUE FAZ SAI DO MODO PLAY 
#else //INSTRUÇAO PARA O COPILADOR SAO DESSE JEITO   TEMO HASTAG
        Application.Quit(); // original code to quit Unity player
#endif
    }
    public void SaveColorClicked() //quando o save color for clikado 
    {
        MainManager.Instance.SaveColor(); // ele salva a cor
    }

    public void LoadColorClicked() //qunado load color e clikado 
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor); // quando  load cornor e clikado 
    }

}
