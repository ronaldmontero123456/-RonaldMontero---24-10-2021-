using PropertyApp.DataAccess;
using PropertyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareasPage : ContentPage, INotifyPropertyChanged
    {
        public ICommand SaveCommand { get; private set; }
        private bool isChecked { get; set; }
        public bool IsChecked { get => isChecked; set { isChecked = value; RaiseOnPropertyChanged(); } }

        public new event PropertyChangedEventHandler PropertyChanged;

        public TareasPage()
        {

            SaveCommand = new Command(GuardadTarea);

            InitializeComponent();
            BindingContext = this;

        }

        private async void GuardadTarea()
        {

            if (string.IsNullOrEmpty(EditNombre.Text))
            {
                await DisplayAlert("Aviso", "Debe Agregar el nombre de la Tarea", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(EditDescripcion.Text))
            {
                await DisplayAlert("Aviso", "Debe Agregar la descripcion de la Tarea", "Aceptar");
                return;
            }

            Tareas tarea = new Tareas()
            {
                TarNombre = EditNombre.Text,
                TarDescripcion = EditDescripcion.Text,
                TarStatus = IsChecked,

            };

            SqliteManager.GetInstance().Insert(tarea);
            await Navigation.PopAsync();

        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}