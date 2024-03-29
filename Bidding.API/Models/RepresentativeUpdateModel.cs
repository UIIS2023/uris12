﻿namespace Bidding.API.Models
{
    public class RepresentativeUpdateModel
    {



        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? IdentificationNumber { get; set; }

        public Guid addressGuid { get; set; }



        public int? NumberOfBoard { get; set; }


        public Guid PublicBiddingGuid { get; set; }

        public RepresentativeUpdateModel() { }




        public RepresentativeUpdateModel(string? firstName, string? lastName, string? identificationNumber,
                         Guid addressGuid, int? numberOfBoard, Guid publicBiddingGuid)
        {

            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            this.addressGuid = addressGuid;
            NumberOfBoard = numberOfBoard;
            PublicBiddingGuid = publicBiddingGuid;

        }
    }
}
