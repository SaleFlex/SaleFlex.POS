using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using SaleFlex.Data.Models;
using SaleFlex.Data.AccessLayer;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using SaleFlex.Data;


namespace SaleFlex.POS.Manager
{
    public class ExternalService
    {
        private const string URL = "http://213.144.115.150:10000/SaleFlex/SaleFlexGate.PosService.svc/";
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
        const string method = "POST";

        public ExternalService()
        {
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        public ServiceDataModel.ResponseModel vSetupPos(long lMerchantId, int iStoreNo, long lPosId)
        {
            var query = URL + "SetupPos";
            var requestBody = new Dictionary<string, object>();

            requestBody.Add("MerchantId", lMerchantId);
            requestBody.Add("StoreNo", iStoreNo);
            requestBody.Add("PosId", lPosId);

            string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.SetupPosResponseModel setupPosResponseModel = JsonConvert.DeserializeObject<ServiceDataModel.SetupPosResponseModel>(result, jsonSettings);
                    response.Close();

                    if (setupPosResponseModel.ResponseModel.Code == "0")
                    {
                        vSaveScreen(setupPosResponseModel.FormList, setupPosResponseModel.FormControlList, setupPosResponseModel.LabelValueList);
                        vSavePaymentTypeList(setupPosResponseModel.PaymentTypeList);
                        vSavePos(setupPosResponseModel.Pos, setupPosResponseModel.CountryList);
                        vSaveGroupList(setupPosResponseModel.PluMainGroupList, setupPosResponseModel.PluSubGroupList);
                        vSaveVatList(setupPosResponseModel.VatList);
                        vSaveCashierList(setupPosResponseModel.CashierList);
                        vSaveStockUnitList(setupPosResponseModel.StockUnitList);
                        vSavePluManufacturerList(setupPosResponseModel.PluManufacturerList);
                        //vSaveCommonPluList(setupPosResponseModel.CommonPluList);
                        vSaveTransactionDocumentTypeList(setupPosResponseModel.TransactionDocumentTypeList);
                        CommonProperty.prop_strAppToken = setupPosResponseModel.AppToken;
                    }
                    return setupPosResponseModel.ResponseModel;
                }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.ResponseModel
                {
                    Code = "201",
                    Message = "Servis Hatası!"
                };
            }
        }

        public ServiceDataModel.ResponseModel vAskForUpdate()
        {
            var query = URL + "AskForService";
            var requestBody = new Dictionary<string, object>();

            requestBody.Add("AppToken", "9BFE-B7BC-4411-BA8F-0D6654627B84");
            requestBody.Add("PosId", 2);

            string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.AskForUpdateResponseModel askForUpdateResponse = JsonConvert.DeserializeObject<ServiceDataModel.AskForUpdateResponseModel>(result, jsonSettings);
                    response.Close();

                    return askForUpdateResponse.ResponseModel;
                }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.ResponseModel
                {
                    Code = "201",
                    Message = "Servis Hatası!"
                };
            }
        }

        public string vPopUpMessage()
        {
            var query = URL + "PopUpMessage";
            var requestBody = new Dictionary<string, object>();
            var headerModel = new Dictionary<string, object>();

            headerModel.Add("AppToken", "9BFE-B7BC-4411-BA8F-0D6654627B84");
            requestBody.Add("HeaderModel", headerModel);
            requestBody.Add("PosUpdateId", 1);

            string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.PopUpMessageResponseModel popUpMessageResponse = JsonConvert.DeserializeObject<ServiceDataModel.PopUpMessageResponseModel>(result, jsonSettings);
                    response.Close();

                    return popUpMessageResponse.UpdateMessage;
                }
            }
            catch (Exception ex)
            {
                return "Servis Hatası!";
                //return new ResponseModel
                //{
                //    Code = 201,
                //    Message = "Servis Hatası!"
                //};
            }
        }

        public ServiceDataModel.ResponseModel vGetVatList()
        {
            var query = URL + "GetVatList";
            var requestBody = new Dictionary<string, object>();

            requestBody.Add("AppToken", "9BFE-B7BC-4411-BA8F-0D6654627B84");

            string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.VatListResponseModel vatListResponse = JsonConvert.DeserializeObject<ServiceDataModel.VatListResponseModel>(result, jsonSettings);
                    response.Close();

                    vSaveVatList(vatListResponse.VatList);

                    return vatListResponse.ResponseModel;
                }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.ResponseModel
                {
                    Code = "201",
                    Message = "Servis Hatası!"
                };
            }
        }

        public ServiceDataModel.ResponseModel vGetGroupList()
        {
            var query = URL + "GetGroupList";
            var requestBody = new Dictionary<string, object>();

            requestBody.Add("AppToken", "9BFE-B7BC-4411-BA8F-0D6654627B84");

            string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.GroupListResponseModel groupListResponse = JsonConvert.DeserializeObject<ServiceDataModel.GroupListResponseModel>(result, jsonSettings);
                    response.Close();

                    vSaveGroupList(groupListResponse.MainGroupList, groupListResponse.SubGroupList);

                    return groupListResponse.ResponseModel;
                }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.ResponseModel
                {
                    Code = "201",
                    Message = "Servis Hatası!"
                };
            }
        }

        public ServiceDataModel.ResponseModel vGetScreen()
        {
            var query = URL + "GetScreen";
            var requestBody = new Dictionary<string, object>();

            requestBody.Add("AppToken", "9BFE-B7BC-4411-BA8F-0D6654627B84");

            string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.ScreenResponseModel screenResponse = JsonConvert.DeserializeObject<ServiceDataModel.ScreenResponseModel>(result, jsonSettings);
                    response.Close();

                    vSaveScreen(screenResponse.FormList, screenResponse.FormControlList, screenResponse.LabelValueList);

                    return screenResponse.ResponseModel;
                }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.ResponseModel
                {
                    Code = "201",
                    Message = "Servis Hatası!"
                };
            }
        }

        public ServiceDataModel.ResponseModel vGetPaymentTypeList()
        {
            var query = URL + "GetPaymentTypeList";
            var requestBody = new Dictionary<string, object>();

            requestBody.Add("AppToken", "9BFE-B7BC-4411-BA8F-0D6654627B84");

            string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.PaymentTypeListResponseModel paymentTypeResponse = JsonConvert.DeserializeObject<ServiceDataModel.PaymentTypeListResponseModel>(result, jsonSettings);
                    response.Close();

                    vSavePaymentTypeList(paymentTypeResponse.PaymentTypeList);

                    return paymentTypeResponse.ResponseModel;
                }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.ResponseModel
                {
                    Code = "201",
                    Message = "Servis Hatası!"
                };
            }
        }

        public void vGetPluList(List<ServiceDataModel.AskForUpdate> askForUpdateList)
        {
            var query = URL + "GetPosPluList";
            var pluList = new ServiceDataModel.PluListRequestModel
            {
                HeaderModel = new ServiceDataModel.HeaderModel
                {
                    AppToken = CommonProperty.prop_strAppToken
                },
                PluUpdateNo = Dao.xGetInstance().iGetPluUpdateNo()
            };

            string body = JsonConvert.SerializeObject(pluList, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.PluListResponseModel pluListResponse = JsonConvert.DeserializeObject<ServiceDataModel.PluListResponseModel>(result, jsonSettings);
                    response.Close();

                    //List<PluDataModel> list = pluListResponse.PluList.ToDefiniteItem<PluDataModel>();

                    var pluSaved = vSavePluList(pluListResponse);

                    if (pluSaved)
                    {
                        foreach (var askForUpdate in askForUpdateList)
                        {
                            vUpdatePosUpdate(askForUpdate.PosUpdateId);
                        }
                    }
                    //return pluListResponse.ResponseModel;
                }
            }
            catch (Exception ex)
            {
                //return new ServiceDataModel.ResponseModel
                //{
                //    Code = "201",
                //    Message = "Servis Hatası!"
                //};
            }
        }

        public ServiceDataModel.ResponseModel vGetPos()
        {
            var query = URL + "GetPos";
            var requestBody = new Dictionary<string, object>();
            var headerModel = new Dictionary<string, object>();

            headerModel.Add("AppToken", "9BFE-B7BC-4411-BA8F-0D6654627B84");
            requestBody.Add("HeaderModel", headerModel);
            requestBody.Add("PosId", 1);

            string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.PosResponseModel posResponse = JsonConvert.DeserializeObject<ServiceDataModel.PosResponseModel>(result, jsonSettings);
                    response.Close();

                    vSavePos(posResponse.Pos, posResponse.CountryList);

                    return posResponse.ResponseModel;
                }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.ResponseModel
                {
                    Code = "201",
                    Message = "Servis Hatası!"
                };
            }
        }

        public ServiceDataModel.PluListSaveResponseModel vSavePluList(List<ServiceDataModel.PluStockModel> pluStockList)
        {
            string URLMobile = "http://213.144.115.150:10000/SaleFlex/SaleFlexGate.MobileService.svc/";

            var query = URLMobile + "SavePluList";
            var pluList = new ServiceDataModel.PluListSaveRequestModel
            {
                HeaderModel = new ServiceDataModel.HeaderModel
                {
                    AppToken = CommonProperty.prop_strAppToken
                },
                PluListModel = pluStockList
            };

            string body = JsonConvert.SerializeObject(pluList, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.PluListSaveResponseModel responseModel = JsonConvert.DeserializeObject<ServiceDataModel.PluListSaveResponseModel>(result, jsonSettings);
                    var b = JsonConvert.SerializeObject(responseModel, jsonSettings);
                    response.Close();

                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.PluListSaveResponseModel
                {
                    ResponseModel = new ServiceDataModel.ResponseModel
                    {
                        Code = "201",
                        Message = "Servis Hatası!"
                    }
                };
            }
        }

        private ServiceDataModel.ResponseModel vUpdatePosUpdate(long posUpdateId)
        {
            var query = URL + "UpdatePosUpdate";
            var posUpdate = new ServiceDataModel.UpdatePosUpdateRequestModel
            {
                HeaderModel = new ServiceDataModel.HeaderModel
                {
                    AppToken = CommonProperty.prop_strAppToken
                },
                PosUpdateId = posUpdateId
            };

            string body = JsonConvert.SerializeObject(posUpdate, jsonSettings);

            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.ResponseModel responseModel = JsonConvert.DeserializeObject<ServiceDataModel.ResponseModel>(result, jsonSettings);
                    response.Close();
                    return responseModel;
               }
            }
            catch (Exception ex)
            {
                return new ServiceDataModel.ResponseModel
                {
                    Code = "201",
                    Message = "Servis Hatası!"
                };
            }
        }

        private void vSaveVatList(List<ServiceDataModel.VatModel> vatList)
        {
            try
            {
                foreach (ServiceDataModel.VatModel vat in vatList)
                {
                    Dao.xGetInstance().vSaveVat(vat);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        private void vSaveStockUnitList(List<ServiceDataModel.StockUnitModel> stockUnitList)
        {
            try
            {
                foreach (ServiceDataModel.StockUnitModel stock in stockUnitList)
                {
                    Dao.xGetInstance().vSaveStockUnit(stock);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        private void vSaveCashierList(List<ServiceDataModel.CashierModel> cashierList)
        {
            try
            {
                foreach (ServiceDataModel.CashierModel cashier in cashierList)
                {
                    Dao.xGetInstance().vSaveCashier(cashier);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        private void vSavePluManufacturerList(List<ServiceDataModel.PluManufacturerModel> pluManufacturerList)
        {
            try
            {
                foreach (ServiceDataModel.PluManufacturerModel pluManufacturer in pluManufacturerList)
                {
                    Dao.xGetInstance().vSavePluManufacturer(pluManufacturer);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        private void vSaveGroupList(List<ServiceDataModel.PluMainGroupModel> mainGroupList, List<ServiceDataModel.PluSubGroupModel> subGroupList)
        {
            try
            {
                foreach (ServiceDataModel.PluMainGroupModel pluMainGroup in mainGroupList)
                {
                    Dao.xGetInstance().vSavePluGroup(pluMainGroup, subGroupList.FindAll(s => s.FkPluMainGroupId == pluMainGroup.Id));
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void vSaveScreen(List<ServiceDataModel.FormModel> formList, List<ServiceDataModel.FormControlModel> formControlList, List<ServiceDataModel.LabelValueModel> labelValueList)
        {
            try
            {
                foreach (ServiceDataModel.FormModel form in formList)
                {
                    Dao.xGetInstance().vSaveForm(form, formControlList.FindAll(fc => fc.FkFormId == form.Id));
                }
                foreach (ServiceDataModel.LabelValueModel labelValue in labelValueList)
                {
                    Dao.xGetInstance().vSaveLabelValue(labelValue);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void vSavePaymentTypeList(List<ServiceDataModel.PaymentTypeModel> paymentTypeList)
        {
            try
            {
                foreach (ServiceDataModel.PaymentTypeModel paymentType in paymentTypeList)
                {
                    Dao.xGetInstance().vSavePaymentType(paymentType);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private bool vSavePluList(ServiceDataModel.PluListResponseModel pluListResponse)
        {
            try
            {
                foreach (ServiceDataModel.PluModel plu in pluListResponse.PluList)
                {
                    Dao.xGetInstance().vSavePlu(plu, pluListResponse.PluBarcodeList.Find(p => p.FkPluId == plu.Id));
                }
                Dao.xGetInstance().vUpdatePluUpdateNo(pluListResponse.PluUpdateNo);
                //foreach (ServiceDataModel.PluManufacturerModel pluManufacturer in pluManufacturerList)
                //{
                //    Dao.xGetInstance().vSavePluManufacturer(pluManufacturer);
                //}
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        private void vSavePos(ServiceDataModel.PosModel pos, List<ServiceDataModel.CountryModel> countryList)
        {
            try
            {
                Dao.xGetInstance().vSavePos(pos);

                foreach (ServiceDataModel.CountryModel country in countryList)
                {
                    Dao.xGetInstance().vSaveCountry(country);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void vSaveCommonPluList(List<ServiceDataModel.PluStockModel> CommonPluList)
        {
            try
            {
                foreach (ServiceDataModel.PluStockModel CommonPlu in CommonPluList)
                {
                    Dao.xGetInstance().vSaveCommonPlu(CommonPlu);
                }
                //foreach (ServiceDataModel.PluBarcodeModel pluBarcode in pluBarcodeList)
                //{
                //    Dao.xGetInstance().vSavePluBarcode(pluBarcode);
                //}
                //foreach (PluManufacturerDataModel pluManufacturer in pluManufacturerList)
                //{
                //    Dao.xGetInstance().vSavePluManufacturer(pluManufacturer);
                //}
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void vSaveTransactionDocumentTypeList(List<ServiceDataModel.TransactionDocumentType> transactionDocumentTypeList)
        {
            try
            {
                foreach (ServiceDataModel.TransactionDocumentType transactionDocumentType in transactionDocumentTypeList)
                {
                    Dao.xGetInstance().vSaveTransactionDocumentType(transactionDocumentType);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public ServiceDataModel.TransactionListResponseModel vSaveTransactionList(ServiceDataModel.TransactionListRequestModel transactionList)
        {
            var query = URL + "SaveTransactionList";
            string body = JsonConvert.SerializeObject(transactionList, jsonSettings);
            var request = (HttpWebRequest)HttpWebRequest.Create(query);
            request.Method = method;
            request.ContentType = "application/json";

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var requestStreamWriter = new StreamWriter(requestStream))
                    requestStreamWriter.Write(body);
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    String result = reader.ReadToEnd().Trim();

                    ServiceDataModel.TransactionListResponseModel transactionListResponseModel = JsonConvert.DeserializeObject<ServiceDataModel.TransactionListResponseModel>(result, jsonSettings);
                    response.Close();

                    return transactionListResponseModel;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message, JsonConvert.SerializeObject(transactionList, jsonSettings));
                return null;
            }
        }
    }
}
