using System.ComponentModel.DataAnnotations;

namespace CrudSemBD.ViewModel
{
    public class PessoaViewModel
    {
        public int idPessoa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Sexo é obrigatório.")]
        [Display(Name = "Sexo:")]
        public int idSexo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome:")]
        public string nmPessoa { get; set; }
        public string descricaoSexo { get; set; }                                        
                                                                                         
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Data de nascimento é obrigatório.")]
        [Display(Name = "Data de nascimento:")]                                                        
        public string dtNascimento { get; set; }                                         
                                                                                         
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo CPF é obrigatório.")]
        [Display(Name = "CPF:")]
        public string pessoaCPF { get; set; }
    }
}