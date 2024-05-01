namespace WebVideoStore.Models.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VideoTape
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Title { get; set; }
        [Required]
        [Range(1960,2024,ErrorMessage ="Year for Production must be 1960-2024")]
        public int Year { get; set; }
        [Required]
        public string? Director { get; set; }
        [Required]
        [Display(Name ="Price for Rent")]
        [Range(1,10,ErrorMessage ="Price must be between 1-10")]
        public double PriceRent { get; set; }
        [Required]
        [Display(Name = "Price for Buy")]
        [Range(1, 100, ErrorMessage = "Price must be between 1-100")]
        public double PriceBuy { get; set; }
    }
}
