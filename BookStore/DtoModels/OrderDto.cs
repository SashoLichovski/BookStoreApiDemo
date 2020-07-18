using BookStore.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DtoModels
{
    public class OrderDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string TrackingNumber { get; set; }
        [Required]
        public double FullPrice { get; set; }
        public string Status { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
