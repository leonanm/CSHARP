using System.ComponentModel.DataAnnotations;

public class Author
{
    public int Id { get; set; }

    [Required] 
    public string Name { get; set; }

    [Required] 
    public string Bio { get; set; }
}
