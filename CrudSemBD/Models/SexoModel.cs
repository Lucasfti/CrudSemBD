using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudSemBD.Models
{
    public class SexoModel
    {
        [Key]
        public int idSexo { get; set; }
        public string descricaoSexo { get; set; }

        public virtual ICollection<PessoaModel> Pessoas { get; set; }

        public SexoModel()
        {
            Pessoas = new HashSet<PessoaModel>();
        }
    }
}