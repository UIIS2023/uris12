﻿namespace Bidding.API.Models
{
    public class BuyerApplicationRequestModel
    {


        public Guid RepresentativeGuid { get; set; }

        public int Amount { get; set; }



        public BuyerApplicationRequestModel() { }
        public BuyerApplicationRequestModel(Guid representativeGuid, int amount)
        {

            RepresentativeGuid = representativeGuid;
            Amount = amount;

        }
    }
}
