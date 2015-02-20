/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/23/2013
 * Time: 6:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils
{
    using System;
    using System.Management.Automation;
    using TestUtils.Commands;
    using Ionic.Zip;
    using NUnrar.Archive;
    using NUnrar.Common;
    
    /// <summary>
    /// Description of ArchivingHelper.
    /// </summary>
    public static class ArchivingHelper
    {
        internal static void AddFilesToArchive(NewTuZipArchiveCommand cmdlet)
        {
            
            if (null == cmdlet.Filename || 0 == cmdlet.Filename.Length)
                cmdlet.WriteError(
                    cmdlet,
                    "There are no files to archive",
                    "NoFiles",
                    ErrorCategory.InvalidArgument,
                    true);
            
            if (string.IsNullOrEmpty(cmdlet.ArchiveName))
                cmdlet.ArchiveName = "NewArchive";
            
            try {
                using (var zipFile = new ZipFile()) {
                    
                    foreach (string fileName in cmdlet.Filename) {
                        
                        cmdlet.WriteVerbose(
                            cmdlet, 
                            "Adding file '" +
                            fileName +
                            "' to the archive");
                        
//                        if (System.IO.Directory.Exists(fileName)) {
//                            if (null == cmdlet.PathInArchive) {
//                                zipFile.AddDirectory(fileName);
//                            } else {
//                                zipFile.AddDirectory(fileName, cmdlet.PathInArchive);
//                            }
//                        }
//                        if (System.IO.File.Exists(fileName)) {
//                            if (null == cmdlet.PathInArchive) {
//                                zipFile.AddFile(fileName);
//                            } else {
//                                zipFile.AddFile(fileName, cmdlet.PathInArchive);
//                            }
//                        }
                        if (System.IO.Directory.Exists(fileName))
                            string.IsNullOrEmpty(cmdlet.PathInArchive) ? zipFile.AddDirectory(fileName) : zipFile.AddDirectory(fileName, cmdlet.PathInArchive);
                        if (System.IO.File.Exists(fileName))
                            string.IsNullOrEmpty(cmdlet.PathInArchive) ? zipFile.AddFile(fileName) : zipFile.AddFile(file, cmdlet.PathInArchive);
                    }
                    
                    zipFile.Comment = cmdlet.Comment;
                    
                    zipFile.Save(cmdlet.ArchiveName + ".zip");
                    
                    cmdlet.WriteObject(zipFile);
                }
            }
            catch (Exception eArchive) {
                
                cmdlet.WriteError(
                    cmdlet,
                    "Failed to create archive '" +
                    cmdlet.ArchiveName + 
                    ".zip'." +
                    eArchive.Message,
                    "FailedToCreateArchive",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        
        internal static void ExtractFromZipArchive(ExpandTuZipArchiveCommand cmdlet)
        {
            string[] pathToArchive = cmdlet.ArchiveName;
            string pathToTargetDirectory = cmdlet.TargetFolder;
            var fileAction = ExtractExistingFileAction.DoNotOverwrite;
            if (cmdlet.Overwrite)
                fileAction = ExtractExistingFileAction.OverwriteSilently;
            
            foreach (string path in pathToArchive) {
                
                if (!string.IsNullOrEmpty(path)) {
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "extracting '" +
                        path +
                        "'");
                    
                    try {
                        
                        using (ZipFile zipARchive = ZipFile.Read(path)) {
                            
                            cmdlet.WriteVerbose(cmdlet, "opening the archive");
                            
                            foreach (ZipEntry entry in zipARchive) {
                                
                                entry.Extract(pathToTargetDirectory, fileAction);
                                cmdlet.WriteObject(
                                    cmdlet,
                                    pathToTargetDirectory +
                                    @"\" +
                                    entry.FileName);
                            }
                        }
                    } catch (Exception eExtract) {
                        cmdlet.WriteError(
                            cmdlet,
                            "Failed to extract archive '" +
                            path +
                            "'. " +
                            eExtract.Message,
                            "FailedToExtract",
                            ErrorCategory.InvalidOperation,
                            false);
                    }
                }
            }
        }
        
        internal static void ExtractFromRarArchive(ExpandTuRarArchiveCommand cmdlet)
        {
            string[] pathToArchive = cmdlet.ArchiveName;
            string pathToTargetDirectory = cmdlet.TargetFolder;
//            ExtractExistingFileAction fileAction = ExtractExistingFileAction.DoNotOverwrite;
//            if (cmdlet.Overwrite) {
//                fileAction = ExtractExistingFileAction.OverwriteSilently;
//            }
            var options = ExtractOptions.Overwrite;
            
            foreach (string path in pathToArchive) {
                
                if (!string.IsNullOrEmpty(path)) {
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "extracting '" +
                        path +
                        "'");
                    
                    try {
                        
//                        using (Ionic.zipARchive = ZipFile.Read(path)) {
//                            
//                            cmdlet.WriteVerbose(cmdlet, "opening the archive");
//                            
//                            foreach (ZipEntry entry in zipARchive) {
//                                
//                                entry.Extract(pathToTargetDirectory, fileAction);
//                                cmdlet.WriteObject(
//                                    cmdlet,
//                                    pathToTargetDirectory +
//                                    @"\" +
//                                    entry.FileName);
//                            }
//                        }
                        
                        RarArchive.WriteToDirectory(
                            path,
                            pathToTargetDirectory,
                            options);
                            
                        // RarArchive.IsRarFile
                    } catch (Exception eExtract) {
                        cmdlet.WriteError(
                            cmdlet,
                            "Failed to extract archive '" +
                            path +
                            "'. " +
                            eExtract.Message,
                            "FailedToExtract",
                            ErrorCategory.InvalidOperation,
                            false);
                    }
                }
            }
        }
    }
}
