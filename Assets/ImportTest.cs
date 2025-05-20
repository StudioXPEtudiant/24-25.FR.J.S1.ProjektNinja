using UnityEngine;
using Siccity.GLTFUtility;

public class GLTFImporter : MonoBehaviour {
    void Start() {
        string path = Application.dataPath + "/MAIN/ninja v2.gltf";
        GameObject importedObject = Importer.LoadFromFile(path);
        if (importedObject != null) {
            importedObject.transform.position = Vector3.zero;
            Debug.Log("Modèle importé avec succès !");
        } else {
            Debug.LogError("Échec de l'importation du modèle.");
        }
    }
}