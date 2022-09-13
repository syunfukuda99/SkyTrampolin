using System.Diagnostics;
using System.Net.Http;
using UnityEditor;
using UnityEditor.Callbacks;
using Debug = UnityEngine.Debug;

namespace Template.Editor
{
    public class SlackPoster
    {
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string path) {
            if (target == BuildTarget.Android) {
                Post(path);
            }
        }

        public static void Post(string path)
        {
            var channel = "game-hc-dating_simulator";
            var cmd = $"~/upload_apk {channel} {path}";

            Debug.Log(cmd);
            var p = new Process();
            p.StartInfo.FileName = "/bin/bash";
            p.StartInfo.Arguments = "-c \" " + cmd + " \"";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            var output = p.StandardOutput.ReadToEnd();
            // var error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            p.Close();
            
            Debug.Log(output);
            // string filePath = "/Users/marurun/main/unity/tileio/tileio.apk";
            // string url = "https://slack.com/api/files.upload";
            //
            // System.Net.WebClient wc = new System.Net.WebClient();
            // wc.Headers.Add("Content-Type", "multipart/form-data");
            // wc.bo
            // byte[] resData = wc.UploadFile(url, filePath);
        }
    }
}