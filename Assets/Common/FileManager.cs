using System.IO;

public class FileCatchData
{
    public bool state = true;   //操作是否成功
    public string message = ""; //失败之后的信息
    public object data = null ; //需要返回的数据
}
/// <summary>
/// 包外文件管理器
/// </summary>
public class FileManager
{
    /// <summary>
    /// 删除文件
    /// </summary>
    public static FileCatchData DeleteFile(string path)
    {
        FileCatchData fileCatchData = new FileCatchData();
        if(string.IsNullOrEmpty(path))
        {
            fileCatchData.state = false;
            return fileCatchData;
        }
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            fileCatchData.state = true;
        }
        catch (System.Exception e)
        {
            fileCatchData.state = false;
            fileCatchData.message = e.Message;
        }
        return fileCatchData;
    }
}
