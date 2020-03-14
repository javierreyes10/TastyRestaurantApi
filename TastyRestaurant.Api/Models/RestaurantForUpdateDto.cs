﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TastyRestaurant.Api.Models
{
    public class RestaurantForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a Name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
