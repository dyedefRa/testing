using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsService1
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            //serviceInstaller1.ServiceName = "Test";
            //serviceInstaller1.DisplayName = "Test Service";
            //serviceInstaller1.Description = "Test";
            serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            Installers.Add(serviceInstaller1);

            //this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            //this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            //this.serviceProcessInstaller1.Password = null;
            //this.serviceProcessInstaller1.Username = null;



        }

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
