using System;
using System.Collections.Generic;

namespace SaleFlex.Data.Models
{
    public class ServiceDataModel
    {
        public struct HeaderModel
        {
            public string AppToken { get; set; }
        }

        public struct ResponseModel
        {
            public string Code { get; set; }
            public string Message { get; set; }
        }

        public struct PluModel
        {
            public long Id { get; set; }
            public long FkServerId { get; set; }
            public int FkVatId { get; set; }
            public int VatNo { get; set; }
            public int FkPluSubGroupId { get; set; }
            public int FkPluManufacturerId { get; set; }
            public string Code { get; set; }
            public string OldCode { get; set; }
            public string ShelfCode { get; set; }
            public string Name { get; set; }
            public string ShortName { get; set; }
            public string Description { get; set; }
            public string DescriptionOnScreen { get; set; }
            public string DescriptionOnShelf { get; set; }
            public string DescriptionOnScale { get; set; }
            public string KeyboardValue { get; set; }
            public bool Scalable { get; set; }
            public bool AllowDiscount { get; set; }
            public int DiscountPercent { get; set; }
            public bool AllowNegativeStock { get; set; }
            public bool AllowReturn { get; set; }
            public int Stock { get; set; }
            public string StockUnit { get; set; }
            public int StockUnitNo { get; set; }
            public int MinStock { get; set; }
            public int MaxStock { get; set; }
        }

        public struct PluStockModel
        {
            public int Id { get; set; }
            public int BarcodeId { get; set; }
            public string Barcode { get; set; }
            public long FkVatId { get; set; }
            public int VatNo { get; set; }
            public long FkPluMainGroupId { get; set; }
            public string Code { get; set; }
            public string ShortName { get; set; }
            public int Stock { get; set; }
            public string StockUnit { get; set; }
            public int StockUnitNo { get; set; }
            public int MinStock { get; set; }
            public int PurchasePrice { get; set; }
            public int SalePrice { get; set; }
        }

        public struct FormModel
        {
            public long Id { get; set; }
            public int FormNo { get; set; }
            public string Name { get; set; }
            public string Function { get; set; }
            public bool NeedLogin { get; set; }
            public bool NeedAuth { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public string FormBorderStyle { get; set; }
            public string StartPosition { get; set; }
            public string Caption { get; set; }
            public string Icon { get; set; }
            public string Image { get; set; }
            public string BackColor { get; set; }
            public bool ShowStatusBar { get; set; }
            public bool ShowInTaskbar { get; set; }
            public bool UseVirtualKeyboard { get; set; }
            public bool IsVisible { get; set; }
        }

        public struct FormControlModel
        {
            public long FkFormId { get; set; }
            public long FkParentId { get; set; }
            public string Name { get; set; }
            public string ParentName { get; set; }
            public string FormControlFunction1 { get; set; }
            public string FormControlFunction2 { get; set; }
            public int TypeNo { get; set; }
            public string Type { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int LocationX { get; set; }
            public int LocationY { get; set; }
            public string StartPosition { get; set; }
            public string Caption1 { get; set; }
            public string Caption2 { get; set; }
            public string List { get; set; }
            public string Dock { get; set; }
            public string Alignment { get; set; }
            public string TextAlignment { get; set; }
            public string CharacterCasing { get; set; }
            public string Font { get; set; }
            public string Icon { get; set; }
            public string ToolTip { get; set; }
            public string Image { get; set; }
            public string ImageSelected { get; set; }
            public bool FontAutoHeight { get; set; }
            public int FontSize { get; set; }
            public string InputType { get; set; }
            public string TextImageRelation { get; set; }
            public string BackColor { get; set; }
            public string ForeColor { get; set; }
            public string KeyboardValue { get; set; }
            public bool IsVisible { get; set; }
        }

        public struct LabelValueModel
        {
            public string Name { get; set; }
            public string CultureInfo { get; set; }
            public string KeyValue { get; set; }
        }

        public struct PaymentTypeModel
        {
            public int TypeNo { get; set; }
            public string TypeName { get; set; }
            public string TypeDescription { get; set; }
        }

        public struct PluManufacturerModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }

        public struct PluBarcodeModel
        {
            public long FkServerId { get; set; }
            public long FkPluId { get; set; }
            public string Barcode { get; set; }
            public string OldBarcode { get; set; }
            public long FkPluBarcodeDefinitionId { get; set; }
            public int PurchasePrice { get; set; }
            public int SalePrice { get; set; }
        }

        public struct PluMainGroupModel
        {
            public int Id { get; set; }
            public int No { get; set; }
            public int DiscountPercent { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int MaxPrice { get; set; }
        }

        public class PluSubGroupModel
        {
            public string Name { get; set; }
            public long FkPluMainGroupId { get; set; }
            public long No { get; set; }
            public long DiscountPercent { get; set; }
            public string Description { get; set; }
        }

        public struct VatModel
        {
            public string Name { get; set; }
            public int No { get; set; }
            public int Rate { get; set; }
            public string Description { get; set; }
        }

        public struct CashierModel
        {
            public int Id { get; set; }
            public int No { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public string IdentityNumber { get; set; }
            public string Description { get; set; }
            public bool IsAdministrator { get; set; }
        }

        public struct StockUnitModel
        {
            public int No { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Coefficient { get; set; }
        }

        public struct PosModel
        {
            public string Name { get; set; }
            public string OwnerNationalIdNumber { get; set; }
            public string OwnerTaxIdNumber { get; set; }
            public string OwnerMersisIdNumber { get; set; }
            public string OwnerCommercialRecordNo { get; set; }
            public string OwnerWebAdress { get; set; }
            public string OwnerRegistrationNumber { get; set; }
            public string MacAddress { get; set; }
            public string CashierScreenType { get; set; }
            public string CustomerScreenType { get; set; }
            public string CustomerDisplayType { get; set; }
            public string CustomerDisplayPort { get; set; }
            public string ReceiptPrinterType { get; set; }
            public string ReceiptPrinterPortName { get; set; }
            public string InvoicePrinterType { get; set; }
            public string InvoicePrinterPortName { get; set; }
            public string ScaleType { get; set; }
            public string ScalePortName { get; set; }
            public string BarcodeReaderPort { get; set; }
            public string ServerIp1 { get; set; }
            public string ServerPort1 { get; set; }
            public string ServerIp2 { get; set; }
            public string ServerPort2 { get; set; }
            public bool ForceToWorkOnline { get; set; }
            public int FkDefaultCountryId { get; set; }
            public long PluUpdateNo { get; set; }
        }

        public struct CountryModel
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public string ShortName { get; set; }
        }

        public struct TransactionDocumentType
        {
            public long Id { get; set; }
            public int No { get; set; }
            public string Name { get; set; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
        }

        public struct SetupPosResponseModel
        {
            public string AppToken { get; set; }
            public List<FormModel> FormList { get; set; }
            public List<FormControlModel> FormControlList { get; set; }
            public List<LabelValueModel> LabelValueList { get; set; }
            public List<PaymentTypeModel> PaymentTypeList { get; set; }
            public List<PluManufacturerModel> PluManufacturerList { get; set; }
            public List<PluMainGroupModel> PluMainGroupList { get; set; }
            public List<PluSubGroupModel> PluSubGroupList { get; set; }
            public List<VatModel> VatList { get; set; }
            public List<CashierModel> CashierList { get; set; }
            public List<StockUnitModel> StockUnitList { get; set; }
            public PosModel Pos { get; set; }
            public List<CountryModel> CountryList { get; set; }
            public List<PluStockModel> CommonPluList { get; set; }
            public List<TransactionDocumentType> TransactionDocumentTypeList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public struct AskForUpdate
        {
            public long PosUpdateId { get; set; }
            public DateTime UpdateDate { get; set; }
            public int UpdateTypeId { get; set; }
        }

        public struct AskForUpdateResponseModel
        {
            public List<AskForUpdate> AskForUpdateList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public struct PopUpMessageResponseModel
        {
            public string UpdateMessage { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public struct VatListResponseModel
        {
            public List<VatModel> VatList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public struct GroupListResponseModel
        {
            public List<PluMainGroupModel> MainGroupList { get; set; }
            public List<PluSubGroupModel> SubGroupList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public struct ScreenResponseModel
        {
            public List<FormModel> FormList { get; set; }
            public List<FormControlModel> FormControlList { get; set; }
            public List<LabelValueModel> LabelValueList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public struct PaymentTypeListResponseModel
        {
            public List<PaymentTypeModel> PaymentTypeList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public class PluListRequestModel
        {
            public long PluUpdateNo { get; set; }
            public HeaderModel HeaderModel { get; set; }
        }

        public class PluListResponseModel
        {
            public List<PluModel> PluList { get; set; }
            public List<PluBarcodeModel> PluBarcodeList { get; set; }
            public List<PluManufacturerModel> PluManufacturerList { get; set; }
            public long PluUpdateNo { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public struct PosResponseModel
        {
            public PosModel Pos { get; set; }
            public List<CountryModel> CountryList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public class PluListSaveRequestModel
        {
            public List<PluStockModel> PluListModel { get; set; }
            public HeaderModel HeaderModel { get; set; }
        }

        public class PluResponseModel
        {
            public int PluId { get; set; }
            public long FkServerId { get; set; }
            public long FkServerBarcodeId { get; set; }
        }

        public class PluListSaveResponseModel
        {
            public List<PluResponseModel> PluList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

        public struct UpdatePosUpdateRequestModel
        {
            public long PosUpdateId { get; set; }
            public HeaderModel HeaderModel { get; set; }
        }

        public struct TransactionListRequestModel
        {
            public List<TransactionHeadModel> TransactionHeadList { get; set; }
            public HeaderModel HeaderModel { get; set; }
        }

        public class TransactionHeadModel
        {
            public long Id { get; set; }
            public long FkCashierId { get; set; }
            //public DateTime TransactionDateTime { get; set; }
            public long FkTransactionDocumentTypeId { get; set; }
            public long FkCustomerId { get; set; }
            public long FkPosId { get; set; }
            public string TransactionNo { get; set; }
            public long ReceiptNumber { get; set; }
            public long ZNumber { get; set; }
            public long ReceiptTotalPrice { get; set; }
            public long ReceiptTotalVat { get; set; }
            public long TotalDiscountAmount { get; set; }
            public long TransactionsDiscountAmount { get; set; }
            public long CustomerTotalDiscountAmount { get; set; }
            public long PromotionTotalDiscountAmount { get; set; }
            public long SurchargeAmount { get; set; }
            public long PaymentAmount { get; set; }
            public long ChangeAmount { get; set; }
            public long RoundAmount { get; set; }
            public bool IsVoided { get; set; }
            public List<TransactionDetailModel> TransactionDetailList { get; set; }
            public List<TransactionPaymentModel> TransactionPaymentList { get; set; }
        }

        public class TransactionDetailModel
        {
            public long Id { get; set; }
            public long FkTransactionHeadId { get; set; }
            public long FkPluId { get; set; }
            public long FkServerPluId { get; set; }
            public long FkDepartmentId { get; set; }
            public long Price { get; set; }
            public long Quantity { get; set; }
            public long TotalPrice { get; set; }
            public long TotalPriceWithoutVat { get; set; }
            public long TotalVat { get; set; }
            public bool Canceled { get; set; }
            //public DateTime TransactionDetailDateTime { get; set; }
        }

        public class TransactionPaymentModel
        {
            public long Id { get; set; }
            public long FkTransactionHeadId { get; set; }
            public long FkPaymentTypeId { get; set; }
            public long PaymentAmount { get; set; }
        }

        public class TransactionResponseModel
        {
            public long TransactionId { get; set; }
            public long FkServerId { get; set; }
        }

        public class TransactionHeadResponseModel
        {
            public TransactionResponseModel TransactionHead { get; set; }
            public List<TransactionResponseModel> TransactionDetailList { get; set; }
            public List<TransactionResponseModel> TransactionPaymentList { get; set; }
        }

        public class TransactionListResponseModel
        {
            public List<TransactionHeadResponseModel> transactionHeadList { get; set; }
            public ResponseModel ResponseModel { get; set; }
        }

    }
}
