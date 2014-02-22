using System;
using System.IO;
namespace OpenQuant.API.Engine
{
	public static class IDE
	{
		private static StrategyMode mode = StrategyMode.Simulation;
		private static SolutionInfo solutionInfo = null;
		private static Scenario scenario = null;
		public static event EventHandler ModeChangeRequested;
		public static event EventHandler OpenSolutionRequested;
		public static event EventHandler CloseSolutionRequested;
		public static event EventHandler StartSolutionRequested;
		public static event EventHandler StopSolutionRequested;
		public static event EventHandler BuildSolutionRequested;
		public static event EventHandler SolutionInfoRequested;
		public static event EventHandler ScenarioRequested;
		public static event EventHandler StartScriptRequested;
		public static event EventHandler StopScriptRequested;
		public static DirectoryInfo SolutionsDirectory
		{
			get;
			private set;
		}
		public static DirectoryInfo ProjectsDirectory
		{
			get;
			private set;
		}
		public static DirectoryInfo ScriptsDirectory
		{
			get;
			private set;
		}
		public static StrategyMode Mode
		{
			get
			{
				return IDE.mode;
			}
			set
			{
				if (IDE.ModeChangeRequested != null)
				{
					IDE.ModeChangeRequested(value, EventArgs.Empty);
				}
			}
		}
		public static Solution Solution
		{
			get;
			set;
		}
		public static SolutionInfo SolutionInfo
		{
			get
			{
				if (IDE.SolutionInfoRequested != null)
				{
					IDE.SolutionInfoRequested(null, EventArgs.Empty);
				}
				return IDE.solutionInfo;
			}
		}
		public static Scenario Scenario
		{
			get
			{
				if (IDE.ScenarioRequested != null)
				{
					IDE.ScenarioRequested(null, EventArgs.Empty);
				}
				return IDE.scenario;
			}
		}
		private static void Init(DirectoryInfo solutionsDirectory, DirectoryInfo projectsDirectory, DirectoryInfo scriptsDirectory)
		{
			IDE.SolutionsDirectory = solutionsDirectory;
			IDE.ProjectsDirectory = projectsDirectory;
			IDE.ScriptsDirectory = scriptsDirectory;
		}
		public static bool OpenSolution(string name)
		{
			FileInfo fileInfo = new FileInfo(string.Concat(new string[]
			{
				IDE.SolutionsDirectory.FullName,
				"\\",
				name,
				"\\",
				name,
				".oqs"
			}));
			if (fileInfo.Exists)
			{
				if (IDE.OpenSolutionRequested != null)
				{
					IDE.OpenSolutionRequested(fileInfo, EventArgs.Empty);
				}
				return true;
			}
			return false;
		}
		public static void CloseSolution()
		{
			if (IDE.CloseSolutionRequested != null)
			{
				IDE.CloseSolutionRequested(null, EventArgs.Empty);
			}
		}
		public static void BuildSolution()
		{
			if (IDE.BuildSolutionRequested != null)
			{
				IDE.BuildSolutionRequested(null, EventArgs.Empty);
			}
		}
		public static void StartSolution()
		{
			if (IDE.StartSolutionRequested != null)
			{
				IDE.StartSolutionRequested(null, EventArgs.Empty);
			}
		}
		public static void StopSolution()
		{
			if (IDE.StopSolutionRequested != null)
			{
				IDE.StopSolutionRequested(null, EventArgs.Empty);
			}
		}
		public static void StartScript(ScriptInfo scriptInfo)
		{
			if (IDE.StartScriptRequested != null)
			{
				IDE.StartScriptRequested(scriptInfo, EventArgs.Empty);
			}
		}
		public static void StopScript(ScriptInfo scriptInfo)
		{
			if (IDE.StopScriptRequested != null)
			{
				IDE.StopScriptRequested(scriptInfo, EventArgs.Empty);
			}
		}
	}
}
