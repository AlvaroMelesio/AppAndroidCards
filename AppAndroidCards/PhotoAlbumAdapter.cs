using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace AppAndroidCards
{
    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> SeleccionElemento;
        public AlbumFotos mAlbumFotos;

        public PhotoAlbumAdapter(AlbumFotos AlbumFotos)
        {
            mAlbumFotos = AlbumFotos;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup Contenido, int viewType)
        {
            View VistaDeElemento = LayoutInflater.From(Contenido.Context).
                Inflate(Resource.Layout.PhotoCardView, Contenido, false);
            var vh = new PhotoViewHolder(VistaDeElemento, OnClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder cabecera, int position)
        {
            PhotoViewHolder pvh = cabecera as PhotoViewHolder;
            pvh.Imagen.SetImageResource(mAlbumFotos[position].FotoID);
            pvh.Texto.Text = mAlbumFotos[position].TextoFoto;
        }

        public override int ItemCount
        {
            get { return mAlbumFotos.CantidaddeFotos; }
        }

        void OnClick(int position)
        {
            SeleccionElemento(this, position);
        }
    }
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Imagen { get; private set; }
        public TextView Texto { get; private set; }
        public PhotoViewHolder(View Elemento, Action<int> Colocador):base(Elemento)
        {
            Elemento.Click += (sender, e) => Colocador(base.LayoutPosition);
            Texto = Elemento.FindViewById<TextView>(Resource.Id.texto);
            Imagen = Elemento.FindViewById<ImageView>(Resource.Id.imagen);
        }
    }
}