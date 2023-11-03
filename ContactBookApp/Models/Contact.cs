using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactBookApp.Models
{
    [Table(name: "Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "EL nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "EL telefono es requerido")]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "EL celular es requerido")]
        [Display(Name = "Celular")]
        public string CellPhone { get; set; }

        [EmailAddress(ErrorMessage = "La dirección de correo electrónico no es válida")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Display(Name = "Fecha de creacion")]
        public DateTime CreationDate { get; set; }
    }
}
