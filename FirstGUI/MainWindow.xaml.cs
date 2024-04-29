using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FirstGUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random randomNumber = new Random();

            // Generiere eine zufällige Farbe - Color.FromRgb() erwartet einen Bytewert, deshalb das konvertieren der Ganzzahl in Byte
            Color randomColor = Color.FromRgb(
                (byte)randomNumber.Next(256),   // R
                (byte)randomNumber.Next(256),   // G
                (byte)randomNumber.Next(256));  // B
 

            ListBoxItem item = new ListBoxItem();
            item.Content = $"{randomColor.R}, {randomColor.G}, {randomColor.B}"; ;
            colorListBox.Items.Insert(0,item); // An die 0. Position wird das Item eingefügt (Inserted) also Oben erste stelle

            // Random Color dem Background zuweisen
            this.Background = new SolidColorBrush(randomColor);
            rgbCode.Content = $"R: {randomColor.R}, G: {randomColor.G}, B: {randomColor.B}";
        }

        private void colorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Überprüfen, ob ein Element ausgewählt ist
            if (colorListBox.SelectedItem != null)
            {
                // Ausgewähltes Element in ein ListBoxItem konvertieren
                ListBoxItem selectedItem = (ListBoxItem)colorListBox.SelectedItem;

                // Inhalt des ausgewählten Elements (Farbwert) extrahieren
                string selectedColor = selectedItem.Content.ToString();


                // Farbwert in RGB-Komponenten aufteilen
                string[] components = selectedColor.Split(',');
                byte r = byte.Parse(components[0].Trim()); // R-Komponente
                byte g = byte.Parse(components[1].Trim()); // G-Komponente
                byte b = byte.Parse(components[2].Trim()); // B-Komponente

                rgbCode.Content = $"R: {r}, G: {g}, B: {b}";

                // Hintergrundfarbe entsprechend der ausgewählten Farbe ändern
                this.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
        }
    }
}
