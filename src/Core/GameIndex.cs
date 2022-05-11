using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IniParser;
using IniParser.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ArchiveCacheManager
{
    public class GameIndex
    {
        private readonly string SelectedFile = "SelectedFile";

        private static IniData mGameIndex = null;

        static GameIndex()
        {
            Load();
        }

        public static void Load()
        {
            string gameIndexPath = PathUtils.GetPluginGameIndexPath();
            mGameIndex = null;

            if (File.Exists(gameIndexPath))
            {
                var parser = new FileIniDataParser();
                mGameIndex = new IniData();

                try
                {
                    mGameIndex = parser.ReadFile(gameIndexPath);
                }
                catch (Exception e)
                {
                    Logger.Log(string.Format("Error parsing game index file from {0}. Deleting invalid file.", gameIndexPath));
                    Logger.Log(e.ToString(), Logger.LogLevel.Exception);
                    File.Delete(gameIndexPath);
                    mGameIndex = null;
                }
            }
        }

        public static void Save()
        {
            string gameIndexPath = PathUtils.GetPluginGameIndexPath();

            if (mGameIndex != null)
            {
                var parser = new FileIniDataParser();

                try
                {
                    parser.WriteFile(gameIndexPath, mGameIndex);
                }
                catch (Exception e)
                {
                    Logger.Log(string.Format("Error saving game index file to {0}.", gameIndexPath));
                    Logger.Log(e.ToString(), Logger.LogLevel.Exception);
                }
            }
        }

        public static string GetSelectedFile(string gameId)
        {
            string selectedFile = string.Empty;

            if (mGameIndex != null && mGameIndex.Sections.ContainsSection(gameId))
            {
                selectedFile = mGameIndex[gameId][nameof(SelectedFile)] ?? string.Empty;
            }

            return selectedFile;
        }

        public static void SetSelectedFile(string gameId, string selectedFile)
        {
            if (mGameIndex == null)
            {
                mGameIndex = new IniData();
            }

            mGameIndex[gameId][nameof(SelectedFile)] = selectedFile;

            Save();
        }

        public static List<string> GetPreferedFile(string gameId)
        {
            List<string> liste_prefered = new List<string>();
            if (mGameIndex != null && mGameIndex.Sections.ContainsSection(gameId))
            {
                if(mGameIndex[gameId].ContainsKey("prefered")){
                    dynamic jobj = JsonConvert.DeserializeObject(mGameIndex[gameId]["prefered"].ToString());
                    foreach (string jstring in jobj)
                    {
                        liste_prefered.Add(jstring);
                    }
                }
            }
            return liste_prefered;
        }

        public static string GetPreferedFileString(string gameId)
        {
            if (mGameIndex != null && mGameIndex.Sections.ContainsSection(gameId))
            {
                if (mGameIndex[gameId].ContainsKey("prefered"))
                {
                    return mGameIndex[gameId]["prefered"].ToString();
                }
            }
            return "";
        }

        public static string[] PreferedStringToArray(string prefered)
        {
            List<string> liste_prefered = new List<string>();
            if(prefered != "")
            {
                dynamic jobj = JsonConvert.DeserializeObject(prefered.ToString());
                foreach (string jstring in jobj)
                {
                    liste_prefered.Add(jstring);
                }
            }
            return liste_prefered.ToArray();
        }

        public static void AddPreferedFile(string gameId, string selectedFile)
        {

            if (mGameIndex == null)
            {
                mGameIndex = new IniData();
            }
            List<string> liste_prefered = GetPreferedFile(gameId);
            if (liste_prefered.Contains(selectedFile) == false)
            {
                liste_prefered.Add(selectedFile);
            }
            mGameIndex[gameId]["prefered"] = JsonConvert.SerializeObject(liste_prefered.ToArray());

            Save();
        }

        public static void RemovePreferedFile(string gameId, string selectedFile)
        {
            if (mGameIndex == null)
            {
                mGameIndex = new IniData();
            }

            List<string> liste_prefered = GetPreferedFile(gameId);
            if (liste_prefered.Contains(selectedFile))
            {
                liste_prefered.Remove(selectedFile);
            }
            mGameIndex[gameId]["prefered"] = JsonConvert.SerializeObject(liste_prefered.ToArray());

            Save();
        }
    }
}
