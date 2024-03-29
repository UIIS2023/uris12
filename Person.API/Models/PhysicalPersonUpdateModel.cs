﻿using System.ComponentModel.DataAnnotations;


namespace Person.API.Models


{   /// <summary>
    /// Dto Update fizičko lice
    /// </summary>
    public class PhysicalPersonUpdateModel
    {
        /// <summary>
        /// Ime fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ime!")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Prezime fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti prezime!")]
        public string? LastName { get; set; }

        /// <summary>
        /// Jmbg fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti jmbg!")]
        public string? Jmbg { get; set; }

        /// <summary>
        /// Adresa id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id adrese!")]
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Broj telefona fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 1!")]
        public string? PhoneNumber1 { get; set; }

        /// <summary>
        /// Broj telefona 2 fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj telefona 2!")]
        public string? PhoneNumber2 { get; set; }

        /// <summary>
        /// Email fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti email!")]
        public string? Email { get; set; }

        /// <summary>
        /// Broj računa fizičkog lica
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj računa!")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Represents a model used to update a physical person's information.
        /// </summary>
        public PhysicalPersonUpdateModel(string? firstName, string? lastName, string? jmbg, Guid? addressId, string? phoneNumber1, string? phoneNumber2, string? email, string? accountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Jmbg = jmbg;
            AddressId = addressId;
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            Email = email;
            AccountNumber = accountNumber;
        }
    }
}