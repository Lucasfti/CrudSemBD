using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudSemBD.Models
{
    public class PessoaModel
    {
        [Key]
        public int idPessoa { get; set; }

        [ForeignKey("Sexo")]
        public int idSexo { get; set; }
        public string nmPessoa { get; set; }
        public DateTime dtNascimento { get; set; }
        public string pessoaCPF { get; set; }
        public virtual SexoModel Sexo { get; set; }
    }
}