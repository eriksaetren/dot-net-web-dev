using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

namespace PlanSimplyByCJ.FileHandler
{
    public class CSVHandler
    {
        public static Hashtable csvToHash(string path)
        {
            Hashtable result = new Hashtable();

            try
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    var index = line.IndexOf(',');
                    if(index > 0) { 
                        var key = line.Substring(0, index);
                        var val = line.Substring(index + 1);
                        result.Add(key, val);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("ERROR PARSING CSV LINE: " + line);
                    }
                    //System.Diagnostics.Debug.WriteLine(key + ":\t" + val);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.InnerException + "\t" + e.Message);
            }


            return result;
        }
    }
}