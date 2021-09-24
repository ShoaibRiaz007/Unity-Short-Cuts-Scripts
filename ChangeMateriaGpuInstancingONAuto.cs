using System.Linq;
using UnityEditor;
using UnityEngine;

public class ChangeMateriaGpuInstancingONAuto : Editor
{
    private static void ChangeInstance(Material material)
    {

        //Undo.RecordObject(rectTransform, "Anchor UI Object");
        if (!material.enableInstancing)
        {
            try
            {
                material.enableInstancing = true;
                Debug.Log("Success ------ =>" + material.name + " --------  " + count++);
            }
            catch
            {
                Debug.Log("Failled ------ =>" + material.name);
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
