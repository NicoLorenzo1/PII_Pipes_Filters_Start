using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterSave : IFilter
    {
        /// Un filtro que guarda y retorna la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, @"result.jpg");
            return image;
        }
    }
}
