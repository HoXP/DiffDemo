using System.IO;
using UnityEditor;
using UnityEngine;

public class PatchEditor : EditorWindow
{
    private const string ext = ".zip";

    [MenuItem("Tools/Diff File")]
    public static void DiffFile()
    {
        string basePath = Application.dataPath + "/../";
        string oldFile = basePath + "Diff/old" + ext;
        string newFile = basePath + "Diff/new" + ext;
        string patchFile = basePath + "Diff/patch";
        if (File.Exists(oldFile) == false || File.Exists(newFile) == false)
        {
            Debug.Log("cant find file oldFile=" + oldFile + ";newFile=" + newFile);
            return;
        }
        FileManager.DeleteFile(patchFile);

        string[] list = new string[4];
        list[0] = "bsdiff";
        list[1] = oldFile;
        list[2] = newFile;
        list[3] = patchFile;
        Debug.Log("oldFile ===" + oldFile);
        Debug.Log("newFile ===" + newFile);
        Debug.Log("patchFile ===" + patchFile);
        int value = DllManager.StartDiff(oldFile, newFile, patchFile);
        Debug.Log("DiffFile ===" + value);
    }

    [MenuItem("Tools/Patch File")]
    public static void PatchFile()
    {
        string basePath = Application.dataPath + "/../";
        string oldFile = basePath + "Diff/old" + ext;
        string outFile = basePath + "Diff/out" + ext;
        string patchFile = basePath + "Diff/patch";
        if (File.Exists(oldFile) == false || File.Exists(patchFile) == false)
        {
            Debug.Log("cant find file oldFile=" + oldFile + ";patchFile=" + patchFile);
            return;
        }
        FileManager.DeleteFile(outFile);
        string[] list = new string[4];
        list[0] = "bspatch";
        list[1] = oldFile;
        list[2] = outFile;
        list[3] = patchFile;
        Debug.Log("oldFile ===" + oldFile);
        Debug.Log("outFile ===" + outFile);
        Debug.Log("patchFile ===" + patchFile);
        int value = DllManager.StartPatch(oldFile, outFile, patchFile);
        Debug.Log("PatchFile ===" + value);
    }
}