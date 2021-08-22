﻿using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using CAMMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Serilog;
using Microsoft.Data.SqlClient;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllQUSummeryQueryHandler : IRequestHandler<GetAllQuickUpdateSummeryQuery, List<QuickUpdateSummeryDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllQUSummeryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<QuickUpdateSummeryDto>> Handle(GetAllQuickUpdateSummeryQuery request, CancellationToken cancellationToken)
        {
            var quSectionList = new List<QuickUpdateSection>();

            var quUserSectionList = new List<UserQuickUpdateSection>();

            var actionList = new List<Domain.Action>();
            List<QuickUpdateSummeryDto> QUSummeryDtoList = new List<QuickUpdateSummeryDto>();
           

            if ((request.UserId != null && request.AppCode != null) && request.AppCode == "SYCLE" || request.AppCode == "INTERPLAN" || request.AppCode == "IPM")
            {
                List<Domain.UserQuickUpdateSection> UserQuickUpdateSectionlist = await GetUserQuickUpdateSectionList(request.UserId, request.AppCode);
                if (UserQuickUpdateSectionlist != null && UserQuickUpdateSectionlist.Count > 0)
                {

                }
                else
                {
                    SqlParameter[] parameters =
                             {
                               new SqlParameter("@ApplicationCode", request.AppCode)
                             };
                    List<Domain.QuickUpdateSection> QUUpdateSectionlist = await unitOfWork.GetRepository<Domain.QuickUpdateSection>().ExecuteReaderAsync<Domain.QuickUpdateSection>("[dbo].GetQuickUpdateSectionByApplicationCode", parameters);

                     QUUpdateSectionlist = QUUpdateSectionlist.GroupBy(x => x.QuickUpdateSectionID)
                                  .Select(g => g.First())
                                  .ToList();

                    foreach (var section in QUUpdateSectionlist)
                    {
                        QUSummeryDtoList.Add(
                           new QuickUpdateSummeryDto
                           {
                               QuickUpdateSectionCode = section.UniqueName,
                               QuickUpdateSectionName = section.SectionName,
                               Sort = section.Sort
                           }
                            );

                    }
                }
            }
            else
            {
                quSectionList = await unitOfWork.GetRepository<Domain.QuickUpdateSection>().GetAllAsync();

                foreach (var section in quSectionList)
                {
                    if (request.AppCode == "RISK" &&
                        (section.UniqueName == "MYRISKS" || section.UniqueName == "MYRISKACTIONS") ||
                        (section.UniqueName == "MYINCIDENTS" || section.UniqueName == "MYINCIDENTACTIONS") ||
                         (section.UniqueName == "MYAUTHORITYDOCUMENT" || section.UniqueName == "MYRECOMMENDATIONS")
                        )
                    {
                        QUSummeryDtoList.Add(
                            new QuickUpdateSummeryDto
                            {
                                QuickUpdateSectionCode = section.UniqueName,
                                QuickUpdateSectionName = section.SectionName,
                                Sort = section.Sort
                            }
                             );

                    }

                    else if (request.UserId == null && request.AppCode == null)
                    {
                        QUSummeryDtoList.Add(
                              new QuickUpdateSummeryDto
                              {
                                  QuickUpdateSectionCode = section.UniqueName,
                                  QuickUpdateSectionName = section.SectionName,
                                  Sort = section.Sort
                              }
                               );
                    }
                }
            }      

            return await Task.FromResult(QUSummeryDtoList.OrderBy(a=>a.Sort).ToList());
        }

        private async Task<List<Domain.UserQuickUpdateSection>> GetUserQuickUpdateSectionList(Guid? UserId, string AppCode)
        { 
            var quUserSectionList = new List<UserQuickUpdateSection>();

            SqlParameter[] parameters =
                                     {
                       new SqlParameter("@UserID", UserId),
                        new SqlParameter("@AppCode", AppCode)

                    };
            quUserSectionList = await unitOfWork.GetRepository<Domain.UserQuickUpdateSection>().ExecuteReaderAsync<Domain.UserQuickUpdateSection>("[dbo].GetAllUserQuickUpdateSectionByUserAppCode", parameters);

            return quUserSectionList;
        }
    }
}
