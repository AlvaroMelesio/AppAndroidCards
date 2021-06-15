using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using System;
using Android.Runtime;
using Android.Widget;

namespace AppAndroidCards
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView RecicladordeVista;
        RecyclerView.LayoutManager AdministradorInterfaz;
        PhotoAlbumAdapter Adaptador;
        AlbumFotos mAlbumdeFotos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SupportActionBar.Hide();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            mAlbumdeFotos = new AlbumFotos();
            RecicladordeVista = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            AdministradorInterfaz = new LinearLayoutManager(this);
            //Scroll Vertical
            //RecicladordeVista.SetLayoutManager(AdministradorInterfaz);
            //Scroll Horizontal
            RecicladordeVista.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false));
            Adaptador = new PhotoAlbumAdapter(mAlbumdeFotos);
            Adaptador.SeleccionElemento += OnItemClick;
            RecicladordeVista.SetAdapter(Adaptador);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        void OnItemClick(object sender, int position)
        {
            int NumerodeFoto = position + 1;
            var txtNombre = FindViewById<TextView>(Resource.Id.txtnombre);
            var txtDescripcion = FindViewById<TextView>(Resource.Id.txtdescripcion);
            var Imagen = FindViewById<ImageView>(Resource.Id.imageView2);
            if (NumerodeFoto == 1)
            {
                Imagen.SetImageResource(Resource.Drawable.inception);
                txtNombre.Text = "Inception";
                txtDescripcion.Text = "Cobb steals information from his targets by entering their dreams. Saito offers to wipe clean Cobb's criminal history as payment for performing an inception on his sick competitor's son.";
            }
            else
            {
                if(NumerodeFoto == 2)
                {
                    Imagen.SetImageResource(Resource.Drawable.f1);
                    txtNombre.Text = "Drive To Survive";
                    txtDescripcion.Text = "The drivers, managers and team owners in Formula 1 live life in the fast lane -- both on and off the track.";
                }
                else
                {
                    if(NumerodeFoto == 3)
                    {
                        Imagen.SetImageResource(Resource.Drawable.interestellar);
                        txtNombre.Text = "Interestellar";
                        txtDescripcion.Text = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.";
                    }
                    else
                    {
                        if(NumerodeFoto == 4)
                        {
                            Imagen.SetImageResource(Resource.Drawable.wolf);
                            txtNombre.Text = "The Wolf Of Wall Street";
                            txtDescripcion.Text = "Introduced to life in the fast lane through stockbroking, Jordan Belfort takes a hit after a Wall Street crash. He teams up with Donnie Azoff, cheating his way to the top as his relationships slide.";
                        }
                        else
                        {
                            if(NumerodeFoto == 5)
                            {
                                Imagen.SetImageResource(Resource.Drawable.catchme);
                                txtNombre.Text = "Catch Me If You Can";
                                txtDescripcion.Text = "Un agente de FBI asume como propia la misión de capturar el astuto estafador Frank Abagnale Jr. Pero Frank no solo se escapa, sino que se deleita con la persecución.";
                            }
                        }
                    }
                }
            }
            //Toast.MakeText(this, "Fotografia " + NumerodeFoto, ToastLength.Short).Show();
        }
    }
    public class Fotografias
    {
        public int mFotoID;
        public string mTextoFoto;
        public int FotoID { get { return mFotoID; } }
        public string TextoFoto { get { return mTextoFoto; } }
    };

    public class AlbumFotos
    {
        private Fotografias[] Fotos;
        public AlbumFotos()
        {
            Fotos = ConjuntodeFotos;
        }
        public int CantidaddeFotos
        {
            get { return Fotos.Length; }
        }
        public Fotografias this[int i]
        {
            get { return Fotos[i]; }
        }
        static Fotografias[] ConjuntodeFotos = {
            new Fotografias {mFotoID = Resource.Drawable.inception,
            mTextoFoto="[Inception]"},
            new Fotografias {mFotoID = Resource.Drawable.f1,
            mTextoFoto="[F1]"},
            new Fotografias {mFotoID = Resource.Drawable.interestellar,
            mTextoFoto="[Interestellar]"},
            new Fotografias {mFotoID = Resource.Drawable.wolf,
            mTextoFoto="[Wolf of Wall Street]"},
            new Fotografias {mFotoID = Resource.Drawable.catchme,
            mTextoFoto="[Catch Me If You Can]"},
            /*new Fotografias {mFotoID = Resource.Drawable.seis,
            mTextoFoto="[Mars]"},
            new Fotografias {mFotoID = Resource.Drawable.siete,
            mTextoFoto="[Arcade]"},
            new Fotografias {mFotoID = Resource.Drawable.ocho,
            mTextoFoto="[Giordano's]"},
            new Fotografias {mFotoID = Resource.Drawable.nueve,
            mTextoFoto="[Mountains]"},
            new Fotografias {mFotoID = Resource.Drawable.diez,
            mTextoFoto="[Library]"},
            new Fotografias {mFotoID = Resource.Drawable.once,
            mTextoFoto="[Ocean]"},
            new Fotografias {mFotoID = Resource.Drawable.doce,
            mTextoFoto="[People]"},
            new Fotografias {mFotoID = Resource.Drawable.trece,
            mTextoFoto="[Lights]"},
            new Fotografias {mFotoID = Resource.Drawable.catorce,
            mTextoFoto="[Street]"},
            new Fotografias {mFotoID = Resource.Drawable.quince,
            mTextoFoto="[Arcade]"},
            new Fotografias {mFotoID = Resource.Drawable.dieciseis,
            mTextoFoto="[Trump]"},*/
        };
    };
}