using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGamesLibreryBack.ModelDB
{
    [Table("VideoGameConsoles")]
    public class GameConsole
    {
        [Key]
        public string? ConsoleId { get; set; }
        [StringLength(255)]
        public string? NameConsole {  get; set; }
        [StringLength(20)]
        public string? Company {  get; set; }
        public int Quantity { get; set; }
        public bool IsEspecialEdition { get; set; }
        public bool IsPortable { get; set; }
        public bool IsNew { get; set; }
        public bool IsOpen { get; set; }
        public bool IsComplete { get; set; }
        public bool IsProtected { get; set; }
        public string? Description { get; set; }
    }
}
