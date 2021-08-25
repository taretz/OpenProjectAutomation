using System;
using System.Globalization;
using System.IO;
using CSharpVitamins;
using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;

namespace OpenProject.infra
{
	public class Logger
	{
		private static Logger instance;
		private static string _logsDirectory;
		private static string _testId;
		private static string _testDirectory;

		//TODO - transform to singleton
		private Logger()
		{
			_testId = (ShortGuid)Guid.NewGuid();
			_logsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OpenProjectLogs");
			_testDirectory = Path.Combine(_logsDirectory, $"{TestContext.CurrentContext.Test.Name}_{_testId}");
			CreateDirectory(_logsDirectory);
			CreateDirectory(_testDirectory);
		}

		public static Logger GetInstance()
		{
			return instance ?? (instance = new Logger());
		}

		public void Log(string logMessage)
		{
			try
			{
				// CreateDirectoriesIfNotExists(_logsDirectory);
				// CreateDirectoriesIfNotExists(_testDirectory);
				// string logFileFullPath = CreateLogFileFullPath();
				FormatLogMessageAndWriteToLogFile("", logMessage);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Log(Screenshot image, string imageName)
		{
			try
			{
				// CreateDirectoriesIfNotExists(_logsDirectory);
				// CreateDirectoriesIfNotExists(_testDirectory);
				SaveImage(_testDirectory, image, imageName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private static void FormatLogMessageAndWriteToLogFile(string logFullPath, string logMessage)
		{
			string formattedMessage = $"[{DateTime.Now.ToShortTimeString()}] {logMessage}";
			formattedMessage += Environment.NewLine;
			logFullPath = Path.Combine(_testDirectory, "log.txt");
			if (!File.Exists(logFullPath))
			{
				File.WriteAllText(logFullPath, formattedMessage);
			}
			else
			{
				File.AppendAllText(logFullPath, formattedMessage);
			}
		}

		// private static void CreateLogsDirectoryIfNotExists()
		// {
		// 	if (!Directory.Exists(LogsDirectory))
		// 	{
		// 		Console.WriteLine("Creating logs folder: " + LogsDirectory);
		// 		Directory.CreateDirectory(LogsDirectory);
		// 	}
		// }

		private void CreateDirectory(string path)
		{
			if (!Directory.Exists(path))
			{
				Console.WriteLine("Creating logs folder: " + path);
				Directory.CreateDirectory(path);
			}
		}

		private  string CreateLogFileFullPath()
		{
			// string date = DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
			return $"{_testDirectory}.log";
			// return Path.Combine(LogsDirectory, logFilename);
		}

		private  void SaveImage(string logsFolder, Screenshot image, string imageName)
		{
			string fileName = $"{Path.Combine(logsFolder, imageName)}.{ScreenshotImageFormat.Png}";
			image.SaveAsFile(fileName, ScreenshotImageFormat.Png);
		}

		public  void LogActionAccordingToResponse(IRestResponse response)
		{
			string actionDesc = $"{response.Request.Method.ToString().ToUpper()} {response.Request.Resource}";
			Log(response.IsSuccessful
				? $"{actionDesc} ended successfully"
				: $"{actionDesc} was not successful");
			Log(response.Content);
		}

	}
}