using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private LauncherConfig config;

        public MainWindow()
        {
            InitializeComponent();
            config = LauncherConfig.Load();
            GamePathTextBox.Text = config.GamePath;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Fichiers EXE (*.exe)|*.exe" };
            if (dialog.ShowDialog() == true)
            {
                GamePathTextBox.Text = dialog.FileName;
                config.GamePath = dialog.FileName;
                config.Save();
            }
        }


        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            string path = GamePathTextBox.Text;

            if (File.Exists(path))
            {
                try
                {
                    Process.Start(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors du lancement : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Chemin invalide ou fichier introuvable.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}