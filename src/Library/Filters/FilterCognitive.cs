using System;
using System.Drawing;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterCognitive : IFilterConditional
    {
        /// Un filtro que retorna true o false si la imagen filtrada contiene una cara o no.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>true or false.</returns>
        public Boolean Filter(IPicture picture)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(picture, @"picture_Aux.jpg"); //para recibir una IPicture y usarla en CognitiveFace

            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(@"picture_Aux.jpg");
            return cog.FaceFound;
        }
    }
}
