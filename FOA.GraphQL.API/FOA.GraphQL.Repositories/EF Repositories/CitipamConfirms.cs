using System;
using System.Collections.Generic;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class CitipamConfirms
    {
        public int CitipamConfirmId { get; set; }
        public string ConfirmFilename { get; set; }
        public int OrderId { get; set; }
        public string PortfolioCode { get; set; }
        public string CitiFundCode { get; set; }
        public DateTime DateLoaded { get; set; }
        public string ClientReference { get; set; }
        public string OrderReference { get; set; }
        public string Hub { get; set; }
        public string Customer { get; set; }
        public string MessageType { get; set; }
        public string ProviderConfirmReference { get; set; }
        public string PreviousReferenceForReplace { get; set; }
        public string OrderType { get; set; }
        public string FsvsAccount { get; set; }
        public string RegistrationInve { get; set; }
        public string AccountRegistrationCis { get; set; }
        public string PortfolioId { get; set; }
        public string SkAccount { get; set; }
        public string FundId { get; set; }
        public string FundName { get; set; }
        public decimal? Shares { get; set; }
        public decimal? Cash { get; set; }
        public string FundBaseCurrency { get; set; }
        public string AltPaymentCurrency { get; set; }
        public string TradeDate { get; set; }
        public string ValueDate { get; set; }
        public string AccountAtTa { get; set; }
        public string ContractReference { get; set; }
        public string PriceNavCurrency { get; set; }
        public decimal? PriceNav { get; set; }
        public decimal? ActualShares { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? GrossAmountInFundCurrency { get; set; }
        public string ExchangeRate { get; set; }
        public decimal? NetAmount { get; set; }
        public string Charge1Currency { get; set; }
        public decimal? Charge1Amount { get; set; }
        public string Charge2Currency { get; set; }
        public decimal? Charge2Amount { get; set; }
        public string Charge3Currency { get; set; }
        public decimal? Charge3Amount { get; set; }
        public string Charge4Currency { get; set; }
        public decimal? Charge4Amount { get; set; }
        public string Charge5Currency { get; set; }
        public decimal? Charge5Amount { get; set; }
        public string Charge6Currency { get; set; }
        public decimal? Charge6Amount { get; set; }
        public string Charge7Currency { get; set; }
        public decimal? Charge7Amount { get; set; }
        public string Charge8Currency { get; set; }
        public decimal? Charge8Amount { get; set; }
        public string Charge9Currency { get; set; }
        public decimal? Charge9Amount { get; set; }
        public string Charge10Currency { get; set; }
        public decimal? Charge10Amount { get; set; }
        public string Charge11Currency { get; set; }
        public decimal? Charge11Amount { get; set; }
        public string Charge12Currency { get; set; }
        public decimal? Charge12Amount { get; set; }
        public string Charge13Currency { get; set; }
        public decimal? Charge13Amount { get; set; }
        public long? AuditId { get; set; }
    }
}
