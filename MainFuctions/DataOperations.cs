using System;
using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.EMMA;
using Recorder.MFCC;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Recorder.MainFuctions;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Bibliography;

public class DataOperations
{
    public static string test_reading_time, train_reading_time, matching_time;

    private string filePath;
    static public String folder = "E:\\Algo\\[2] SPEAKER IDENTIFICATION\\";
    public DataOperations(string excelFilePath)
    {
        filePath = excelFilePath;
    }
    public struct Person_template
    {
        public string name { get; set; }
        public List<Recorder.MFCC.Sequence> sequences { get; set; }

    }

    //static public Dictionary<int, List<Recorder.MFCC.Sequence>> data_base_sequence = new Dictionary<int, List<Recorder.MFCC.Sequence>>();
    //static public Dictionary<int, String> data_base_names = new Dictionary<int, string>();
    static public Dictionary<int, Person_template> data_base_sequence = new Dictionary<int, Person_template>();

    static public Dictionary<int, Person_template> sequenceMap = new Dictionary<int, Person_template>();
    //static public Dictionary<int, String> names_map = new Dictionary<int, string>();
 
    public static void save_js_file(Dictionary<int, Person_template> saved_data, string path)
    {

        var splitpath = path.Split('\\');
        string folderPath = "";
        for (int i = 0; i < splitpath.Length - 1; i++)
        {
            folderPath += splitpath[i] + '\\';
        }
        string filename = splitpath[splitpath.Length - 1];


        Console.WriteLine(path);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        File.WriteAllText(path, JsonConvert.SerializeObject(saved_data, Formatting.Indented));
    }
    public static Dictionary<int, Person_template> read_js_file(string path)
    {

        return JsonConvert.DeserializeObject<Dictionary<int, Person_template>>(File.ReadAllText(path));
    }
}