using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TallerApi.Xamarin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TallerApi.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PublicacionPage : ContentPage
	{
     

        public PublicacionPage ()
		{
			InitializeComponent ();
		}

        public object JsonConvert { get; private set; }

        public void CargarProductos()
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://mitiendaapis.azurewebsites.net");
            //ahora hacemos la peticion
            var request = cliente.GetAsync("/api/Producto").Result; // ->metodo para obtener la informacion que me trajo el metodo get y me devuelvve un objeto de tipo producto en json
            if (request.IsSuccessStatusCode) //si el request se ejecuta bien y es verdadero cuando me devuelve un status 200
            {
                var responseJSON = request.Content.ReadAsStringAsync().Result; //obtenemos la respueta del servidor si el request se ejecuta bien; se obtiene como un string
                //para poder comvertirlo a jsson formato tengo que agregar el paquete de Newtonsoft.Jsone incluir su libreria
                var respuesta = JsonConvert.DeserializeObject<List<Publicacion>>(responseJSON); //dserializando el objeto json: significa que estamos llevando el json a string
                listpublicaciones.ItemsSource = respuesta;
            }
            /*
            l = new List<Producto>{
                new Producto{Nombre="Celular1",Referencia="Samsung S8x",Imagen="celular.jpg"},
                new Producto{Nombre="Televisor1",Referencia="tv 40' smart tv 1",Imagen="tv.jpg"},
                new Producto{Nombre="Celular2",Referencia="Samsung S8x2",Imagen="celular.jpg"},
                new Producto{Nombre="Televisor2",Referencia="tv 40' smart tv 2",Imagen="tv.jpg"},
                new Producto{Nombre="Celular3",Referencia="Samsung S8x3",Imagen="celular.jpg"}
            };
            listProductos.ItemsSource = l;*/

        }

        private void Item_Selected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

        }
    }
}