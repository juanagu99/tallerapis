using Libreria.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TallerApi.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PublicacionPage : ContentPage
	{
        public PublicacionPage ()		{
			InitializeComponent ();
            CargarProductos();
        }

        public void CargarProductos()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://192.168.1.8");
            //ahora hacemos la peticion
            var request = cliente.GetAsync("PrimerApi/api/Publicacion").Result; // ->metodo para obtener la informacion que me trajo el metodo get y me devuelvve un objeto de tipo producto en json
            if (request.IsSuccessStatusCode) //si el request se ejecuta bien y es verdadero cuando me devuelve un status 200
            {
                var responseJSON = request.Content.ReadAsStringAsync().Result; //obtenemos la respueta del servidor si el request se ejecuta bien; se obtiene como un string
                //para poder comvertirlo a jsson formato tengo que agregar el paquete de Newtonsoft.Jsone incluir su libreria
                var respuesta = JsonConvert.DeserializeObject<List<Publicacion>>(responseJSON); //dserializando el objeto json: significa que estamos llevando el json a string
                listpublicaciones.ItemsSource = respuesta;
            }
        }
            private async void Item_Selected(object sender, SelectedItemChangedEventArgs e)
            {
                var p = e.SelectedItem as Publicacion;
                await DisplayAlert("Informacion","MG:"+ p.MeGusta,"NoMG:" + p.MeDisgusta, "VecesCompartido:" + p.VecesCompartido);
            }
 
    }
}