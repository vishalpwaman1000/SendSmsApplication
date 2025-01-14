﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendSmsApplication.CommonLayer.Model;
using SendSmsApplication.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendSmsApplication.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SendSmsController : ControllerBase
    {
        public readonly IDataAccessLayer _dataAccessLayer;
        public SendSmsController(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        [HttpPost]
        public async Task<IActionResult> SendOTP(SendOtpSmsRequest request)
        {
            SendOtpSmsResponse response = new SendOtpSmsResponse();
            try
            {

                response = await _dataAccessLayer.SendOTP(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> OtpVarification(OTpVarificationRequest request)
        {
            OTpVarificationResponse response = new OTpVarificationResponse();

            try
            {
                response = await _dataAccessLayer.OTpVarification(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetMobileOtpDetail(GetMobileOtpDetailRequest request)
        {
            GetMobileOtpDetailResponse response = new GetMobileOtpDetailResponse();

            try
            {
                response = await _dataAccessLayer.GetMobileOtpDetail(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
