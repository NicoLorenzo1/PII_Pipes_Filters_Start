using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;

namespace CompAndDel.Pipes
{
    public class PipeCognitive : IPipeConditional
    {
        protected IFilterConditional filtro;
        protected IPipe nextPipeA;
        protected IPipe nextPipeB;


        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeCognitive(IFilterConditional filtro, IPipe nextPipeA, IPipe nextPipeB)
        {
            this.nextPipeA = nextPipeA;
            this.nextPipeB = nextPipeB;

            this.filtro = filtro;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe NextA
        {
            get { return this.nextPipeA; }
        }
        public IPipe NextB
        {
            get { return this.nextPipeB; }
        }
        /// <summary>
        /// Devuelve el IFilterConditional que aplica este pipe
        /// </summary>
        public IFilterConditional Filter
        {
            get { return this.filtro; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {

            Boolean condicion = this.filtro.Filter(picture);
            Console.WriteLine(">>>> " + condicion);
            if (condicion)
            {
                return this.nextPipeA.Send(picture);
            }
            else
            {
                return this.nextPipeB.Send(picture);
            }
            //return condicion ? this.nextPipeA.Send(picture) : this.nextPipeB.Send(picture);
        }
    }
}