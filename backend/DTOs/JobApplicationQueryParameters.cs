using System.ComponentModel.DataAnnotations;

namespace Apollo_hire.API.DTOs
{
    public class JobApplicationQueryParameters
    {

        public int PageIndex { get; set; } = 0;
        
        [Range(5, 100)]
        public int PageSize { get; set; } = 50;

        public string? SortColumn { get; set; } = "Date";

        [RegularExpression("ASC|DESC", ErrorMessage = "SortDirection must be ASC or DESC")]
        public string SortDirection { get; set; } = "DESC";

        [MaxLength(200)]
        public string? Search { get; set; } = "";
    }
}   
