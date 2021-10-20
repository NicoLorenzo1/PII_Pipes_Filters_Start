using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //parte3 - publicar imagen en twitter
            //parte3();

            //parte4 - pipe con bifurcacion 
            parte4();

        }

        static void parte4()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"bill2.jpg");
            //IPicture picture = provider.GetPicture(@"beer.jpg");


            PipeNull pipenull = new PipeNull();

            // Si la imagen tiene cara----------------------------------------------------------
            IFilter filterSave = new FilterSave();
            IPipe pipeserial1 = new PipeSerial(filterSave, pipenull);
            //----------------------------------------------------------

            //Si la imagen no tiene cara--------------------------------------------------------
            IFilter filterNegative = new FilterNegative();
            IPipe pipeserial3 = new PipeSerial(filterNegative, pipenull);

            IFilter filterGrey = new FilterGreyscale();
            IPipe pipeserial2 = new PipeSerial(filterSave, pipeserial3);
            //----------------------------------------------------------------------------------

            IPipe pipeA = new PipeSerial(filterSave, pipeserial1); // pipe a seguir cuando tiene cara
            IPipe pipeB = new PipeSerial(filterGrey, pipeserial2); // pipe a seguir cuando no tiene cara

            IFilterConditional filterConditional = new FilterCognitive();
            IPipeConditional pipeConditional = new PipeCognitive(filterConditional, pipeA, pipeB);

            IPicture result = pipeConditional.Send(picture); //devuelvo la imagen con los filtros aplicados
        }

        static void parte3()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"bill2.jpg");

            PipeNull pipenull = new PipeNull();

            IFilter filterTwitter = new FilterTwitter();
            IPipe pipeserial4 = new PipeSerial(filterTwitter, pipenull);

            IFilter filterSave = new FilterSave();
            IPipe pipeserial3 = new PipeSerial(filterSave, pipeserial4);

            IFilter filternegative = new FilterNegative();
            IPipe pipeserial2 = new PipeSerial(filternegative, pipeserial3);

            IFilter filtergreyscale = new FilterGreyscale();
            IPipe pipeserial1 = new PipeSerial(filtergreyscale, pipeserial2);

            IPicture result = pipeserial1.Send(picture); //devuelvo la imagen con los filtros aplicados
        }
    }
}
