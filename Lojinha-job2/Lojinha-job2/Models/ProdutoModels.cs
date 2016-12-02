using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lojinha_job2.Models
{
    public class ProdutoModel
    {
        public long Id { get; set; }
        public String Nome { get; set; }
        public Boolean Ativo { get; set; }
        public Double Valor {get; set;}
        public virtual CategoriaProdutoModel Categoria { get; set; }
        public virtual IList<ComentarioProdutoModel> ComentarioLst { get; set; }
    }

    public class CategoriaProdutoModel
    {
        public long Id { get; set; }
        public String Titulo { get; set; }
    }

    public class ComentarioProdutoModel
    {
        public long Id { get; set; }
        public String Conteudo { get; set; }
        public ProdutoModel Produto { get; set; }
    }
}