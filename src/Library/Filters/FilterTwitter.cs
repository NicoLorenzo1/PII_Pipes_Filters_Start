using System;
using CompAndDel;
using TwitterUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen, la publica en twitter y devuelve la misma imagen.
    /// </remarks>
    public class FilterTwitter : IFilter
    {
        /// Un filtro que publica la imagen en twitter y la devuelve.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            //aca va el codigo para publicar en twitter
            pruebaTwitter(image);
            return image;
        }
        async private void pruebaTwitter(IPicture image)
        {
            TwitterImage twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Hola!!", @"result.jpg"));

        }
    }
}
