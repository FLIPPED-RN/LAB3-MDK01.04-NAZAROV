using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB3_MDK01._04.NAZAROV.Models;

public class MyUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public long IdUser {get; set;}
    public required string Login { get; set; }
    public required  string Password { get; set; }
}