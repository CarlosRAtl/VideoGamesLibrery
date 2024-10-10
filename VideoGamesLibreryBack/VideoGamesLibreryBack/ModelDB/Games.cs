using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGamesLibreryBack.ModelDB
{
    [Table("Games")]
    public class Games
    {
        [Key]
        public string? GameId { get; set; }
        [StringLength(255)]
        public string? GameName { get; set; }
        public int Quantity { get; set; }
        public bool IsEspecialEdition { get; set; }
        public bool IsDigital { get; set; }
        [StringLength(20)]
        public string? Company { get; set; }
        public bool IsPlayed { get; set; }
        [StringLength(50)]
        public string? ConsoleName { get; set; }
        public bool IsFinished { get; set; }
        public bool IsProtected { get; set; }
    }
}

