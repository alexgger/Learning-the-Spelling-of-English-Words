﻿using Microsoft.WindowsAPICodePack.Dialogs;
using Spelling_of_words.Properties;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Spelling_of_words.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsUser.xaml
    /// </summary>
    public partial class SettingsUser : Page
    {
        public SettingsUser()
        {
            InitializeComponent();

            pathFileBox.Text = Settings.Default.PathFileWords;

            state_generatewords.IsChecked = Settings.Default.GenerateRandomWords;
            state_repeatspellingword.IsChecked = Settings.Default.RepeatSpellingWords;
            state_notresponseresult.IsChecked = Settings.Default.NotDisplayingResponseResult;
            state_disabletimecounting.IsChecked = Settings.Default.DisableTimeCounting;
        }


        private void btn_SettingsBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SelectFolder(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();

                dialog.Title = "Выберите файла со словами";
                dialog.InitialDirectory = Settings.Default.PathFileWords;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Settings.Default.PathFileWords = dialog.FileName;
                    pathFileBox.Text = Settings.Default.PathFileWords;

                    MessageBox.Show($"Вы выбрали файл: {Settings.Default.PathFileWords}", "Выбор файла");
                    Settings.Default.Save();
                }
                
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void btn_repeatspellingwords(object sender, RoutedEventArgs e)
        {
            Settings.Default.RepeatSpellingWords = (bool)state_repeatspellingword.IsChecked;
            Settings.Default.Save();
        }

        private void btn_generaterandomwords(object sender, RoutedEventArgs e)
        {
            Settings.Default.GenerateRandomWords = (bool)state_generatewords.IsChecked;
            Settings.Default.Save();
        }

        private void btn_hideresponseresult(object sender, RoutedEventArgs e)
        {
            Settings.Default.NotDisplayingResponseResult = (bool)state_notresponseresult.IsChecked;
            Settings.Default.Save();
        }

        private void btn_disabletimecounting(object sender, RoutedEventArgs e)
        {
            Settings.Default.DisableTimeCounting = (bool)state_disabletimecounting.IsChecked;
            Settings.Default.Save();
        }
    }
}
