using AS_Licence.Entities.Model.Subscription;
using AS_Licence.Service.Interface.Subscription;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AS_Licence.Entities.Model.CustomerComputerInfo;
using AS_Licence.Service.Interface.Customer;

namespace AS_Licence.WebUI.CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private ISubscriptionManager _subscriptionManager;

        public SubscriptionController(ISubscriptionManager subscriptionManager)
        {
            _subscriptionManager = subscriptionManager;
        }


        [HttpPost]
        [Route("SaveSubscription")]
        public async Task<IActionResult> SaveSubscription([FromBody] Subscription subscription)
        {
            var subscriptionResult = await _subscriptionManager.SaveSubscription(subscription);
            if (subscriptionResult.Status == false)
            {
                return BadRequest(subscriptionResult);
            }

            return Ok(subscriptionResult);
        }
        //[HttpPut]
        //[Route("UpdateSubscription")]
        //public async Task<IActionResult> Put([FromBody] CustomerComputerInfo customerComputerInfo)
        //{
        //    var customerComputerInfoResult = await _customerComputerInfoManager.UpdateCustomerComputerInfo(customerComputerInfo);
        //    if (customerComputerInfoResult.Status == false)
        //    {
        //        return BadRequest(customerComputerInfoResult);
        //    }

        //    return Ok(customerComputerInfoResult);
        //}

        [HttpGet]
        [Route("GetSubscriptionSummaryListByCustomerId")]
        public async Task<IActionResult> GetSubscriptionSummaryListByCustomerId(int customerId)
        {

            var subscriptionResult = await _subscriptionManager.GetSubscriptionSummaryListByCustomerId(customerId);
            if (subscriptionResult.Status == false)
            {
                return BadRequest(subscriptionResult);
            }

            return Ok(subscriptionResult);
        }

        [HttpGet]
        [Route("GetSubscriptionBySubscriptionId")]
        public async Task<IActionResult> GetSubscriptionBySubscriptionId(int subscriptionId)
        {
            var subscriptionResult = await _subscriptionManager.GetSubscriptionBySubscriptionId(subscriptionId);
            if (subscriptionResult.Status == false)
            {
                return BadRequest(subscriptionResult);
            }

            return Ok(subscriptionResult);
        }

        [HttpDelete]
        [Route("DeleteSubscriptionBySubscriptionId/{subscriptionId}")]
        public async Task<IActionResult> DeleteSubscriptionBySubscriptionId(int subscriptionId)
        {
            var subscriptionResult = await _subscriptionManager.DeleteSubscriptionBySubscriptionId(subscriptionId);
            if (subscriptionResult.Status == false)
            {
                return BadRequest(subscriptionResult);
            }

            return Ok(subscriptionResult);
        }
    }
}