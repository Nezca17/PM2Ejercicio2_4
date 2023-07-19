using Ejercicio2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignatureGallery : ContentPage
    {
        public SignatureGallery()
        {
            InitializeComponent();            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            fillCollectionView();
        }

        private async void fillCollectionView()
        {
            clvFirmas.ItemsSource = await App.DBase.obtenerFirmas();
        }

        private async void swpDelete_Invoked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmar", "Deliminar esta firma?", "Sí", "No"))
            {
                var firma = (Firma)(sender as SwipeItemView).CommandParameter;
                var result = await App.DBase.borrarFirma(firma);

                if (result == 1)
                {
                    fillCollectionView();
                    await DisplayAlert("Aviso", "Firma Eliminada", "OK");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha ocurrido un error", "OK");
                }
            }
        }

        /*private async void swpUpdate_Invoked(object sender, EventArgs e)
        {
            var firma = (Firma)(sender as SwipeItemView).CommandParameter;

            MainPage page = new MainPage();
            page.BindingContext = firma;
            await Navigation.PushAsync(page);
        }*/
    }
}