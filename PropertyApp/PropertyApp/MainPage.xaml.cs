using PropertyApp.DataAccess;
using PropertyApp.Models;
using PropertyApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace PropertyApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
        }

        public List<Tareas> Tareas => GetTareas();

        private List<Tareas> GetTareas()
        {
            return SqliteManager.GetInstance().Query<Tareas>("select * from Tareas", new string[] { });
        }

        private void PropertySelected(object sender, EventArgs e)
        {
            SqliteManager.GetInstance().Execute($"delete from Tareas where TarId = {((sender as Xamarin.Forms.View).BindingContext as Tareas).TarId}");
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TareasPage());
        }

        protected override void OnAppearing()
        {
            InitializeComponent();
            BindingContext = this;
            base.OnAppearing();
        }
    }
}
