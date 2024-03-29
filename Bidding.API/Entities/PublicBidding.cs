﻿using Bidding.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Bidding.API.Entities
{
    [DataContract(IsReference = true)]
    public partial class PublicBidding : IValidatableObject
    {
        public Guid Guid { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartPricePerHectar { get; set; }
        public string Expected { get; set; }
        [JsonConverter(typeof(MunicipalityConverter))]
        public Municipality municipality { get; set; }
        public int AuctionedPrice { get; set; }
        public Guid? BestBuyerGuid { get; set; }

        [JsonConverter(typeof(PublicBiddingTypeConverter))]
        public PublicBiddingType public_bidding_type { get; set; }
        public Guid AddresGuid { get; set; }
        public int LeasePeriod { get; set; }
        public int DepositReplenishmentAmount { get; set; }

        public Guid Round { get; set; }
        [JsonConverter(typeof(BiddingStatusConverter))]

        public BiddingStatus biddingStatus { get; set; }

        public List<Representative> Representatives { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<PublicBiddingLot> PublicBiddingLots { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<BiddingOffer> BiddingOffers { get; set; }

        public PublicBidding() { }
        public PublicBidding(
         Guid publicBiddingGuid,
         DateTime date,
         DateTime startDate,
         DateTime endDate,
         int startPricePerHectar,
         string expected,
         Municipality municipality,
         int auctionedPrice,
         Guid? bestBuyerGuid,
         PublicBiddingType public_bidding_type,
         Guid addressGuid,
         int leasePeriod,
         int depositReplenishmentAmount,
         Guid round,
         BiddingStatus biddingStatus
          )
        {
            Guid = publicBiddingGuid;
            Date = date;
            StartDate = startDate;
            EndDate = endDate;
            StartPricePerHectar = startPricePerHectar;
            Expected = expected;
            this.municipality = municipality;
            AuctionedPrice = auctionedPrice;
            BestBuyerGuid = bestBuyerGuid;
            this.public_bidding_type = public_bidding_type;
            AddresGuid = addressGuid;
            LeasePeriod = leasePeriod;
            DepositReplenishmentAmount = depositReplenishmentAmount;
            this.Round = round;
            this.biddingStatus = biddingStatus;
        }

        public PublicBidding(

         DateTime date,
         DateTime startDate,
         DateTime endDate,
         int startPricePerHectar,
         string expected,
         Municipality municipality,
         int auctionedPrice,
         Guid? bestBuyerGuid,
         PublicBiddingType public_bidding_type,
         Guid addressGuid,
         int leasePeriod,
         int depositReplenishmentAmount,
         Guid round,
         BiddingStatus biddingStatus
          )
        {
            Guid = Guid.NewGuid();
            Date = date;
            StartDate = startDate;
            EndDate = endDate;
            StartPricePerHectar = startPricePerHectar;
            Expected = expected;
            this.municipality = municipality;
            AuctionedPrice = auctionedPrice;
            BestBuyerGuid = bestBuyerGuid;
            this.public_bidding_type = public_bidding_type;
            AddresGuid = addressGuid;
            LeasePeriod = leasePeriod;
            DepositReplenishmentAmount = depositReplenishmentAmount;
            this.Round = round;
            this.biddingStatus = biddingStatus;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Guid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }


            if (Date > EndDate)
            {
                results.Add(new ValidationResult("Date cannot be greater than EndDate."));
            }

            if (StartDate > EndDate)
            {
                results.Add(new ValidationResult("StartDate cannot be greater than EndDate."));
            }

            if (AuctionedPrice < StartPricePerHectar)
            {
                results.Add(new ValidationResult("AuctionedPrice cannot be less than StartPricePerHectar."));
            }

            if (LeasePeriod <= 0)
            {
                results.Add(new ValidationResult("LeasePeriod must be greater than 0."));
            }

            if (DepositReplenishmentAmount <= 0)
            {
                results.Add(new ValidationResult("DepositReplenishmentAmount must be greater than 0."));
            }

            if (string.IsNullOrEmpty(Expected))
            {
                results.Add(new ValidationResult("Expected must not be empty."));
            }





            if (AddresGuid == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }




            if (Round == Guid.Empty)
            {
                results.Add(new ValidationResult("Guid cannot be empty."));
            }




            return results;
        }




    }
}
