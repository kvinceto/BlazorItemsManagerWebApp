﻿namespace BlazorItemsManagerWebApp.Web.Data.Models
{
    public class User
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Role { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}