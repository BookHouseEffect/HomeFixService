using HomeFixService.WebService.Models.Api;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HomeFixService.WebService.Controllers
{
    [Authorize]
    public class ScheduleController : BaseController
    {
        private ScheduleService ScheduleService;

        public ScheduleController():base()
        {
            ScheduleService = new ScheduleService();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/schedule/work")]
        public IHttpActionResult GetWorkTime(int userId)
        {
            List<TimeSchedules> existingWorkTime;
            try
            {
                existingWorkTime = ScheduleService.GetAllWorkingIntervals(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(existingWorkTime);
        }

        [HttpPost]
        [Route("api/schedule/work")]
        public IHttpActionResult AddWorkTime(DayTimeModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            TimeSchedules newWorkTime;
            try
            {
                Users currentUser = GetUser();
                newWorkTime = ScheduleService.AddWorkingInterval(
                    currentUser.Id, 
                    model.GetUtcStartDay(), 
                    model.GetUtcStartTimeSpan(),
                    model.GetUtcEndtDay(),
                    model.GetUtcEndTimeSpan());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(newWorkTime);
        }

        [HttpPut]
        [Route("api/schedule/work")]
        public IHttpActionResult UpdateWorkTime(int id, DayTimeModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            TimeSchedules updatedWorkTime;
            try
            {
                Users currentUser = GetUser();
                updatedWorkTime = ScheduleService.UpdateWokingInterval(
                    currentUser.Id,
                    id,
                    model.GetUtcStartDay(),
                    model.GetUtcStartTimeSpan(),
                    model.GetUtcEndtDay(),
                    model.GetUtcEndTimeSpan());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(updatedWorkTime);
        }

        [HttpDelete]
        [Route("api/schedule/work")]
        public IHttpActionResult DeleteWorkTime(int id)
        {
            try
            {
                Users currentUser = GetUser();
                ScheduleService.RemoveWorkingInterval(currentUser.Id, id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(true);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/schedule/busy")]
        public IHttpActionResult GetUnvailablePeriods(int userId, [FromUri] DateTimeModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            List<BusySchedules> existingUnvailablePeriods;
            try
            {
                existingUnvailablePeriods = ScheduleService.GetAllBusyIntervalsPerPeriod(
                    userId, model.GetStartDateTime(), model.GetEndDateTime());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(existingUnvailablePeriods);
        }

        [HttpPost]
        [Route("api/schedule/busy")]
        public IHttpActionResult AddUnavailablePeriod(DateTimeModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            BusySchedules newUnavailablePeriod;
            try
            {
                Users currentUser = GetUser();
                newUnavailablePeriod = ScheduleService.AddBusyInterval(
                    currentUser.Id, model.GetStartDateTime(), model.GetEndDateTime());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(newUnavailablePeriod);
        }

        [HttpPut]
        [Route("api/schedule/busy")]
        public IHttpActionResult UpdateUnavailablePeriod(int id, DateTimeModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            BusySchedules updatedWorkTime;
            try
            {
                Users currentUser = GetUser();
                updatedWorkTime = ScheduleService.UpdateBusyInterval(
                    currentUser.Id,
                    id,
                    model.GetStartDateTime(), 
                    model.GetEndDateTime());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(updatedWorkTime);
        }

        [HttpDelete]
        [Route("api/schedule/busy")]
        public IHttpActionResult DeleteUnavailablePeriods(int id)
        {
            try
            {
                Users currentUser = GetUser();
                ScheduleService.RemoveBusyInterval(currentUser.Id, id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(true);
        }
    }
}
