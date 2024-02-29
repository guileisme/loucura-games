using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

// Scriptable Object para  guardar as configurações 
[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Configurações do Diálogo - Antonio Mori")]
    public GameObject actor;
    //feito para referenciar prefab do objeto que fala, uma vez que no futuro posso querer que ao diálogar 
    //o objeto que fala mude de animação ou de sprite

    [Header("Diálogo")]
    //Sprite do falador
    public String ActorName;
    public  Sprite ObjetoFalador;
    public String  Sentença;

    public List<Sentences> ListaDeSentenças = new List<Sentences>();

}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profileImage;
    public Languages sentence;

}


[System.Serializable]
public class Languages
{
    public String portuguese;
    public String english;
    public String spanish;
}

#if UNITY_EDITOR
    // esse if permite rodar esse código se esse unity estiver em modo de edição
    [CustomEditor(typeof(DialogueSettings))]
    public class BuilderEditor : Editor
    {
        //esse método é chamado quando o editor é aberto
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            //pega o objeto que está sendo editado
            //ds = DialogueSettings
            DialogueSettings ds = (DialogueSettings)target;
            //cria um novo objeto do tipo linguagens
            Languages um = new Languages();
            //cria um novo objeto do tipo sentenças 
            um.portuguese = ds.Sentença;

            Sentences s = new Sentences();
            s.profileImage = ds.ObjetoFalador;
            s.sentence = um;
            s.actorName = ds.ActorName;

            //adiciona a sentença na lista de sentenças
            if(GUILayout.Button("Adicionar Sentença"))
            {
               if(ds.Sentença != "")
                {
                    ds.ListaDeSentenças.Add(s);
                    ds.ObjetoFalador = null;
                    ds.Sentença = "";


                }
            }

        }
    }


#endif