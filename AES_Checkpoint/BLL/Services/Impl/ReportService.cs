﻿using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Impl;

public class ReportService: IReportService
{
    private readonly IUnitOfWork _database;
    private int pageSize = 10;
    public ReportService( 
            IUnitOfWork unitOfWork)
    {
        if (unitOfWork == null)
        { 
            throw new ArgumentNullException(nameof(unitOfWork));
        }
        _database = unitOfWork;
    }
    /// <exception cref="MethodAccessException"></exception>
    public IEnumerable<ReportDTO> GetReports(int pageNumber)
    {
        var user = SecurityContext.GetUser(); 
        var userType = user.GetType();
        if (userType != typeof(Director)
            && userType != typeof(Worker))
        {
            throw new MethodAccessException();
        }
        var reasonId = user.ReasonId;
        var streetsEntities = 
            _database
                .Reports
                .Find(z => z.Reason == reasonId, pageNumber, pageSize);
        var mapper = 
            new MapperConfiguration(
                cfg => cfg.CreateMap<Report, ReportDTO>()
                ).CreateMapper();
        var reportsDto = 
            mapper
                .Map<IEnumerable<Report>, List<ReportDTO>>(
                    streetsEntities);
        return reportsDto;
    }

}