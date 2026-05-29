using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Bai1.Models;

namespace Bai1.Utils
{
    public static class FileHelper
    {
        public static void SaveOverwrite(string path, List<Block> blocks)
        {
            string folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string json = JsonSerializer.Serialize(blocks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, json);
        }

        public static List<Block> LoadBlocks(string path)
        {
            if (!File.Exists(path))
                return new List<Block>();

            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<Block>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Block>();
        }
    }
}