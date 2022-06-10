using System;
using System.Windows.Input;

namespace ProjektWPF.Core
{
    class RelayCommand
    {
        private Action<SZKOŁA_PODSTAWOWAEntities> execute;
        private Func<SZKOŁA_PODSTAWOWAEntities, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<SZKOŁA_PODSTAWOWAEntities> ex, Func<SZKOŁA_PODSTAWOWAEntities, bool> canExecute = null)
        {
            this.execute = ex;
            this.canExecute = canExecute;
        }

        public bool CanExecute(SZKOŁA_PODSTAWOWAEntities parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(SZKOŁA_PODSTAWOWAEntities parameter)
        {
            execute(parameter);
        }
    }
}
