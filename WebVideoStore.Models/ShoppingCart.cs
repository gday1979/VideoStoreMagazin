namespace WebVideoStore.Models
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebVideoStore.Models.ViewModels;

    public class ShoppingCart
    {
        public int Id { get; set; }
        public int VideoTapeId { get; set; }
        [ForeignKey("VideoTapeId")]
        [ValidateNever]
        public VideoTape VideoTape { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a count between 1 and 1000")]
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

    }

}
