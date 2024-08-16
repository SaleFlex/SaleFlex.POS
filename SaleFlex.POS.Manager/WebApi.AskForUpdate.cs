using System;
using System.Collections.Generic;
using System.Net;
using SaleFlex.CommonLibrary;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using SaleFlex.Data;
using SaleFlex.Data.Models;
using System.Windows.Forms;
using Newtonsoft.Json.Converters;

namespace SaleFlex.POS.Manager
{
    public partial class WebApi
    {
        private const string URL = "http://213.144.115.150:10000/SaleFlex/SaleFlexGate.PosService.svc/";
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
        const string method = "POST";

        public void vAskForUpdateThread()
        {
            jsonSettings.Converters.Add(new StringEnumConverter());
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.TypeNameHandling = TypeNameHandling.All;

            Thread xThread = new Thread(new ThreadStart(vAskForUpdate));

            xThread.Priority = ThreadPriority.AboveNormal;
            xThread.Start();
        }

        private void vAskForUpdate()
        {
            try
            {
                while (true)
                {
                    var query = URL + "AskForUpdate";
                    var requestBody = new Dictionary<string, object>();
                    var requestHeader = new Dictionary<string, object>();

                    requestHeader.Add("AppToken", CommonProperty.prop_strAppToken);
                    requestBody.Add("HeaderModel", requestHeader);
                    requestBody.Add("PosId", CommonProperty.prop_lPosId);

                    string body = JsonConvert.SerializeObject(requestBody, jsonSettings);

                    var request = (HttpWebRequest)HttpWebRequest.Create(query);
                    request.Method = method;
                    request.ContentType = "application/json";

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        using (var requestStreamWriter = new StreamWriter(requestStream))
                            requestStreamWriter.Write(body);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    using (var responseStream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(responseStream);
                        String result = reader.ReadToEnd().Trim();

                        ServiceDataModel.AskForUpdateResponseModel askForUpdateResponse = JsonConvert.DeserializeObject<ServiceDataModel.AskForUpdateResponseModel>(result, jsonSettings);

                        response.Close();

                        var askForUpdateList = askForUpdateResponse.AskForUpdateList.FindAll(update => update.UpdateTypeId == 4);
                        if (askForUpdateList.Count > 0)
                        {
                            ExternalService externalService = new ExternalService();
                            var xThreadUpdate = new Thread(() => externalService.vGetPluList(askForUpdateList));
                            xThreadUpdate.Start();
                            //Application.Idle += new Thread(new ThreadStart(externalService.vGetPluList()));

                        }
                    }
                    Thread.Sleep(60000);
                }
            }
            catch (Exception xException)
            {
                xException.strTraceError();
                //throw;
            }
        }
    }
}
