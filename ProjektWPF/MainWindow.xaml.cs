using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;


namespace ProjektWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SZKOŁA_PODSTAWOWAEntities context = new SZKOŁA_PODSTAWOWAEntities();
        CollectionViewSource custViewSource;
        CollectionViewSource ordViewSource;

        public MainWindow()
        {
            InitializeComponent();
            custViewSource = ((CollectionViewSource)(FindResource("uczniowieViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("uczniowieViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource uczniowieViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uczniowieViewSource")));
            context.Uczniowies.Load();
            custViewSource.Source = context.Uczniowies.Local;
        }

        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            custViewSource.View.MoveCurrentToLast();
        }

        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            custViewSource.View.MoveCurrentToPrevious();
        }

        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            custViewSource.View.MoveCurrentToNext();
        }

        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            custViewSource.View.MoveCurrentToFirst();
        }

        private void DeleteUczenCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // If existing window is visible, delete the customer and all their orders.  
            // In a real application, you should add warnings and allow the user to cancel the operation.  
            var cur = custViewSource.View.CurrentItem as Uczniowie;

            var cust = (from c in context.Uczniowies
                        where c.ID == cur.ID
                        select c).FirstOrDefault();

            if (cust != null)
            {
                context.Uczniowies.Remove(cust);
            }
            context.SaveChanges();
            custViewSource.View.Refresh();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
    }
}
