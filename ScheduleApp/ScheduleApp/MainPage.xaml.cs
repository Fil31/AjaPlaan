using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace ScheduleApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ScheduleItem> ScheduleItems { get; set; }

        public MainPage()
        {
            InitializeComponent();

            ScheduleItems = new ObservableCollection<ScheduleItem>();

            // Пример добавления элементов в расписание
            ScheduleItems.Add(new ScheduleItem { DayNumber = 4, Time = "08:00", Activity = "Завтрак", Description = "Приготовить омлет с сыром и томатами", IsChecked = false });
            ScheduleItems.Add(new ScheduleItem { DayNumber = 4, Time = "10:00", Activity = "Работа", Description = "Отправить отчет о проделанной работе", IsChecked = false });

            scheduleListView.ItemsSource = ScheduleItems;
        }


        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var item = e.SelectedItem as ScheduleItem;
            await DisplayAlert("Информация о деле", $"Название: {item.Activity}\nОписание: {item.Description}", "OK");
            scheduleListView.SelectedItem = null;
        }
        private async void OnAddActivityClicked(object sender, EventArgs e)
        {
            int dayNumber = datePicker.Date.Day;
            string time = await DisplayPromptAsync("Добавить дело", "Введите время (например, 12:30)");
            string activity = await DisplayPromptAsync("Добавить дело", "Введите название дела");
            string description = await DisplayPromptAsync("Добавить дело", "Введите описание дела");

            ScheduleItems.Add(new ScheduleItem { DayNumber = dayNumber, Time = time, Activity = activity, Description = description, IsChecked = false });
        }


    public class ScheduleItem
        {
            public int DayNumber { get; set; }
            public string Time { get; set; }
            public string Activity { get; set; }
            public string Description { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}