using System.Runtime.InteropServices;

public class DllManager
{
    [DllImport("bsdiff")]
    public static extern int StartDiff(string oldFile, string newFile, string patch);
    [DllImport("bspatch")]
    public static extern int StartPatch(string oldFile, string outFile, string patch);
}