using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace UPHotel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HotelsPage());
            Manager.MngrMainFrame = MainFrame;
            //ImportTours();
        }

        private void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\Zver\Desktop\Tours.txt");
            var img = Directory.GetFiles(@"C:\Users\Zver\Desktop\Tours");

            foreach (var line in fileData)
            {
                var data = line.Split('\t');

                var tempTour = new Tour
                {
                    Name = data[0].Replace("\"", ""),
                    TicketCount = int.Parse(data[2]),
                    Price = decimal.Parse(data[3]),
                    IsActual = (data[4] == "0") ? false : true
                };
                foreach (var tourType in data[5].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var currentType = UPEntities2.GetContext().Types.ToList().FirstOrDefault(p => p.Name == tourType);
                    if (currentType != null)
                        tempTour.Types.Add(currentType);
                }
                try
                {
                    tempTour.ImagePreview = File.ReadAllBytes(img.FirstOrDefault(p => p.Contains(tempTour.Name)));
                }
                catch (Exception ex)

                { Console.WriteLine(ex.Message); }
                UPEntities2.GetContext().Tours.Add(tempTour);
                UPEntities2.GetContext().SaveChanges();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MngrMainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                BackButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
