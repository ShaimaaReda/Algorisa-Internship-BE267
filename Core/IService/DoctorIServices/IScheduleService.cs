﻿using Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.DoctorIServices
{
    public interface IScheduleService
    {
        Task Insert(DaySchedule Schesule);
    }
}
