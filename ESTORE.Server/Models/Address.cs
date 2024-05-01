﻿namespace ESTORE.Server.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Barangay { get; set; } = string.Empty;
        public int ZipCode { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
