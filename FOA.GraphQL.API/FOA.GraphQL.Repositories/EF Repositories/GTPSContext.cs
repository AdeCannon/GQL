using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace FOA.GraphQL.Repositories.Repositories
{
    public partial class GTPSContext : DbContext
    {
        public static readonly LoggerFactory LoggerFactory =
            new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public GTPSContext()
        {
        }

        public GTPSContext(DbContextOptions<GTPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allocations> Allocations { get; set; }
        public virtual DbSet<AllocationTransmissionRef> AllocationTransmissionRef { get; set; }
        public virtual DbSet<AuditData> AuditData { get; set; }
        public virtual DbSet<CitipamConfirms> CitipamConfirms { get; set; }
        public virtual DbSet<CurrencyData> CurrencyData { get; set; }
        public virtual DbSet<ExchangeCountriesData> ExchangeCountriesData { get; set; }
        public virtual DbSet<ExecBrokerData> ExecBrokerData { get; set; }
        public virtual DbSet<GiveupBrokerData> GiveupBrokerData { get; set; }
        public virtual DbSet<IrscurrencyData> IrscurrencyData { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Listitem> Listitem { get; set; }
        public virtual DbSet<OrderLog> OrderLog { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ScheduledTask> ScheduledTask { get; set; }
        public virtual DbSet<ScheduledTaskTransmissionRef> ScheduledTaskTransmissionRef { get; set; }
        public virtual DbSet<SsbTradeFeedFlatControl> SsbTradeFeedFlatControl { get; set; }
        public virtual DbSet<SystemParameters> SystemParameters { get; set; }
        public virtual DbSet<TransmissionLog> TransmissionLog { get; set; }
        public virtual DbSet<Transmissions> Transmissions { get; set; }

        // Unable to generate entity type for table 'FOFC.SCHEDULED_TASK_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.CITIPAM_CONFIRMS_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.LIST_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.LISTITEM_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.SYSTEM_PARAMETERS_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.CONTROL_REPORT_ENTRIES'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.ORDERS_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.ORDER_LOG_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.ALLOCATIONS_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.TRANSMISSIONS_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.TRANSMISSION_LOG_JN'. Please see the warning messages.
        // Unable to generate entity type for table 'FOFC.UnitInIssueFund'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder
                    .EnableSensitiveDataLogging()
                    .UseSqlServer("Server=LDNEC1AD\\ESA2012;Database=GTPS;Trusted_Connection=True;")
                    .UseLoggerFactory(LoggerFactory);

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "GLOBAL\\U46669");

            modelBuilder.Entity<Allocations>(entity =>
            {
                entity.HasKey(e => e.AllocationId);

                entity.ToTable("ALLOCATIONS", "FOFC");

                entity.Property(e => e.AllocationId).HasColumnName("ALLOCATION_ID");

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.ClearBroker)
                    .HasColumnName("CLEAR_BROKER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClearBrokerBic)
                    .HasColumnName("CLEAR_BROKER_BIC")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ExecBroker)
                    .HasColumnName("EXEC_BROKER")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ExecBrokerBic)
                    .HasColumnName("EXEC_BROKER_BIC")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.GamFundCode)
                    .HasColumnName("GAM_FUND_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NetAmount)
                    .HasColumnName("NET_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.PortfolioCode)
                    .IsRequired()
                    .HasColumnName("PORTFOLIO_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("QUANTITY")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROW_VERSION")
                    .IsRowVersion();

                entity.Property(e => e.SecurityCcy)
                    .IsRequired()
                    .HasColumnName("SECURITY_CCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityDesc)
                    .IsRequired()
                    .HasColumnName("SECURITY_DESC")
                    .HasMaxLength(255);

                entity.Property(e => e.SecurityId)
                    .IsRequired()
                    .HasColumnName("SECURITY_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SettlCcy)
                    .IsRequired()
                    .HasColumnName("SETTL_CCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SideListCode)
                    .IsRequired()
                    .HasColumnName("SIDE_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SideListitemCode)
                    .IsRequired()
                    .HasColumnName("SIDE_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Allocations)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALLOCATIONS_ORDERS");

                entity.HasOne(d => d.SideList)
                    .WithMany(p => p.Allocations)
                    .HasForeignKey(d => new { d.SideListitemCode, d.SideListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALLOCATIONS_SIDE");
            });

            modelBuilder.Entity<AllocationTransmissionRef>(entity =>
            {
                entity.HasKey(e => new { e.AllocationId, e.TransmissionId });

                entity.ToTable("ALLOCATION_TRANSMISSION_REF", "FOFC");

                entity.Property(e => e.AllocationId).HasColumnName("ALLOCATION_ID");

                entity.Property(e => e.TransmissionId).HasColumnName("TRANSMISSION_ID");

                entity.HasOne(d => d.Allocation)
                    .WithMany(p => p.AllocationTransmissionRef)
                    .HasForeignKey(d => d.AllocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALLOCATION_TRANSMISSION_REF_ALLOCATION");

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.AllocationTransmissionRef)
                    .HasForeignKey(d => d.TransmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALLOCATION_TRANSMISSION_REF_TRANSMISSION");
            });

            modelBuilder.Entity<AuditData>(entity =>
            {
                entity.HasKey(e => e.AuditId);

                entity.ToTable("AUDIT_DATA", "FOFC");

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasColumnName("APPLICATION_NAME")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(coalesce(app_name(),'?'))");

                entity.Property(e => e.ChangedBy)
                    .IsRequired()
                    .HasColumnName("CHANGED_BY")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("(coalesce(suser_sname(),'?'))");

                entity.Property(e => e.ChangedDate)
                    .HasColumnName("CHANGED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChangedType)
                    .IsRequired()
                    .HasColumnName("CHANGED_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HostName)
                    .IsRequired()
                    .HasColumnName("HOST_NAME")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(coalesce(host_name(),'?'))");

                entity.Property(e => e.LastAuditId).HasColumnName("LAST_AUDIT_ID");
            });

            modelBuilder.Entity<CitipamConfirms>(entity =>
            {
                entity.HasKey(e => e.CitipamConfirmId);

                entity.ToTable("CITIPAM_CONFIRMS", "FOFC");

                entity.Property(e => e.CitipamConfirmId).HasColumnName("CITIPAM_CONFIRM_ID");

                entity.Property(e => e.AccountAtTa)
                    .HasColumnName("ACCOUNT_AT_TA")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AccountRegistrationCis)
                    .HasColumnName("ACCOUNT_REGISTRATION_CIS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ActualShares)
                    .HasColumnName("ACTUAL_SHARES")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.AltPaymentCurrency)
                    .HasColumnName("ALT_PAYMENT_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.Cash)
                    .HasColumnName("CASH")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge10Amount)
                    .HasColumnName("CHARGE_10_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge10Currency)
                    .HasColumnName("CHARGE_10_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge11Amount)
                    .HasColumnName("CHARGE_11_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge11Currency)
                    .HasColumnName("CHARGE_11_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge12Amount)
                    .HasColumnName("CHARGE_12_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge12Currency)
                    .HasColumnName("CHARGE_12_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge13Amount)
                    .HasColumnName("CHARGE_13_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge13Currency)
                    .HasColumnName("CHARGE_13_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge1Amount)
                    .HasColumnName("CHARGE_1_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge1Currency)
                    .HasColumnName("CHARGE_1_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge2Amount)
                    .HasColumnName("CHARGE_2_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge2Currency)
                    .HasColumnName("CHARGE_2_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge3Amount)
                    .HasColumnName("CHARGE_3_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge3Currency)
                    .HasColumnName("CHARGE_3_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge4Amount)
                    .HasColumnName("CHARGE_4_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge4Currency)
                    .HasColumnName("CHARGE_4_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge5Amount)
                    .HasColumnName("CHARGE_5_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge5Currency)
                    .HasColumnName("CHARGE_5_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge6Amount)
                    .HasColumnName("CHARGE_6_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge6Currency)
                    .HasColumnName("CHARGE_6_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge7Amount)
                    .HasColumnName("CHARGE_7_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge7Currency)
                    .HasColumnName("CHARGE_7_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge8Amount)
                    .HasColumnName("CHARGE_8_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge8Currency)
                    .HasColumnName("CHARGE_8_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Charge9Amount)
                    .HasColumnName("CHARGE_9_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Charge9Currency)
                    .HasColumnName("CHARGE_9_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CitiFundCode)
                    .HasColumnName("CITI_FUND_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClientReference)
                    .IsRequired()
                    .HasColumnName("CLIENT_REFERENCE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmFilename)
                    .IsRequired()
                    .HasColumnName("CONFIRM_FILENAME")
                    .HasMaxLength(255);

                entity.Property(e => e.ContractReference)
                    .HasColumnName("CONTRACT_REFERENCE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasColumnName("CUSTOMER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateLoaded)
                    .HasColumnName("DATE_LOADED")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnName("EXCHANGE_RATE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FsvsAccount)
                    .HasColumnName("FSVS_ACCOUNT")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FundBaseCurrency)
                    .HasColumnName("FUND_BASE_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FundId)
                    .HasColumnName("FUND_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FundName)
                    .HasColumnName("FUND_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("GROSS_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.GrossAmountInFundCurrency)
                    .HasColumnName("GROSS_AMOUNT_IN_FUND_CURRENCY")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.Hub)
                    .HasColumnName("HUB")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MessageType)
                    .HasColumnName("MESSAGE_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NetAmount)
                    .HasColumnName("NET_AMOUNT")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.OrderReference)
                    .HasColumnName("ORDER_REFERENCE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasColumnName("ORDER_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PortfolioCode)
                    .HasColumnName("PORTFOLIO_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PortfolioId)
                    .HasColumnName("PORTFOLIO_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PreviousReferenceForReplace)
                    .HasColumnName("PREVIOUS_REFERENCE_FOR_REPLACE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PriceNav)
                    .HasColumnName("PRICE_NAV")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.PriceNavCurrency)
                    .HasColumnName("PRICE_NAV_CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderConfirmReference)
                    .HasColumnName("PROVIDER_CONFIRM_REFERENCE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationInve)
                    .HasColumnName("REGISTRATION_INVE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Shares)
                    .HasColumnName("SHARES")
                    .HasColumnType("numeric(28, 12)");

                entity.Property(e => e.SkAccount)
                    .HasColumnName("SK_ACCOUNT")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TradeDate)
                    .HasColumnName("TRADE_DATE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValueDate)
                    .HasColumnName("VALUE_DATE")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CurrencyData>(entity =>
            {
                entity.HasKey(e => new { e.Currency, e.Index });

                entity.ToTable("CURRENCY_DATA", "FOFC");

                entity.Property(e => e.Currency)
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Index).HasColumnName("INDEX");

                entity.Property(e => e.Giveup)
                    .IsRequired()
                    .HasColumnName("GIVEUP")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExchangeCountriesData>(entity =>
            {
                entity.HasKey(e => e.Exchange);

                entity.ToTable("EXCHANGE_COUNTRIES_DATA", "FOFC");

                entity.Property(e => e.Exchange)
                    .HasColumnName("EXCHANGE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExecBrokerData>(entity =>
            {
                entity.HasKey(e => e.Broker);

                entity.ToTable("EXEC_BROKER_DATA", "FOFC");

                entity.Property(e => e.Broker)
                    .HasColumnName("BROKER")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Giveup)
                    .IsRequired()
                    .HasColumnName("GIVEUP")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GiveupBrokerData>(entity =>
            {
                entity.HasKey(e => new { e.Casc, e.Cpc, e.Crc });

                entity.ToTable("GIVEUP_BROKER_DATA", "FOFC");

                entity.Property(e => e.Casc)
                    .HasColumnName("CASC")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cpc)
                    .HasColumnName("CPC")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Crc)
                    .HasColumnName("CRC")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Broker)
                    .IsRequired()
                    .HasColumnName("BROKER")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mintfsec)
                    .IsRequired()
                    .HasColumnName("MINTFSEC")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IrscurrencyData>(entity =>
            {
                entity.HasKey(e => new { e.Cac, e.Ccy, e.Type });

                entity.ToTable("IRSCURRENCY_DATA", "FOFC");

                entity.Property(e => e.Cac)
                    .HasColumnName("CAC")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ccy)
                    .HasColumnName("CCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Maxtenor).HasColumnName("MAXTENOR");

                entity.Property(e => e.Mintenor).HasColumnName("MINTENOR");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => e.ListCode);

                entity.ToTable("LIST", "FOFC");

                entity.Property(e => e.ListCode)
                    .HasColumnName("LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("LABEL")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Listitem>(entity =>
            {
                entity.HasKey(e => new { e.ListitemCode, e.ListCode });

                entity.ToTable("LISTITEM", "FOFC");

                entity.Property(e => e.ListitemCode)
                    .HasColumnName("LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ListCode)
                    .HasColumnName("LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("LABEL")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ListOrder).HasColumnName("LIST_ORDER");

                entity.HasOne(d => d.ListCodeNavigation)
                    .WithMany(p => p.Listitem)
                    .HasForeignKey(d => d.ListCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LISTITEM_LIST");
            });

            modelBuilder.Entity<OrderLog>(entity =>
            {
                entity.ToTable("ORDER_LOG", "FOFC");

                entity.Property(e => e.OrderLogId).HasColumnName("ORDER_LOG_ID");

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.Comment)
                    .HasColumnName("COMMENT")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.StatusListCode)
                    .IsRequired()
                    .HasColumnName("STATUS_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusListitemCode)
                    .IsRequired()
                    .HasColumnName("STATUS_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLog)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_LOG_ORDERS");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("ORDERS", "FOFC");

                entity.HasIndex(e => e.OmsOrderId);

                entity.HasIndex(e => new { e.OmsOrderId, e.OmsOrderVersionId })
                    .HasName("PK_OMS_ORDER_REF")
                    .IsUnique();

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("CONTENT")
                    .HasColumnType("xml");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.GamId)
                    .HasColumnName("GAM_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OmsOrderId)
                    .IsRequired()
                    .HasColumnName("OMS_ORDER_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OmsOrderVersionId)
                    .IsRequired()
                    .HasColumnName("OMS_ORDER_VERSION_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrevOrderId).HasColumnName("PREV_ORDER_ID");

                entity.Property(e => e.SecurityType)
                    .IsRequired()
                    .HasColumnName("SECURITY_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SettlDate)
                    .HasColumnName("SETTL_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceListCode)
                    .IsRequired()
                    .HasColumnName("SOURCE_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SourceListitemCode)
                    .IsRequired()
                    .HasColumnName("SOURCE_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TradeDate)
                    .HasColumnName("TRADE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TradeStatusListCode)
                    .IsRequired()
                    .HasColumnName("TRADE_STATUS_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TradeStatusListitemCode)
                    .IsRequired()
                    .HasColumnName("TRADE_STATUS_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Trader)
                    .IsRequired()
                    .HasColumnName("TRADER")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.PrevOrder)
                    .WithMany(p => p.InversePrevOrder)
                    .HasForeignKey(d => d.PrevOrderId)
                    .HasConstraintName("FK_ORDERS_PARENT_ORDER");

                entity.HasOne(d => d.SourceList)
                    .WithMany(p => p.OrdersSourceList)
                    .HasForeignKey(d => new { d.SourceListitemCode, d.SourceListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_SOURCE");

                entity.HasOne(d => d.TradeStatusList)
                    .WithMany(p => p.OrdersTradeStatusList)
                    .HasForeignKey(d => new { d.TradeStatusListitemCode, d.TradeStatusListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_TRADE_STATUS");
            });

            modelBuilder.Entity<ScheduledTask>(entity =>
            {
                entity.ToTable("SCHEDULED_TASK", "FOFC");

                entity.Property(e => e.ScheduledTaskId).HasColumnName("SCHEDULED_TASK_ID");

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ScheduledTaskXml)
                    .HasColumnName("SCHEDULED_TASK_XML")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TypeListCode)
                    .HasColumnName("TYPE_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TypeListitemCode)
                    .HasColumnName("TYPE_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypeList)
                    .WithMany(p => p.ScheduledTask)
                    .HasForeignKey(d => new { d.TypeListitemCode, d.TypeListCode })
                    .HasConstraintName("FK_SCHEDULED_TASK_TYPE");
            });

            modelBuilder.Entity<ScheduledTaskTransmissionRef>(entity =>
            {
                entity.HasKey(e => new { e.ScheduledTaskId, e.TransmissionId });

                entity.ToTable("SCHEDULED_TASK_TRANSMISSION_REF", "FOFC");

                entity.Property(e => e.ScheduledTaskId).HasColumnName("SCHEDULED_TASK_ID");

                entity.Property(e => e.TransmissionId).HasColumnName("TRANSMISSION_ID");

                entity.HasOne(d => d.ScheduledTask)
                    .WithMany(p => p.ScheduledTaskTransmissionRef)
                    .HasForeignKey(d => d.ScheduledTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SCHEDULED__SCHED__0A2A2B3D");

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.ScheduledTaskTransmissionRef)
                    .HasForeignKey(d => d.TransmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SCHEDULED__TRANS__0B1E4F76");
            });

            modelBuilder.Entity<SsbTradeFeedFlatControl>(entity =>
            {
                entity.HasKey(e => e.ControlId);

                entity.ToTable("SSB_TRADE_FEED_FLAT_CONTROL", "FOFC");

                entity.Property(e => e.ControlId).HasColumnName("CONTROL_ID");

                entity.Property(e => e.CreatedDate).HasColumnName("CREATED_DATE");

                entity.Property(e => e.ExternalId).HasColumnName("EXTERNAL_ID");
            });

            modelBuilder.Entity<SystemParameters>(entity =>
            {
                entity.HasKey(e => e.SystemParameterId);

                entity.ToTable("SYSTEM_PARAMETERS", "FOFC");

                entity.HasIndex(e => new { e.CategoryName, e.SectionName, e.Environment, e.ParamName })
                    .HasName("UK_SYSTEM_PARAMETERS")
                    .IsUnique();

                entity.Property(e => e.SystemParameterId).HasColumnName("SYSTEM_PARAMETER_ID");

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.BooleanValue).HasColumnName("BOOLEAN__VALUE");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("CATEGORY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateValue)
                    .HasColumnName("DATE_VALUE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Environment)
                    .IsRequired()
                    .HasColumnName("ENVIRONMENT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumericValue)
                    .HasColumnName("NUMERIC_VALUE")
                    .HasColumnType("numeric(38, 8)");

                entity.Property(e => e.ParamName)
                    .IsRequired()
                    .HasColumnName("PARAM_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasColumnName("SECTION_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TextValue)
                    .HasColumnName("TEXT_VALUE")
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransmissionLog>(entity =>
            {
                entity.ToTable("TRANSMISSION_LOG", "FOFC");

                entity.HasIndex(e => new { e.TransmissionLogId, e.TypeListCode, e.TypeListitemCode, e.StatusListCode, e.StatusListitemCode, e.Comment, e.Content, e.AuditId, e.TransmissionId })
                    .HasName("NCI_TRAN_ID");

                entity.Property(e => e.TransmissionLogId).HasColumnName("TRANSMISSION_LOG_ID");

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.Comment)
                    .HasColumnName("COMMENT")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .HasColumnName("CONTENT")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.StatusListCode)
                    .IsRequired()
                    .HasColumnName("STATUS_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusListitemCode)
                    .IsRequired()
                    .HasColumnName("STATUS_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransmissionId).HasColumnName("TRANSMISSION_ID");

                entity.Property(e => e.TypeListCode)
                    .IsRequired()
                    .HasColumnName("TYPE_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TypeListitemCode)
                    .IsRequired()
                    .HasColumnName("TYPE_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.TransmissionLog)
                    .HasForeignKey(d => d.TransmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANSMISSION_LOG_TRANSMISSIONS");

                entity.HasOne(d => d.StatusList)
                    .WithMany(p => p.TransmissionLogStatusList)
                    .HasForeignKey(d => new { d.StatusListitemCode, d.StatusListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANSMISSIONS_LOG_STATUS");

                entity.HasOne(d => d.TypeList)
                    .WithMany(p => p.TransmissionLogTypeList)
                    .HasForeignKey(d => new { d.TypeListitemCode, d.TypeListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANSMISSIONS_LOG_TYPE");
            });

            modelBuilder.Entity<Transmissions>(entity =>
            {
                entity.HasKey(e => e.TransmissionId);

                entity.ToTable("TRANSMISSIONS", "FOFC");

                entity.Property(e => e.TransmissionId).HasColumnName("TRANSMISSION_ID");

                entity.Property(e => e.AuditId).HasColumnName("AUDIT_ID");

                entity.Property(e => e.Comment)
                    .HasColumnName("COMMENT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationListCode)
                    .IsRequired()
                    .HasColumnName("DESTINATION_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationListitemCode)
                    .IsRequired()
                    .HasColumnName("DESTINATION_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProcListCode)
                    .HasColumnName("PROC_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProcListitemCode)
                    .HasColumnName("PROC_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PurposeListCode)
                    .IsRequired()
                    .HasColumnName("PURPOSE_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PurposeListitemCode)
                    .IsRequired()
                    .HasColumnName("PURPOSE_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROW_VERSION")
                    .IsRowVersion();

                entity.Property(e => e.StatusListCode)
                    .IsRequired()
                    .HasColumnName("STATUS_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusListitemCode)
                    .IsRequired()
                    .HasColumnName("STATUS_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TypeListCode)
                    .IsRequired()
                    .HasColumnName("TYPE_LIST_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TypeListitemCode)
                    .IsRequired()
                    .HasColumnName("TYPE_LISTITEM_CODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DestinationList)
                    .WithMany(p => p.TransmissionsDestinationList)
                    .HasForeignKey(d => new { d.DestinationListitemCode, d.DestinationListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANSMISSIONS_DESTINTAION");

                entity.HasOne(d => d.ProcList)
                    .WithMany(p => p.TransmissionsProcList)
                    .HasForeignKey(d => new { d.ProcListitemCode, d.ProcListCode })
                    .HasConstraintName("FK_TRANSMISSIONS_PROCESSOR");

                entity.HasOne(d => d.PurposeList)
                    .WithMany(p => p.TransmissionsPurposeList)
                    .HasForeignKey(d => new { d.PurposeListitemCode, d.PurposeListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANSMISSIONS_PURPOSE");

                entity.HasOne(d => d.StatusList)
                    .WithMany(p => p.TransmissionsStatusList)
                    .HasForeignKey(d => new { d.StatusListitemCode, d.StatusListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANSMISSIONS_STATUS");

                entity.HasOne(d => d.TypeList)
                    .WithMany(p => p.TransmissionsTypeList)
                    .HasForeignKey(d => new { d.TypeListitemCode, d.TypeListCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRANSMISSIONS_TYPE");
            });
        }
    }
}
