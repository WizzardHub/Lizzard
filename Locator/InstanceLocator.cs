using System.Diagnostics;

namespace Lizzard.Locator
{
    class InstanceLocator
    {
        private string title;
        public InstanceLocator(string title)
        {
            this.title = title;
        }

        public Process GetInstance()
        {
            Process[] processes = Process.GetProcessesByName("Javaw");
            foreach (var prc in processes)
            {
                if (prc.MainWindowTitle.Contains(title))
                    return prc;
            }
            return null;
        }
    }
}
