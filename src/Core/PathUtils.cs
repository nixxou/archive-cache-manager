﻿using System;
using System.Reflection;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Linq;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace ArchiveCacheManager
{

    /// <summary>
    /// Helper class to manage the paths of files used by the plugin.
    /// </summary>
    public class PathUtils
    {
        [DllImport("mpr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int WNetGetConnection(
        [MarshalAs(UnmanagedType.LPTStr)] string localName,
        [MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName,
        ref int length);
        /* There are multiple root paths to be handled:
         * <LaunchBox>\Core\LaunchBox.exe
         * <LaunchBox>\ThirdParty\7-Zip\7z.exe
         */
        public static readonly int MAX_PATH = 260;

        public static Dictionary<string, string> cache_altpath = new Dictionary<string, string>();

        private static readonly string configFileName = @"config.ini";
        private static readonly string gameIndexFileName = @"game-index.ini";
        private static readonly string gameInfoFileName = @"game.ini";
        private static readonly string default7zFileName = @"7z.exe";
        private static readonly string alt7zFileName = @"7-zip.exe";
        private static readonly string tempPath = @"Temp";
        private static readonly string tempArchiveFilename = @"temp.zip";
        private static readonly string restoreSettingsFileName = @"restore-settings.ini";
        private static readonly string relativePluginPath = @"Plugins\ArchiveCacheManager";
        private static readonly string relative7zPath = @"ThirdParty\7-Zip";
        private static readonly string relativeExtractorPath = Path.Combine(relativePluginPath, "Extractors");
        private static readonly string relativeLogPath = Path.Combine(relativePluginPath, "Logs");
        private static readonly DateTime dateTimeNow = DateTime.Now;
        private static readonly string logFileName = string.Format("events-{0}-{1:00}-{2:00}.log", dateTimeNow.Year, dateTimeNow.Month, dateTimeNow.Day);

        private static string assemblyPath;
        private static string assemblyFileName;
        private static string assemblyDirectory;
        private static string launchBoxRootPath;

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        static extern bool PathRelativePathTo([Out] StringBuilder pszPath, [In] string pszFrom, [In] FileAttributes dwAttrFrom, [In] string pszTo, [In] FileAttributes dwAttrTo);

        static PathUtils()
        {
            assemblyPath = Assembly.GetEntryAssembly().Location;
            assemblyFileName = Path.GetFileName(assemblyPath);
            assemblyDirectory = Path.GetDirectoryName(assemblyPath);
            launchBoxRootPath = GetLaunchBoxRootPath();
        }

        /// <summary>
        /// Compares two paths if they are equal.
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns></returns>
        public static bool ComparePaths(string path1, string path2)
        {
            return string.Equals(Path.GetFullPath(path1).TrimEnd(Path.DirectorySeparatorChar),
                                 Path.GetFullPath(path2).TrimEnd(Path.DirectorySeparatorChar),
                                 StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Finds the relative path between pathFrom and pathTo. Leading .\ is removed.
        /// </summary>
        /// <param name="pathFrom"></param>
        /// <param name="pathTo"></param>
        /// <returns>The relative path, or pathTo if there is no common root path.</returns>
        public static string GetRelativePath(string pathFrom, string pathTo)
        {
            string resultPath = pathTo;

            // Paths must have common root to have relative path
            if (Path.GetPathRoot(pathFrom) == Path.GetPathRoot(pathTo))
            {
                StringBuilder relativePath = new StringBuilder(MAX_PATH);
                PathRelativePathTo(relativePath, pathFrom, FileAttributes.Directory, pathTo, FileAttributes.Normal);
                resultPath = relativePath.ToString();

                if (resultPath.StartsWith(@".\"))
                {
                    resultPath = resultPath.Remove(0, 2);
                }
            }

            return resultPath;
        }

        /// <summary>
        /// Returns the absolute path of the input path. Relative paths are to the root LaunchBox folder.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>The absolute path of the input path.</returns>
        public static string GetAbsolutePath(string path)
        {
            if (!Path.IsPathRooted(path))
            {
                path = Path.GetFullPath(Path.Combine(PathUtils.GetLaunchBoxRootPath(), path));
            }

            return path;
        }

        /// <summary>
        /// Determine the LaunchBox root path based on whether this function was called by the plugin, or the Archive Cache Manager exe.
        /// </summary>
        /// <returns></returns>
        public static string GetLaunchBoxRootPath()
        {
            string path;

            // Called from <LaunchBox>\ThirdParty\7-Zip\7z.exe
            if (string.Equals(assemblyFileName, default7zFileName, StringComparison.InvariantCultureIgnoreCase))
            {
                // Call GetFullPath to resolve ..\.. in path
                path = Path.GetFullPath(Path.Combine(assemblyDirectory, @"..\.."));
            }
            // Called from <LaunchBox>\Core\LaunchBox.exe
            else
            {
                // Call GetFullPath to resolve .. in path
                path = Path.GetFullPath(Path.Combine(assemblyDirectory, @".."));
            }

            return path;
        }

        /// <summary>
        /// Absolute path to plugin config file.
        /// </summary>
        /// <returns>Absolute path to plugin config file.</returns>
        public static string GetPluginConfigPath() => Path.Combine(launchBoxRootPath, relativePluginPath, configFileName);

        /// <summary>
        /// Absolute path to game index info file.
        /// </summary>
        /// <returns>Absolute path to plugin game index info file.</returns>
        public static string GetPluginGameIndexPath() => Path.Combine(launchBoxRootPath, relativePluginPath, gameIndexFileName);

        public static string GetTempPath() => Path.Combine(launchBoxRootPath, relativePluginPath, tempPath);

        public static string GetTempArchivePath() => Path.Combine(GetTempPath(), tempArchiveFilename);

        /// <summary>
        /// Absolute path to file which stores temporary settings changes.
        /// </summary>
        /// <returns>Absolute path to temporary settings file.</returns>
        public static string GetRestoreSettingsFilenamePath() => Path.Combine(GetTempPath(), restoreSettingsFileName);

        /// <summary>
        /// Absolute path to 7z.exe.
        /// </summary>
        /// <returns>Absolute path to 7z.exe.</returns>
        public static string GetLaunchBox7zPath()
        {
            string path;

            // Called from <LaunchBox>\ThirdParty\7-Zip\7z.exe
            if (string.Equals(assemblyFileName, default7zFileName, StringComparison.InvariantCultureIgnoreCase))
            {
                path = Path.Combine(launchBoxRootPath, relative7zPath, alt7zFileName);
            }
            // Called from <LaunchBox>\Core\LaunchBox.exe
            else
            {
                path = Path.Combine(launchBoxRootPath, relative7zPath, default7zFileName);
            }

            return path;
        }

        /// <summary>
        /// Absolute path to 7-Zip folder.
        /// </summary>
        /// <returns>Absolute path to 7-Zip folder.</returns>
        public static string GetLaunchBox7zRootPath() => Path.Combine(launchBoxRootPath, relative7zPath);

        /// <summary>
        /// Absolute path to LaunchBox's temporary extraction location.
        /// </summary>
        /// <returns>Absolute path to LaunchBox's temporary extraction location.</returns>
        public static string GetLaunchBox7zTempPath() => Path.Combine(launchBoxRootPath, relative7zPath, "Temp");

        /// <summary>
        /// Absolute path to game info file.
        /// </summary>
        /// <returns>Absolute path to game info file.</returns>
        public static string GetGameInfoPath() => Path.Combine(launchBoxRootPath, relative7zPath, gameInfoFileName);

        /// <summary>
        /// Absolute path to plugin's log folder.
        /// </summary>
        /// <returns>Absolute path to plugin's log folder.</returns>
        public static string GetLogPath() => Path.Combine(launchBoxRootPath, relativeLogPath);

        /// <summary>
        /// Absolute path to plugin's log file.
        /// </summary>
        /// <returns>Absolute path to plugin's log file.</returns>
        public static string GetLogFilePath() => Path.Combine(launchBoxRootPath, relativeLogPath, logFileName);

        /// <summary>
        /// Absolute path to plugin root folder.
        /// </summary>
        /// <returns>Absolute path to plugin root folder.</returns>
        public static string GetPluginRootPath() => Path.Combine(launchBoxRootPath, relativePluginPath);

        /// <summary>
        /// Absolute path to the folder containing the plugin's copy of 7-Zip.
        /// </summary>
        /// <returns>Absolute path to the folder containing the plugin's copy of 7-Zip.</returns>
        public static string GetPlugin7zRootPath() => Path.Combine(launchBoxRootPath, relativePluginPath, "7-Zip");

        /// <summary>
        /// Absolute path to the folder containing the plugin's extractors.
        /// </summary>
        /// <returns>Absolute path to the folder containing the plugin's extractors.</returns>
        public static string GetExtractorRootPath() => Path.Combine(launchBoxRootPath, relativeExtractorPath);

        /// <summary>
        /// Absolute path to the last played file for the given archive cache path.
        /// </summary>
        /// <param name="archiveCachePath">Location of the cached archive.</param>
        /// <returns>Absolute path to the last played file.</returns>
        public static string GetArchiveCachePlaytimePath(string archiveCachePath) => Path.Combine(archiveCachePath, "lastplayed");

        /// <summary>
        /// Absolute path to the game info file for the given archive cache path.
        /// </summary>
        /// <param name="archiveCachePath">Location of the cached archive.</param>
        /// <returns>Absolute path to the game info file.</returns>
        public static string GetArchiveCacheGameInfoPath(string archiveCachePath) => Path.Combine(archiveCachePath, gameInfoFileName);

        /// <summary>
        /// Absolute path to the extracting flag file for the given archive cache path.
        /// </summary>
        /// <param name="archiveCachePath">Location of the cached archive.</param>
        /// <returns>Absolute path to the extracting flag file.</returns>
        public static string GetArchiveCacheExtractingFlagPath(string archiveCachePath) => Path.Combine(archiveCachePath, "extracting");

        /// <summary>
        /// Absolute path to the link flag file for the given archive cache path.
        /// </summary>
        /// <param name="archiveLaunchPath">Location of the launch path in the cache.</param>
        /// <returns>Absolute path to the link flag file.</returns>
        public static string GetArchiveCacheLinkFlagPath(string archiveLaunchPath) => Path.Combine(archiveLaunchPath, "link");

        /// <summary>
        /// Absolute path to the m3u file for the given archive cache path. Filename includes the game ID.
        /// </summary>
        /// <param name="archiveCachePath"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public static string GetArchiveCacheM3uGameIdPath(string archiveCachePath, string gameId) => GetArchiveCacheM3uPath(archiveCachePath, gameId);

        /// <summary>
        /// Absolute path to the m3u file for the given archive cache path. Filename includes the game title and platform.
        /// If the combination of title and platform results in an invalid filename, use game ID instead.
        /// </summary>
        /// <param name="archiveCachePath"></param>
        /// <param name="title"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static string GetArchiveCacheM3uGameTitlePath(string archiveCachePath, string gameId, string title, string version, int? disc = null)
        {
            string localVersion = version;

            if (disc != null)
            {
                string versionNoDisc = version.Replace(string.Format("(Disc {0})", disc), "").Replace("(Disc 1)", "");
                localVersion = String.Join(" ", versionNoDisc.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            }

            return GetArchiveCacheM3uPath(archiveCachePath, GetValidFilename(string.Format("{0} {1}", title, localVersion), gameId).Trim());
        }

        /// <summary>
        /// Absolute path to the m3u file for the given archive cache path.
        /// </summary>
        /// <param name="archiveCachePath"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static string GetArchiveCacheM3uPath(string archiveCachePath, string filename) => Path.Combine(archiveCachePath, string.Format("{0}.m3u", filename));

        public static string[] GetManagerFiles(string archiveCachePath) => new string[] { GetArchiveCachePlaytimePath(archiveCachePath),
                                                                                          GetArchiveCacheGameInfoPath(archiveCachePath),
                                                                                          GetArchiveCacheExtractingFlagPath(archiveCachePath),
                                                                                          GetArchiveCacheLinkFlagPath(archiveCachePath) };

        /// <summary>
        /// Game info filename.
        /// </summary>
        /// <returns></returns>
        public static string GetGameInfoFileName() => gameInfoFileName;

        /// <summary>
        /// Calculates an MD5 hash of the given path.
        /// </summary>
        /// <param name="path">The path, including filename, to hash.</param>
        /// <returns>The MD5 hash.</returns>
        private static string PathHash(string path)
        {
            // Create hash of archive path
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(path));
            }
            // Example: Doom (USA).zip hashes to 7309402b2dbee883f0f83e3e962dff24
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        /// <summary>
        /// Calculates an MD5 hash of the given path, and appends to the end of the filename in the path.
        /// Example: "Doom (USA).zip - 7309402b2dbee883f0f83e3e962dff24"
        /// </summary>
        /// <param name="path">The path, including filename, to hash.</param>
        /// <param name="hashLength">The length of the hash to append. Valid values are 1-32. Default is 32.</param>
        /// <returns>The filename with MD5 hash suffix.</returns>
        public static string FilenameWithHash(string path, int hashLength = 32)
        {
            if (hashLength > 32)
            {
                hashLength = 32;
            }
            else if (hashLength < 1)
            {
                hashLength = 1;
            }

            // Example: "Doom (USA).zip - 7309402b2dbee883f0f83e3e962dff24"
            return string.Format("{0} - {1}", Path.GetFileName(path), PathHash(path).Substring(0, hashLength));
        }

        /// <summary>
        /// Absolute path to the supplied cache path, or to the configured cache if cachePath omitted.
        /// </summary>
        /// <param name="cachePath">The path to the cache location.</param>
        /// <returns>Absolute path of the cache.</returns>
        public static string CachePath(string cachePath = null)
        {
            return GetAbsolutePath(cachePath ?? Config.CachePath);
        }

        /// <summary>
        /// Absolute path to the archive within the cache.
        /// </summary>
        /// <param name="archivePath">The path to the cache lcation.</param>
        /// <returns>Absolute path to the archive within the cache.</returns>
        public static string ArchiveCachePath(string archivePath)
        {
            return Path.Combine(CachePath(), FilenameWithHash(archivePath));
        }

        /// <summary>
        /// Absolute path to the archive within the cache.
        /// </summary>
        /// <param name="archivePath">The path to the cache lcation.</param>
        /// <returns>Absolute path to the archive within the cache.</returns>
        public static string ArchiveCachePath(string archivePath, string title, string version, string id)
        {
            string path = string.Format("{0} {1} [{2}]", title, version, id.Substring(0, 6));
            path = GetValidFilename(path, Path.GetFileName(archivePath));
            return Path.Combine(CachePath(), path);
        }

        /// <summary>
        /// Get a valid filename from the input string. Will replace invalid characters with '_'.
        /// If the filename is reserved or otherwise generates an exception, safeFilename will be used.
        /// </summary>
        /// <param name="filenameToValidate">The filename to validate.</param>
        /// <param name="safeFilename">The fallback filename to use if filename validation fails.</param>
        /// <returns>The validated filename.</returns>
        public static string GetValidFilename(string filenameToValidate, string safeFilename)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var validFilename = String.Join("_", filenameToValidate.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
            var reservedNames = new[]
            {
                "CON", "PRN", "AUX", "CLOCK$", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
                "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4",
                "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
            };

            foreach (var reserved in reservedNames)
            {
                if (String.Equals(validFilename, reserved, StringComparison.InvariantCultureIgnoreCase))
                {
                    validFilename = safeFilename;
                    break;
                }
            }

            try
            {
                FileInfo fileInfo = new FileInfo(validFilename);
            }
            catch
            {
                validFilename = safeFilename;
            }

            return validFilename;
        }

        /// <summary>
        /// Get a valid path from the input string. Will replace invalid characters with '_'.
        /// If the path is reserved or otherwise generates an exception, safePath will be used.
        /// </summary>
        /// <param name="pathToValidate">The path to validate.</param>
        /// <param name="safePath">The fallback path to use if path validation fails.</param>
        /// <returns>The validated filename.</returns>
        public static string GetValidPath(string pathToValidate, string safePath)
        {
            var invalidChars = Path.GetInvalidPathChars();
            var validPath = String.Join("_", pathToValidate.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
            var reservedNames = new[]
            {
                "CON", "PRN", "AUX", "CLOCK$", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
                "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4",
                "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
            };

            foreach (var reserved in reservedNames)
            {
                if (String.Equals(validPath, reserved, StringComparison.InvariantCultureIgnoreCase))
                {
                    validPath = safePath;
                    break;
                }
            }

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(validPath);
            }
            catch
            {
                validPath = safePath;
            }

            return validPath;
        }

        /// <summary>
        /// Check that the given path is safe to use as a cache location.
        /// Unsafe paths include empty or null, LaunchBox and its default subfolders, c:\, Windows, Program Files.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>True if the path is safe to use, false otherwise.</returns>
        public static bool IsPathSafe(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path.Trim()))
                {
                    return false;
                }

                path = GetAbsolutePath(path);

                string[] unsafePaths = new string[] {
                    launchBoxRootPath,
                    Path.Combine(launchBoxRootPath, "Backups"),
                    Path.Combine(launchBoxRootPath, "Core"),
                    Path.Combine(launchBoxRootPath, "Data"),
                    Path.Combine(launchBoxRootPath, "Images"),
                    Path.Combine(launchBoxRootPath, "LBThemes"),
                    Path.Combine(launchBoxRootPath, "Logs"),
                    Path.Combine(launchBoxRootPath, "Manuals"),
                    Path.Combine(launchBoxRootPath, "Metadata"),
                    Path.Combine(launchBoxRootPath, "Music"),
                    Path.Combine(launchBoxRootPath, "PauseThemes"),
                    Path.Combine(launchBoxRootPath, "Plugins"),
                    Path.Combine(launchBoxRootPath, "Sounds"),
                    Path.Combine(launchBoxRootPath, "StartupThemes"),
                    Path.Combine(launchBoxRootPath, "Themes"),
                    Path.Combine(launchBoxRootPath, "ThirdParty"),
                    Path.Combine(launchBoxRootPath, "Updates"),
                    Path.Combine(launchBoxRootPath, "Videos"),
                    @"C:\",
                    @"C:\Windows",
                    @"C:\Program Files",
                    @"C:\Program Files (x86)"
                };

                foreach (string unsafePath in unsafePaths)
                {
                    if (ComparePaths(path, unsafePath))
                    {
                        return false;
                    }
                }

                // Will throw an exception if the path is poorly formatted or permissions errors
                Directory.EnumerateFiles(path);
            }
            // Path may not exist, but is still valid
            catch (DirectoryNotFoundException)
            {
                return true;
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), Logger.LogLevel.Exception);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if the launched game is a compressed archive based on the file extension.
        /// Extensions checked are zip, 7z, rar.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool HasExtension(string filename, string[] extensions)
        {
            string extension = Path.GetExtension(filename).ToLower();
            return extensions.Contains(extension);
        }

        public static string IsNetworkPath(string path)
        {
            if (!path.StartsWith(@"/") && !path.StartsWith(@"\"))
            {
                string rootPath = System.IO.Path.GetPathRoot(path); // get drive's letter
                System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(rootPath); // get info about the drive
                if (driveInfo.DriveType == DriveType.Network)
                {
                    return GetUNCPath(path);
                }
                return "";
            }

            return path; // is a UNC path
        }

        public static string GetUNCPath(string originalPath)
        {
            StringBuilder sb = new StringBuilder(512);
            int size = sb.Capacity;

            // look for the {LETTER}: combination ...
            if (originalPath.Length > 2 && originalPath[1] == ':')
            {
                // don't use char.IsLetter here - as that can be misleading
                // the only valid drive letters are a-z && A-Z.
                char c = originalPath[0];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    int error = WNetGetConnection(originalPath.Substring(0, 2),
                        sb, ref size);
                    if (error == 0)
                    {
                        DirectoryInfo dir = new DirectoryInfo(originalPath);

                        string path = Path.GetFullPath(originalPath)
                            .Substring(Path.GetPathRoot(originalPath).Length);
                        return Path.Combine(sb.ToString().TrimEnd(), path);
                    }
                }
            }

            return originalPath;
        }

        public static bool HostExists(string PCName)
        {
            Ping pinger = new Ping();

            try
            {
                PingReply reply = pinger.Send(PCName);
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
            finally
            {
                pinger.Dispose();
            }

        }

        public static bool DirExistAndSkipNoPing(string path)
        {
            string nwpath = IsNetworkPath(path);
            if (!String.IsNullOrEmpty(nwpath))
            {
                var host = new Uri(nwpath).Host;
                if (!string.IsNullOrEmpty(host))
                {
                    if (HostExists(host) == false)
                    {
                        return false;
                    }
                }
            }
            return Directory.Exists(path);
        }

        public static string find_alt_path(string path_source, string altpath_config)
        {
            if (String.IsNullOrEmpty(altpath_config))
            {
                return path_source;
            }
            if (File.Exists(path_source))
            {
                return path_source;
            }

            if (cache_altpath.ContainsKey(path_source))
            {
                if (File.Exists(cache_altpath[path_source]))
                {
                    return cache_altpath[path_source];
                }
            }

            Dictionary<string, bool> alt_path = new Dictionary<string, bool>();
            foreach (string apath in altpath_config.Split('|'))
            {
                string[] pathdata = apath.Split('>');
                bool recurse = false;
                if (pathdata.Length > 1 && pathdata[1] == "R") recurse = true;
                alt_path[pathdata[0]] = recurse;
            }



            path_source = Path.GetFullPath(path_source);
            string filename = Path.GetFileName(path_source);
            string fullpath = Path.GetDirectoryName(path_source);

            string nodrive_path = "";
            string[] dirArray = new string[0];
            if (!String.IsNullOrEmpty(fullpath))
            {
                if ((fullpath.IndexOf(":") == 1) || (fullpath.IndexOf(@"\\") == 0)) nodrive_path = fullpath.Substring(2);
                if (nodrive_path.IndexOf(@"\") > 0) nodrive_path = nodrive_path.Substring(nodrive_path.IndexOf("\\"));
                if (nodrive_path.StartsWith(@"\")) nodrive_path = nodrive_path.Substring(1);
                dirArray = nodrive_path.Split(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                Array.Reverse(dirArray);
            }

            

            foreach (var item in alt_path)
            {
                string path_dest = item.Key;
                bool folder_search = item.Value;
                if (DirExistAndSkipNoPing(path_dest))
                {
                    string check_string = filename;
                    string check_fullpath = Path.Combine(path_dest, filename);
                    if (File.Exists(check_fullpath))
                    {
                        cache_altpath[path_source] = check_fullpath;
                        cache_altpath[check_fullpath] = check_fullpath;
                        return check_fullpath;
                    }
                    if (folder_search && dirArray.Length > 0)
                    {
                        foreach (string dir in dirArray)
                        {
                            check_string = dir + Path.DirectorySeparatorChar + check_string;
                            check_fullpath = Path.Combine(path_dest, check_string);
                            if (File.Exists(check_fullpath))
                            {
                                cache_altpath[path_source] = check_fullpath;
                                cache_altpath[check_fullpath] = check_fullpath;
                                return check_fullpath;
                            }
                        }
                    }
                }
            }
            return path_source;
        }
    }
}
