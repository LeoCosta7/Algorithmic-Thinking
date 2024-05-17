using StrategyPOC.Enums;
using StrategyPOC.Messages;

namespace StrategyPOC.Util
{
    public class Utilities
    {
        private static StreamReader sr;
        private static List<string> readLines;


        public static string GetParameterValue(string file, string param)
        {

            string line;

            try
            {
                VerifyCurrentFileStatus(file);

                if (readLines == null)
                    readLines = new List<string>();
                else
                {
                    string pastLine = SearchValueFromPastLine(readLines, param);

                    if (pastLine != null)
                        return GetValueFromLine(pastLine);
                }


                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Contains(param))
                        return GetValueFromLine(line);

                    readLines.Add(line);
                }

                throw new Exception(MsgFile.MSG002);                                    //TypeNotFound

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void VerifyCurrentFileStatus(string file)
        {

            bool srStatus = sr != null;
            bool currentFile = sr.BaseStream != File.OpenRead(file);

            if(srStatus)
                sr.Close();
            else if (currentFile)
            {
                sr = new StreamReader(file);
                readLines = new List<string>();
            }
        }

        private static string GetValueFromLine(string line)
        {
            return line.Substring(7).Trim();
        }

        private static string SearchValueFromPastLine(List<string> line, string param)
        {
            return line.Select(x => x.Contains(param)).ToString();
        }
    }
}
