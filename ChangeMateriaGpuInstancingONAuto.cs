using System.Linq;
using UnityEditor;
using UnityEngine;

public class ChangeMateriaGpuInstancingONAuto : Editor
{
    private static void ChangeInstance(Material material)
    {

        
        if (!material.enableInstancing)
        {
            try
            {
                Undo.RecordObject(material, "Assigning enableInstancing");
                material.enableInstancing = true;
                Debug.Log("<color=green>Successfully Enable ------ </color> =>" + material.name + " --------  " + count++);
            }
            catch
            {
                 Debug.Log("<color=red>Failled ------ </color> =>" + material.name);
            }
           
        }
       
    }
    private static int count = 0;
    [MenuItem("SH Custom/Performence/Set GPU Instancing of All material In Scene _F3")]//with short key
    private static void EnableInstancingOffAllMaterial()
    {
        Material[][] materials = GameObject.FindObjectsOfType<MeshRenderer>().Select(a => a.sharedMaterials).ToArray();
        for (int i = 0; i < materials.Length; i++)
        {
            for(int j = 0; j < materials[i].Length; j++)
            {
                ChangeInstance(materials[i][j]);
            }
        }
    }

    [MenuItem("SH Custom/Performence/Set GPU Instancing of Selected Material In Scene _F4")]//with short key
    private static void EnableInstancingOffSelectedMaterial()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            Material[] materials = Selection.gameObjects[i].GetComponent<MeshRenderer>().sharedMaterials;
            for (int j = 0; j < materials.Length; j++)
            {
                ChangeInstance(materials[j]);
            }
        }
    }


}
