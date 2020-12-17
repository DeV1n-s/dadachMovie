using System;

namespace dadachMovie.DTOs
{
    public class FilterPersonDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public PaginationDTO Pagination
        {
            get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage };}
        }
        public string Name { get; set; }
        public bool IsCast { get; set; }
        public bool IsDirector { get; set; }
        public DateTime MinDateOfBirth { get; set; }
        public DateTime MaxDateOfBirth { get; set; } = DateTime.Now;
        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true;
    }
}