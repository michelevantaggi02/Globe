using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class testo : MonoBehaviour
{

    private string output;
    // Start is called before the first frame update
    void Start()
    {
        /*Process cmd = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "echo prova";
        cmd.StartInfo = startInfo;
        cmd.Start();
        cmd.WaitForExit();
        Console.WriteLine(cmd.StandardOutput.ReadToEnd());*/
        EseguiProcesso("help");//"C:\\Users\\michi\\Desktop\\prova.bat");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(new Vector3(0, 180, 0));
        
        
    }

    void EseguiProcesso(string prova)
    {
        Process p = new Process();
        // Redirect the output stream of the child process.
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.FileName = "cmd";
        //p.StartInfo.Arguments = "/C " + prova;
        p.Start();
        // Do not wait for the child process to exit before
        // reading to the end of its redirected stream.
        // p.WaitForExit();
        // Read the output stream first and then wait.
        output = p.StandardOutput.ReadToEnd();

        print(prova);
        p.StandardInput.WriteLine(prova);
        p.StandardInput.Flush();
        output = p.StandardOutput.ReadToEnd();
        p.StandardInput.WriteLine("exit");
        p.StandardInput.Flush();
        /*byte[] bytes = Encoding.Default.GetBytes(output);
        output = Encoding.UTF8.GetString(bytes);*/
        print(output);
        CambiaTesto(output);
        p.WaitForExit();
    }

    public void EseguiProcessoFromOggetto(GameObject oggetto)
    {
        EseguiProcesso(oggetto.GetComponent<Text>().text);
    }

    


    public void CambiaTesto(string testo)
    {
        TextMeshPro tmp = GetComponent<TextMeshPro>();
        tmp.text = testo;
        TMPro.TMP_Text nuovo;
        /*if (tmp.isTextOverflowing)
        {
            nuovo = new TMPro.TMP_Text();
            nuovo.GetComponent<TextMeshPro>().font = tmp.font;
            nuovo.GetComponent<TextMeshPro>().color = tmp.color;
            nuovo.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;

            tmp.overflowMode = TextOverflowModes.Linked;
            tmp.linkedTextComponent = nuovo;
        }*/
    }

    public void CambiaTestoFromOggetto(GameObject oggetto)
    {
        GetComponent<TextMeshPro>().text = oggetto.GetComponent<Text>().text;
    }
}
