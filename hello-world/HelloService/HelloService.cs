using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HelloService {
	public partial class HelloService : ServiceBase {
		private System.IO.FileSystemWatcher _watcher;
		public HelloService() {
			InitializeComponent();
			if (!System.Diagnostics.EventLog.SourceExists("MySource")) {
				System.Diagnostics.EventLog.CreateEventSource("MySource", "MyNewLog");
			}
			this._watcher = new System.IO.FileSystemWatcher() {
				Path = "C:\\",
				IncludeSubdirectories = true,
				Filter = "*.*",
				NotifyFilter = System.IO.NotifyFilters.LastAccess | System.IO.NotifyFilters.LastWrite | System.IO.NotifyFilters.DirectoryName | System.IO.NotifyFilters.FileName,
				EnableRaisingEvents = true
			};
			System.IO.File.WriteAllText("C:\\temp\\Itsworking", "Its working");
			this._watcher.Renamed += ((object o, System.IO.RenamedEventArgs args) => {
				string currentText = System.IO.File.ReadAllText("C:\\temp\\MyServiceOutput.txt");
				System.IO.File.WriteAllText("C:\\temp\\MyServiceOutput.txt", currentText + $"\nRenamed: {args.FullPath}");
				return;
			});
			this.EventLog.Source = "MySource";
			this.EventLog.Log = "MyNewLog";
		}


		protected override void OnStart(string[] args) {
			this.EventLog.WriteEntry("Hello Service Started");
		}

		protected override void OnStop() {
			this.EventLog.WriteEntry("Hello Service Stopped");
		}

	}
}
