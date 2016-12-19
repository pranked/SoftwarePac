using System;
using System.Windows;
using System.Windows.Controls;
using SoftwarePac.GUI.Forms;
using SoftwarePac.Procurement;
using SoftwarePac.Procurement.Engine;

namespace SoftwarePac.GUI.Model
{
    public class ViewModel
    {
        private UserControl[] Steps;
        private Reader reader;

        public string testing
        {
            get
            {
                Console.WriteLine("america");
                return "america bitches";
            }
        }

        public ViewModel()
        {
            reader = new Reader("./Packages/");
            reader.Parse();
            var eng = new Factory(reader.Storage);
            //eng.Install();
            Steps = new UserControl[] {new SoftwareListing(),};
        }

        public Software[] Software => reader.Storage.ToArray();

        private int current = 0;

        public UserControl CurrentView => Steps[current];

        public void Inheret(Window window)
        {
            
        }
    }
}
