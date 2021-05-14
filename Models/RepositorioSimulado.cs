using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLivros.Models
{
    public class RepositorioSimulado
    {
        private static List<Livro> livros;

        public static List<Livro> Livros
        {
            get
            {
                if (livros == null)
                    GerarLivros();
                return livros;
            }
            set
            {
                livros = value;
            }
        }

        private static void GerarLivros()
        {
            livros = new List<Livro>();

            livros.Add(new Livro
            {
                ID = 1,
                Titulo = "Agile",
                Autor = "André Faria Gomes"
            });

            livros.Add(new Livro
            {
                ID = 2,
                Titulo = "Building Microservices",
                Autor = "Sam Newman"
            });

            livros.Add(new Livro
            {
                ID = 3,
                Titulo = "Controlando versões com Git e Github",
                Autor = "Alexandre Aquiles; Rodrigo Ferreira"
            });
        }
    }
}