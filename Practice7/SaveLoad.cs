using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Practice7
{
    internal class SaveLoad
    {
        public static void SaveJson(string jsonPath, List<string> comments)
        {
            string jsonString = JsonSerializer.Serialize(comments);
            try
            {
                // Тут файл удаляется, так как по какой-то причине неправильно перезаписываются json и bin файлы
                File.Delete(jsonPath);
                using (FileStream saveFile = new FileStream(jsonPath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter jsonWritter = new StreamWriter(saveFile))
                    {
                        jsonWritter.Write(jsonString);
                    }
                }
            } catch
            {
                using (FileStream saveFile = new FileStream(jsonPath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter jsonWritter = new StreamWriter(saveFile))
                    {
                        jsonWritter.Write(jsonString);
                    }
                }   
            }
        }

        public static Comments LoadJson(string jsonPath)
        {
            if (File.Exists(jsonPath))
            {
                using (FileStream loadFile = new FileStream(jsonPath, FileMode.Open))
                {
                    using (StreamReader jsonReader = new StreamReader(loadFile))
                    {
                        string jsonString = jsonReader.ReadToEnd();

                        Comments comments = new Comments();

                        List<string> tempComments = JsonSerializer.Deserialize<List<string>>(jsonString);

                        foreach (string comment in tempComments)
                        {
                            comments.AddComment(comment);
                        }

                        return comments;
                    }
                }
            } else
            {
                Comments comments = new Comments();
                return comments;
            }
        }

        public static void SaveBin(string binPath, List<string> comments)
        {
            try
            {
                File.Delete(binPath);
                using (FileStream binFile = new FileStream(binPath, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter writer = new BinaryWriter(binFile, Encoding.Default))
                    {
                        foreach (string comment in comments)
                        {
                            writer.Write(comment);
                        }
                    }
                }
            } catch
            {
                using (FileStream binFile = new FileStream(binPath, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter writer = new BinaryWriter(binFile, Encoding.Default))
                    {
                        foreach (string comment in comments)
                        {
                            writer.Write(comment);
                        }
                    }
                }
            }
        }

        public static Comments BinLoad(string binPath)
        {
            if (File.Exists(binPath))
            {
                using (FileStream binFile = new FileStream(binPath, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(binFile, Encoding.Default))
                    {
                        Comments comments = new Comments();
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            string comment = reader.ReadString();
                            comments.AddComment(comment);
                        }
                        return comments;
                    }
                }
            } else
            {
                Comments comments = new Comments();
                return comments;
            }
        }
    }
}
